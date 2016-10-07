using System.Collections.Generic;

namespace RQEnchant.CommonData
{
    public static class GameStaticParam
    {
        public static readonly List<string> Grades = new List<string>()
        {
            GameNames.GradeA, GameNames.GradeB, GameNames.GradeC
        };

        public static readonly List<string> ItemTypes = new List<string>()
        {
            GameNames.Armor, GameNames.OneHnd, GameNames.TwoHnd
        };

        public static readonly List<string> EnchStoneNames = new List<string>()
        {
            GameNames.AshkStName, GameNames.BlackStName, GameNames.WhiteStName, GameNames.RedStName
        };

        public static readonly List<double> EnchArmorAChances = new List<double>()
        {
            100, 90, 80, 65, 50, 20, 10, 5, 2.5, 0.5
        };

        public static readonly List<double> EnchArmorBChances = new List<double>()
        {
            100, 90, 80, 70, 65, 50, 30, 20, 10, 5
        };

        public static readonly List<double> EnchArmorCChances = new List<double>()
        {
            100, 90, 85, 75, 65, 50, 40, 30, 20, 20
        };

        public static readonly List<double> Ench1HWeaponAChances = new List<double>()
        {
            100, 80, 67, 50, 25, 7, 4, 2, 1, 0.4
        };
        public static readonly List<double> Ench1HWeaponBChances = new List<double>()
        {
            100, 90, 80, 65, 50, 20, 10, 5, 3, 2
        };
        public static readonly List<double> Ench1HWeaponCChances = new List<double>()
        {
            100, 90, 75, 60, 50, 40, 30, 20, 14, 8
        };

        public static readonly List<double> Ench2HWeaponAChances = new List<double>()
        {
            100, 67, 50, 25, 12, 4, 2, 1, 0.5, 0.2
        };
        public static readonly List<double> Ench2HWeaponBChances = new List<double>()
        {
            100, 67, 50, 30, 20, 16, 8, 4, 2, 1
        };

        public static readonly List<double> Ench2HWeaponCChances = new List<double>()
        {
            100, 90, 70, 50, 30, 20, 15, 10, 7, 4
        };

        public static int GetStoneEnchRate(string stoneName)
        {
            switch (stoneName)
            {
                case GameNames.AshkStName:
                    return 1;
                case GameNames.BlackStName:
                    return 2;
                case GameNames.WhiteStName:
                    return 4;
                case GameNames.RedStName:
                    return 6;
                default:
                    return 1;
            }
        }
    }
}