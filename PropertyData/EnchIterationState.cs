using System;
using RQEnchant.CommonData;
using RQEnchant.Core;

namespace RQEnchant.PropertyData
{
    public class EnchIterationState : NotifyPropertyChangedBase
    {
        public readonly string Name;

        public int EcnhPiece
        {
            get { return StoneType == GameNames.AshkStName ? _ecnhAshkPiece : _ecnhPremPiece; }
            set
            {
                if (StoneType == GameNames.AshkStName)
                {
                    _ecnhAshkPiece = value;
                }
                else
                {
                    _ecnhPremPiece = value;
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

        private readonly double _chance;

        public int _ecnhPremPiece;
        public int _ecnhAshkPiece;
        private string _stoneType;
        private bool _runeIsUsed;

        public EnchIterationState(string name, double chance, int ecnhPremPiece, int enchAshkPeice, string stoneType, bool runeIsUsed)
        {
            Name = name;
            _chance = chance;
            _ecnhPremPiece = ecnhPremPiece;
            _ecnhAshkPiece = enchAshkPeice;
            _stoneType = stoneType;
            _runeIsUsed = runeIsUsed;
        }
    }
}