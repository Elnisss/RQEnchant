using System;
using RQEnchant.CommonData;
using RQEnchant.Core;

namespace RQEnchant.PropertyData
{
    public class EnchIterationState : NotifyPropertyChangedBase
    {
        public readonly string Name;

        public int EcnhTryPiece
        {
            get { return StoneType == GameNames.AshkStName ? EcnhAshkTryPiece : EcnhPremTryPiece; }
            set
            {
                if (StoneType == GameNames.AshkStName)
                {
                    EcnhAshkTryPiece = value;
                }
                else
                {
                    EcnhPremTryPiece = value;
                }

                NotifyPropertyChanged("EcnhPiece");
            }
        }
        public string StoneType
        {
            get { return _stoneType; }
            set
            {
                _stoneType = value;
                NotifyPropertyChanged("StoneType");
                NotifyPropertyChanged("Chance");
                NotifyPropertyChanged("EcnhPiece");
            }
        }

        public double Chance
        {
            get
            {
                var realCahnce = Math.Round(GameStaticParam.GetStoneEnchRate(StoneType)*_chance, 2);
                return realCahnce > 100 ? 100 : realCahnce;
            }
        }

        public bool RuneIsUsed
        {
            get { return _runeIsUsed; }
            set
            {
                _runeIsUsed = value;
                NotifyPropertyChanged("RuneIsUsed");
            }
        }

        public int EcnhPremTryPiece { get; private set; }
        public int EcnhAshkTryPiece { get; private set; }

        private readonly double _chance;
        private string _stoneType;
        private bool _runeIsUsed;

        public EnchIterationState(string name, double chance, int ecnhPremTryPiece, int enchAshkTryPeice, string stoneType, bool runeIsUsed)
        {
            Name = name;
            EcnhPremTryPiece = ecnhPremTryPiece;
            EcnhAshkTryPiece = enchAshkTryPeice;

            _chance = chance;
            _stoneType = stoneType;
            _runeIsUsed = runeIsUsed;
        }
    }
}