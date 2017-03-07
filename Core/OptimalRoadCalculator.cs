using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Documents;
using RQEnchant.CommonData;
using RQEnchant.PropertyData;

namespace RQEnchant.Core
{
    public class OptimalRoadCalculator : IRoadCalculator
    {
        private EnchCalcResult EnchCalcResult { get; }
        public readonly EnchPropertyData EnchProperyData;
        private readonly StonePrices _stonePrice;
        private readonly List<double> _chances;


        public OptimalRoadCalculator(EnchPropertyData enchProperyData, StonePrices stonePrice, List<double> chances)
        {
            EnchProperyData = enchProperyData;
            _stonePrice = stonePrice;
            _chances = chances;
            EnchCalcResult = new EnchCalcResult(enchProperyData, stonePrice);
        }

        public EnchCalcResult Calculate(int startLvl, int endLvl)
        {
            var enchSteps = new List<EnchIterationCostVariant>();
            double totalCostForStartlLvl = 0;

            for (var i = 0; i < startLvl; i++)
            {
                enchSteps.Add(CalculateStep(i, enchSteps));
                totalCostForStartlLvl += enchSteps[i].TotalCost;
            }

            if (totalCostForStartlLvl > _stonePrice.RunePrice)
            {
                EnchCalcResult.Clear();
            }

            for (var i = startLvl; i < endLvl; i++)
            {
                enchSteps.Add(CalculateStep(i, enchSteps));
            }

            CalculateResult(enchSteps);

            var chances = EnchCalcResult.EnchProperyData.EnchLvls.Select(ench => ench.Chance).ToList();
            for (var i = startLvl; i < endLvl; i++)
            {
                EnchCalcResult.FirstTryChance *= chances[i] / 100;
            }

            return EnchCalcResult;
        }

        private void CalculateResult(List<EnchIterationCostVariant> enchSteps)
        {
            EnchCalcResult.Ashkalot.TotalCount = enchSteps.Sum(e => e.AllEnchStoneCost.First(st => st.Name == GameNames.AshkStName).TotalCount);
            EnchCalcResult.BlackStone.TotalCount = enchSteps.Sum(e => e.AllEnchStoneCost.First(st => st.Name == GameNames.BlackStName).TotalCount);
            EnchCalcResult.WhiteStone.TotalCount = enchSteps.Sum(e => e.AllEnchStoneCost.First(st => st.Name == GameNames.WhiteStName).TotalCount);
            EnchCalcResult.RedStone.TotalCount = enchSteps.Sum(e => e.AllEnchStoneCost.First(st => st.Name == GameNames.RedStName).TotalCount);
            EnchCalcResult.Rune.TotalCount = enchSteps.Sum(e => e.AllEnchStoneCost.First(st => st.Name == GameNames.Rune).TotalCount);

        }

        private EnchIterationCostVariant CalculateStep(int i, IList<EnchIterationCostVariant> enchSteps)
        {
            var prevEnchLvl = i < 1 ? EnchIterationCostVariant.GetDefault(_stonePrice) : enchSteps[i - 1];
            var enchLvlVar = CalculateEnchLvl(i, prevEnchLvl);
            
            EnchProperyData.EnchLvls[i].StoneType = enchLvlVar.Stone.Name;
            EnchProperyData.EnchLvls[i].RuneIsUsed = enchLvlVar.RuneIsUsed;

            EnchCalcResult.TotalEcnhItepationPrice += enchLvlVar.EnhTryCost;

            return enchLvlVar;
        }

        private EnchIterationCostVariant CalculateEnchLvl(int lvl, EnchIterationCostVariant prevEnchVariant)
        {
            var ashkCount = 1/(_chances[lvl] /100);
            var blackStCount = ashkCount / 2  < 1 ? 1 : ashkCount / 2;
            var whiteStCount = ashkCount / 4 < 1 ? 1 : ashkCount / 4;
            var redStCount = ashkCount / 6 < 1 ? 1 : ashkCount / 6;

            var runeCostAshk = (prevEnchVariant.TotalCost < _stonePrice.RunePrice) ? 0: _stonePrice.RunePrice;
            var runeCostPrem =  _stonePrice.RunePrice;

            var variants = new List<EnchIterationCostVariant>()
            {
                SetEnchIterationVariant(GameNames.AshkStName, ashkCount, runeCostAshk, lvl, prevEnchVariant),
                SetEnchIterationVariant(GameNames.BlackStName, blackStCount, runeCostPrem, lvl, prevEnchVariant),
                SetEnchIterationVariant(GameNames.WhiteStName, whiteStCount, runeCostPrem, lvl, prevEnchVariant),
                SetEnchIterationVariant(GameNames.RedStName, redStCount, runeCostPrem, lvl, prevEnchVariant)
            };

            return GetMinIterationCost(variants);
        }

