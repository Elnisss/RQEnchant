using System.Collections.Generic;
using System.Linq;
using RQEnchant.CommonData;
using RQEnchant.Core;

namespace RQEnchant.PropertyData
{

    public class CurrentEcnhLvls : NotifyPropertyChangedBase
    {
        public int StartLvlText {
            get { return _startLvl; }
            set
            {
                _startLvl = value;
                if (_startLvl >= _endLvl)
                {
                    _endLvl = _startLvl + 1;
                }
                NotifyPropertyChanged("EndLvlText");
                NotifyPropertyChanged("LastEnchLvlVariants");
            }
        }
        public int EndLvlText {
            get { return _endLvl; }
            set
            {
                _endLvl = value;
                NotifyPropertyChanged("EndLvlText");
            }
        }

        public static List<int> StartEnchLvlVariants {
            get
            {
                return DefaultEnchData.DefaultEcnhLvl.Where(lvl => lvl != DefaultEnchData.DefaultEcnhLvl.Last()).ToList();
            }
        } 
        public List<int> EndEnchLvlVariants
        {
            get
            {
                return DefaultEnchData.DefaultEcnhLvl.Where(lvl => lvl > StartLvlText).ToList();
            }
        }

        private int _startLvl = 0;
        private int _endLvl = 1;

        public CurrentEcnhLvls()
        {
        }
    }
}