using System.Collections.Generic;
using RQEnchant.PropertyData;

namespace RQEnchant.CommonData
{
    public static class DefaultEnchData
    {
        public static readonly StonePrices DefaultStonePrices = new StonePrices(5000, 150000, 670000, 1100000, 270000);

        public static readonly List<int> DefaultEcnhLvl = new List<int>()
        {
           0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };

        public static readonly List<string> DefaultLvlNames = new List<string>()
        {
            "Plus1", "Plus2", "Plus3", "Plus4", "Plus5", "Plus6", "Plus7", "Plus8", "Plus9", "Plus10"
        };

        public static readonly List<EnchIterationStateBase> EnchAArmorValue = new List<EnchIterationStateBase>
        {
            new EnchIterationStateBase(17000, 13380, GameNames.AshkStName, false), //1
            new EnchIterationStateBase(19000, 15172, GameNames.AshkStName, false), //2
            new EnchIterationStateBase(21000, 16600, GameNames.AshkStName, false), //3
            new EnchIterationStateBase(23000, 17850, GameNames.AshkStName, false), //4
            new EnchIterationStateBase(25000, 18743, GameNames.AshkStName, false), //5
            new EnchIterationStateBase(27000, 19338, GameNames.AshkStName, false), //6
            new EnchIterationStateBase(29453, 19338, GameNames.BlackStName, true), //7
            new EnchIterationStateBase(32130, 20000, GameNames.BlackStName, true), //8
            new EnchIterationStateBase(34808, 21000, GameNames.WhiteStName, true), //9
            new EnchIterationStateBase(37486, 22000, GameNames.RedStName, true)    //10
        };
        public static readonly List<EnchIterationStateBase> EnchBArmorValue = new List<EnchIterationStateBase>
        {
            new EnchIterationStateBase(17001, 13381, GameNames.AshkStName, false), //1
            new EnchIterationStateBase(19000, 15172, GameNames.AshkStName, false), //2
            new EnchIterationStateBase(21000, 16600, GameNames.AshkStName, false), //3
            new EnchIterationStateBase(23000, 17850, GameNames.AshkStName, false), //4
            new EnchIterationStateBase(25000, 18743, GameNames.AshkStName, false), //5
            new EnchIterationStateBase(27000, 19338, GameNames.AshkStName, false), //6
            new EnchIterationStateBase(29453, 19338, GameNames.BlackStName, true), //7
            new EnchIterationStateBase(32130, 20000, GameNames.BlackStName, true), //8
            new EnchIterationStateBase(34808, 21000, GameNames.WhiteStName, true), //9
            new EnchIterationStateBase(37486, 22000, GameNames.RedStName, true)    //10
        };
        public static readonly List<EnchIterationStateBase> EnchCArmorValue = new List<EnchIterationStateBase>
        {
            new EnchIterationStateBase(17002, 13382, GameNames.AshkStName, false), //1
            new EnchIterationStateBase(19000, 15172, GameNames.AshkStName, false), //2
            new EnchIterationStateBase(21000, 16600, GameNames.AshkStName, false), //3
            new EnchIterationStateBase(23000, 17850, GameNames.AshkStName, false), //4
            new EnchIterationStateBase(25000, 18743, GameNames.AshkStName, false), //5
            new EnchIterationStateBase(27000, 19338, GameNames.AshkStName, false), //6
            new EnchIterationStateBase(29453, 19338, GameNames.BlackStName, true), //7
            new EnchIterationStateBase(32130, 20000, GameNames.BlackStName, true), //8
            new EnchIterationStateBase(34808, 21000, GameNames.WhiteStName, true), //9
            new EnchIterationStateBase(37486, 22000, GameNames.RedStName, true)    //10
        };
        public static readonly List<EnchIterationStateBase> EnchAWeapon1HValue = new List<EnchIterationStateBase>
        {
            new EnchIterationStateBase(17003, 13383, GameNames.AshkStName, false), //1
            new EnchIterationStateBase(19000, 15172, GameNames.AshkStName, false), //2
            new EnchIterationStateBase(21000, 16600, GameNames.AshkStName, false), //3
            new EnchIterationStateBase(23000, 17850, GameNames.AshkStName, false), //4
            new EnchIterationStateBase(25000, 18743, GameNames.AshkStName, false), //5
            new EnchIterationStateBase(27000, 19338, GameNames.AshkStName, false), //6
            new EnchIterationStateBase(29453, 19338, GameNames.BlackStName, true), //7
            new EnchIterationStateBase(32130, 20000, GameNames.BlackStName, true), //8
            new EnchIterationStateBase(34808, 21000, GameNames.WhiteStName, true), //9
            new EnchIterationStateBase(37486, 22000, GameNames.RedStName, true)    //10
        };
        public static readonly List<EnchIterationStateBase> EnchBWeapon1HValue = new List<EnchIterationStateBase>
        {
            new EnchIterationStateBase(17004, 13384, GameNames.AshkStName, false), //1
            new EnchIterationStateBase(19000, 15172, GameNames.AshkStName, false), //2
            new EnchIterationStateBase(21000, 16600, GameNames.AshkStName, false), //3
            new EnchIterationStateBase(23000, 17850, GameNames.AshkStName, false), //4
            new EnchIterationStateBase(25000, 18743, GameNames.AshkStName, false), //5
            new EnchIterationStateBase(27000, 19338, GameNames.AshkStName, false), //6
            new EnchIterationStateBase(29453, 19338, GameNames.BlackStName, true), //7
            new EnchIterationStateBase(32130, 20000, GameNames.BlackStName, true), //8
            new EnchIterationStateBase(34808, 21000, GameNames.WhiteStName, true), //9
            new EnchIterationStateBase(37486, 22000, GameNames.RedStName, true)    //10
        };
        public static readonly List<EnchIterationStateBase> EnchCWeapon1HValue = new List<EnchIterationStateBase>
        {
            new EnchIterationStateBase(17005, 13385, GameNames.AshkStName, false), //1
            new EnchIterationStateBase(19000, 15172, GameNames.AshkStName, false), //2
            new EnchIterationStateBase(21000, 16600, GameNames.AshkStName, false), //3
            new EnchIterationStateBase(23000, 17850, GameNames.AshkStName, false), //4
            new EnchIterationStateBase(25000, 18743, GameNames.AshkStName, false), //5
            new EnchIterationStateBase(27000, 19338, GameNames.AshkStName, false), //6
            new EnchIterationStateBase(29453, 19338, GameNames.BlackStName, true), //7
            new EnchIterationStateBase(32130, 20000, GameNames.BlackStName, true), //8
            new EnchIterationStateBase(34808, 21000, GameNames.WhiteStName, true), //9
            new EnchIterationStateBase(37486, 22000, GameNames.RedStName, true)    //10
        };
        public static readonly List<EnchIterationStateBase> EnchAWeapon2HValue = new List<EnchIterationStateBase>
        {
            new EnchIterationStateBase(17006, 13386, GameNames.AshkStName, false), //1
            new EnchIterationStateBase(19000, 15172, GameNames.AshkStName, false), //2
            new EnchIterationStateBase(21000, 16600, GameNames.AshkStName, false), //3
            new EnchIterationStateBase(23000, 17850, GameNames.AshkStName, false), //4
            new EnchIterationStateBase(25000, 18743, GameNames.AshkStName, false), //5
            new EnchIterationStateBase(27000, 19338, GameNames.AshkStName, false), //6
            new EnchIterationStateBase(29453, 19338, GameNames.BlackStName, true), //7
            new EnchIterationStateBase(32130, 20000, GameNames.BlackStName, true), //8
            new EnchIterationStateBase(34808, 21000, GameNames.WhiteStName, true), //9
            new EnchIterationStateBase(37486, 22000, GameNames.RedStName, true)    //10
        };
        public static readonly List<EnchIterationStateBase> EnchBWeapon2HValue = new List<EnchIterationStateBase>
        {
            new EnchIterationStateBase(17007, 13387, GameNames.AshkStName, false), //1
            new EnchIterationStateBase(19000, 15172, GameNames.AshkStName, false), //2
            new EnchIterationStateBase(21000, 16600, GameNames.AshkStName, false), //3
            new EnchIterationStateBase(23000, 17850, GameNames.AshkStName, false), //4
            new EnchIterationStateBase(25000, 18743, GameNames.AshkStName, false), //5
            new EnchIterationStateBase(27000, 19338, GameNames.AshkStName, false), //6
            new EnchIterationStateBase(29453, 19338, GameNames.BlackStName, true), //7
            new EnchIterationStateBase(32130, 20000, GameNames.BlackStName, true), //8
            new EnchIterationStateBase(34808, 21000, GameNames.WhiteStName, true), //9
            new EnchIterationStateBase(37486, 22000, GameNames.RedStName, true)    //10
        };
        public static readonly List<EnchIterationStateBase> EnchCWeapon2HValue = new List<EnchIterationStateBase>
        {
            new EnchIterationStateBase(17008, 13388, GameNames.AshkStName, false), //1
            new EnchIterationStateBase(19000, 15172, GameNames.AshkStName, false), //2
            new EnchIterationStateBase(21000, 16600, GameNames.AshkStName, false), //3
            new EnchIterationStateBase(23000, 17850, GameNames.AshkStName, false), //4
            new EnchIterationStateBase(25000, 18743, GameNames.AshkStName, false), //5
            new EnchIterationStateBase(27000, 19338, GameNames.AshkStName, false), //6
            new EnchIterationStateBase(29453, 19338, GameNames.BlackStName, true), //7
            new EnchIterationStateBase(32130, 20000, GameNames.BlackStName, true), //8
            new EnchIterationStateBase(34808, 21000, GameNames.WhiteStName, true), //9
            new EnchIterationStateBase(37486, 22000, GameNames.RedStName, true)    //10
        };
    }
}