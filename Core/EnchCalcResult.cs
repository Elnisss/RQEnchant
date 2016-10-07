using System;
using System.Linq;
using RQEnchant.CommonData;
using RQEnchant.PropertyData;

namespace RQEnchant.Core
{
    public class EnchCalcResult : NotifyPropertyChangedBase
    {
        public EnchElementData Ashkalot { get; }
        public EnchElementData BlackStone { get; }
        public EnchElementData WhiteStone { get; }
        public EnchElementData RedStone { get; }
        public EnchElementData Rune { get; }
        public double TotalEcnhItepationPrice { get; set; }
        public double TotalIterationCount => Math.Round(Ashkalot.TotalCount
                                             + BlackStone.TotalCount
                                             + WhiteStone.TotalCount
                                             + RedStone.TotalCount, 2);

        public double TotalEnchPrice => Ashkalot.TotalPrice
                                        + BlackStone.TotalPrice
                                        + WhiteStone.TotalPrice
                                        + RedStone.TotalPrice
                                        + Rune.TotalPrice
                                        + TotalEcnhItepationPrice;

        public double FirstTryChance { get; set; } = 100;

        private readonly EnchPropertyData _enchProperyData;

        public EnchCalcResult(EnchPropertyData enchProperyData, StonePrices stonePrice)
        {
            _enchProperyData = enchProperyData;

            Ashkalot = new EnchElementData(stonePrice.AshkPrice);
            BlackStone = new EnchElementData(stonePrice.BlackStPrice);
            WhiteStone = new EnchElementData(stonePrice.WhiteStPrice);
            RedStone = new EnchElementData(stonePrice.RedStPrice);
            Rune = new EnchElementData(stonePrice.RunePrice);

        }

        public void Calculate(int startLvl, int endLvl)
        {
            //сэкономленные камни в результате отката на эту позицию с более высокой итерации
            double iterationStBonus = 0;
            double secondIterationStBonus = 0;
            double iterationStMultipler = 1;

            for (var i = endLvl - 1; i >= startLvl; i--)
            {
                var enchLvl = _enchProperyData.EnchLvls[i];
                var lastChance = enchLvl.Chance;

                var iterationStCount = (100 / lastChance) * iterationStMultipler - iterationStBonus;

                TotalEcnhItepationPrice += iterationStCount * enchLvl.EcnhPiece;

                switch (enchLvl.StoneType)
                {
                    case GameNames.AshkStName:
                    {
                        Ashkalot.TotalCount += iterationStCount;
                        break;
                    }
                    case GameNames.BlackStName:
                    {
                        BlackStone.TotalCount += iterationStCount;
                        break;
                    }
                    case GameNames.WhiteStName:
                    {
                        WhiteStone.TotalCount += iterationStCount;
                        break;
                    }
                    case GameNames.RedStName:
                    {
                        RedStone.TotalCount += iterationStCount;
                        break;
                    }
                }

                iterationStBonus = secondIterationStBonus;

                if (enchLvl.RuneIsUsed)
                {
                    Rune.TotalCount += iterationStCount;
                    secondIterationStBonus = 0;
                    iterationStMultipler = 1;
                }
                else
                {
                    secondIterationStBonus = iterationStCount - 1 * iterationStMultipler;
                    iterationStMultipler = iterationStCount;
                }
            }
            var chances = _enchProperyData.EnchLvls.Select(ench => ench.Chance).ToList();
            for (var i = startLvl; i < endLvl; i++)
            {
                FirstTryChance *= chances[i] / 100;
            }
            FirstTryChance = Math.Round(FirstTryChance, 6);
        }
    }
}