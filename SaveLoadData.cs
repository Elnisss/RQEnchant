using System.Collections.Generic;
using RQEnchant.PropertyData;

namespace RQEnchant
{
    public class SaveLoadData
    {
        public Dictionary<string, List<EnchIterationStateBase>> EnchLvlData { get; set; }
        public StonePrices StonePrices { get; set; }

        public string Grade { get; set; }
        public string ItemType { get; set; }
        public int StartEnchLvl { get; set; }
        public int EndEnchLvl { get; set; }

        public SaveLoadData(
            Dictionary<string, List<EnchIterationStateBase>> enchLvlData, 
            StonePrices stonePrices, 
            string grade, 
            string itemType,
            int startEnchLvl,
            int endEnchLvl)
        {
            EnchLvlData = enchLvlData;
            StonePrices = stonePrices;
            Grade = grade;
            ItemType = itemType;
            StartEnchLvl = startEnchLvl;
            EndEnchLvl = endEnchLvl;
        }
    }
}