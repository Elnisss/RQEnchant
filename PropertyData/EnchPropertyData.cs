using System.Collections.Generic;
using RQEnchant.CommonData;
using RQEnchant.Core;

namespace RQEnchant.PropertyData
{
    public class EnchPropertyData : NotifyPropertyChangedBase
    {
        #region EnchLvls
        public EnchIterationState Plus1
        {
            get { return EnchLvls[0]; }

            set
            {
                EnchLvls[0] = value;
                Notify(Plus1);
            }
        }
        public EnchIterationState Plus2
        {
            get { return EnchLvls[1]; }

            set
            {
                EnchLvls[1] = value;
                Notify(Plus2);
            }
        }
        public EnchIterationState Plus3
        {
            get { return EnchLvls[2]; }

            set
            {
                EnchLvls[2] = value;
                Notify(Plus3);
            }
        }
        public EnchIterationState Plus4
        {
            get { return EnchLvls[3]; }

            set
            {
                EnchLvls[3] = value;
                Notify(Plus4);
            }
        }
        public EnchIterationState Plus5
        {
            get { return EnchLvls[4]; }

            set
            {
                EnchLvls[4] = value;
                Notify(Plus5);
            }
        }
        public EnchIterationState Plus6
        {
            get { return EnchLvls[5]; }

            set
            {
                EnchLvls[5] = value;
                Notify(Plus6);
            }
        }
        public EnchIterationState Plus7
        {
            get { return EnchLvls[6]; }

            set
            {
                EnchLvls[6] = value;
                Notify(Plus7);
            }
        }
        public EnchIterationState Plus8
        {
            get { return EnchLvls[7]; }

            set
            {
                EnchLvls[7] = value;
                Notify(Plus8);
            }
        }
        public EnchIterationState Plus9
        {
            get { return EnchLvls[8]; }

            set
            {
                EnchLvls[8] = value;
                Notify(Plus9);
            }
        }
        public EnchIterationState Plus10
        {
            get { return EnchLvls[9]; }

            set
            {
                EnchLvls[9] = value;
                Notify(Plus10);
            }
        } 
        #endregion

        public readonly List<EnchIterationState> EnchLvls = new List<EnchIterationState>();

        public EnchPropertyData(List<EnchIterationStateBase> enchLvls, List<double> chances)
        {
            SetEnchLvlData(enchLvls, chances);
        }
        public void Update(List<EnchIterationStateBase> newEnchLvls, List<double> newChances)
        {
            SetEnchLvlData(newEnchLvls, newChances);
            EnchLvls.ForEach(Notify);
        }

        private void SetEnchLvlData(List<EnchIterationStateBase> newEnchLvls, List<double> newChances)
        {
            EnchLvls.Clear();
            for (var i = 0; i < newEnchLvls.Count; i++)
            {
                EnchLvls.Add(
                    new EnchIterationState(
                        DefaultEnchData.DefaultLvlNames[i],
                        newChances[i],
                        newEnchLvls[i].EcnhPremPiece,
                        newEnchLvls[i].EcnhAshkPiece,
                        newEnchLvls[i].StoneType,
                        newEnchLvls[i].RuneIsUsed
                    ));
            }
        }

        private void Notify(EnchIterationState ench)
        {
            NotifyPropertyChanged(ench.Name);
        }
    }
}