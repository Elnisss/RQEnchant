using System;
using System.Linq;
using RQEnchant.CommonData;
using RQEnchant.PropertyData;

namespace RQEnchant.Core
{
    public class ManualRoadCalculator : RoadCalculatorBase
    {
        public ManualRoadCalculator(EnchPropertyData enchProperyData, StonePrices stonePrice)
            :base(enchProperyData, stonePrice)
        {
        }

        public override EnchCalcResult Calculate(int startLvl, int endLvl)
        {
            //сэкономленные камни в результате отката на эту позицию с более высокой итерации
            double iterationStBonus = 0;
            double secondIterationStBonus = 0;
            double iterationStMultipler = 1;

            for (var i = endLvl - 1; i >= 0; i--)
            {
                var enchLvl = EnchCalcResult.EnchProperyData.EnchLvls[i];
                var iterationChance = enchLvl.Chance / 100;

                var iterationStCount = (iterationStMultipler - iterationStBonus) / iterationChance;

                EnchCalcResult.TotalEcnhItepationPrice += iterationStCount * enchLvl.EcnhTryPiece;

                switch (enchLvl.StoneType)
                {
                    case GameNames.AshkStName:
                    {
                        EnchCalcResult.Ashkalot.TotalCount += iterationStCount;
                        break;
                    }
                    case GameNames.BlackStName:
                    {
                        EnchCalcResult.BlackStone.TotalCount += iterationStCount;
                        break;
                    }
                    case GameNames.WhiteStName:
                    {
                        EnchCalcResult.WhiteStone.TotalCount += iterationStCount;
                        break;
                    }
                    case GameNames.RedStName:
                    {
                        EnchCalcResult.RedStone.TotalCount += iterationStCount;
                        break;
                    }
                }

                iterationStBonus = secondIterationStBonus;

                if (enchLvl.RuneIsUsed)
                {
                    EnchCalcResult.Rune.TotalCount += iterationStCount;

                    if (startLvl >= i)
                    {
                        break;
                    }

                    secondIterationStBonus = 0;
                    iterationStMultipler = 1;
                }
                else
                { 
                    secondIterationStBonus = iterationStCount - iterationStCount * iterationChance; //secondIterationStBonus
                    iterationStMultipler = iterationStCount;

                    if (startLvl == i)
                    {
                        iterationStMultipler--;
                    }
                }
            }

            var chances = EnchCalcResult.EnchProperyData.EnchLvls.Select(ench => ench.Chance).ToList();
            for (var i = startLvl; i < endLvl; i++)
            {
                EnchCalcResult.FirstTryChance *= chances[i] / 100;
            }
            EnchCalcResult.FirstTryChance = Math.Round(EnchCalcResult.FirstTryChance, 6);

            return EnchCalcResult;
        }
    }
}