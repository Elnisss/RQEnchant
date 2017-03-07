using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Стоимость прокруток
        /// </summary>
        public double TotalEcnhItepationPrice { get; set; }
        public double TotalIterationCount => Math.Round(Ashkalot.TotalCount
                                             + BlackStone.TotalCount
                                             + WhiteStone.TotalCount
                                             + RedStone.TotalCount, 2);
        /// <summary>
        /// Суммарная стоимость заточки
        /// </summary>
        public double TotalEnchPrice => Ashkalot.TotalPrice
                                        + BlackStone.TotalPrice
                                        + WhiteStone.TotalPrice
                                        + RedStone.TotalPrice
                                        + Rune.TotalPrice
                                        + TotalEcnhItepationPrice;

        public double FirstTryChance { get; set; } = 100;

        public readonly EnchPropertyData EnchProperyData;

        public readonly List<EnchElementData> Enchantes;

        public EnchCalcResult(EnchPropertyData enchProperyData, StonePrices stonePrice)
        {
            EnchProperyData = enchProperyData;

            Ashkalot = new EnchElementData(stonePrice.AshkPrice, GameNames.AshkStName);
            BlackStone = new EnchElementData(stonePrice.BlackStPrice, GameNames.BlackStName);
            WhiteStone = new EnchElementData(stonePrice.WhiteStPrice, GameNames.WhiteStName);
            RedStone = new EnchElementData(stonePrice.RedStPrice, GameNames.RedStName);
            Rune = new EnchElementData(stonePrice.RunePrice, GameNames.Rune);

            Enchantes = new List<EnchElementData>() {Ashkalot, BlackStone, WhiteStone, RedStone, Rune};
        }

        public void Clear()
        {
            Enchantes.ForEach(e => e.TotalCount = 0);
        }
    }
}