        private EnchIterationCostVariant SetEnchIterationVariant(
            string name, double enchCount, double runeCost, int lvl, EnchIterationCostVariant prevEnchVariant)
        {
            if (enchCount <= 1)
            {
                runeCost = 0;
            }

            var stPrice = _stonePrice.BlackStPrice;
            var enchTryPrice = EnchProperyData.EnchLvls[lvl].EcnhPremTryPiece;

            switch (name)
            {
                case GameNames.AshkStName:
                    stPrice = _stonePrice.AshkPrice;
                    enchTryPrice = EnchProperyData.EnchLvls[lvl].EcnhAshkTryPiece;
                    break;
                case GameNames.BlackStName:
                    stPrice = _stonePrice.BlackStPrice;
                    break;
                case GameNames.WhiteStName:
                    stPrice = _stonePrice.WhiteStPrice;
                    break;
                case GameNames.RedStName:
                    stPrice = _stonePrice.RedStPrice;
                    break;
            }

            return
                new EnchIterationCostVariant(
                    new EnchElementData(stPrice, name) {TotalCount = enchCount }, 
                    enchCount * enchTryPrice,
                    runeCost > 0 ? enchCount : 0,
                    prevEnchVariant);
        }

        private EnchIterationCostVariant GetMinIterationCost(IReadOnlyCollection<EnchIterationCostVariant> enchVariants)
        {
            var minItem = enchVariants.First();

            foreach (var variant in enchVariants)
            {
                if (variant.TotalCost < minItem.TotalCost)
                {
                    minItem = variant;
                }
            }
            return minItem;
        }

        public class EnchIterationCostVariant
        {
            public EnchElementData Stone { get; }
            public bool RuneIsUsed { get; }
            public double TotalCost
            {
                get { return AllEnchStoneCost.Sum(e => e.TotalPrice) + EnhTryCost; } 
            }

            public double EnhTryCost{ get; }

            public readonly List<EnchElementData> AllEnchStoneCost = new List<EnchElementData>();

            public EnchIterationCostVariant(
                EnchElementData thisLvlEnchData, double enhTryCost, double runeCount, EnchIterationCostVariant prevEnchVariant)
            {
                Stone = thisLvlEnchData;
                RuneIsUsed = runeCount > 0;

                prevEnchVariant.AllEnchStoneCost.ForEach(prEl => AllEnchStoneCost.Add(new EnchElementData(prEl.Price, prEl.Name) { TotalCount = prEl.TotalCount }));

                foreach (var ecnhSt in AllEnchStoneCost)
                {
                    //учитываем затраты на то что нам придется делать предыдущие прокрутки если мы конечно не используем руну.
                    ecnhSt.TotalCount = RuneIsUsed ? 0 : (thisLvlEnchData.TotalCount - 1) * ecnhSt.TotalCount;
                    
                    if (ecnhSt.Name == thisLvlEnchData.Name)
                    {
                        ecnhSt.TotalCount += thisLvlEnchData.TotalCount;
                    }
                    if (ecnhSt.Name == GameNames.Rune)
                    {
                        ecnhSt.TotalCount += runeCount;
                    }
                }

                EnhTryCost = enhTryCost;
                EnhTryCost = RuneIsUsed ? EnhTryCost : EnhTryCost + (thisLvlEnchData.TotalCount - 1) * prevEnchVariant.EnhTryCost;
            }


            private EnchIterationCostVariant(List<EnchElementData> allEnchStoneCost)
            {
                AllEnchStoneCost = allEnchStoneCost;
            }

            public static EnchIterationCostVariant GetDefault(StonePrices stonePrice)
            {
                var allEnchStoneCost = new List<EnchElementData>()
                {
                    new EnchElementData(stonePrice.AshkPrice, GameNames.AshkStName),
                    new EnchElementData(stonePrice.BlackStPrice, GameNames.BlackStName),
                    new EnchElementData(stonePrice.WhiteStPrice, GameNames.WhiteStName),
                    new EnchElementData(stonePrice.RedStPrice, GameNames.RedStName),
                    new EnchElementData(stonePrice.RunePrice, GameNames.Rune),
                };

                var result = new EnchIterationCostVariant(allEnchStoneCost);
                return result;
            }
        }
    }
}