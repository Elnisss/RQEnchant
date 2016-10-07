using System.Collections.Generic;
using RQEnchant.CommonData;
using RQEnchant.Core;

namespace RQEnchant.PropertyData
{
    public class EquipProperties: NotifyPropertyChangedBase
    {
        public string ItemType {
            get { return _equipType; }

            set
            {
                _equipType = value;
                NotifyPropertyChanged("ItemType");
            }
        }
        public string Grade {
            get { return _equipGrade; }
            set
            {
                _equipGrade = value;
                NotifyPropertyChanged("EquipGrade");
            }
        }

        public List<string> EquipTypeVariants { get; set; } = GameStaticParam.ItemTypes;
        public List<string> EquipGradeVariants { get; set; } = GameStaticParam.Grades;

        private string _equipType;

        private string _equipGrade;

        public EquipProperties(string equipType, string equipGrade)
        {
            _equipType = equipType;
            _equipGrade = equipGrade;
        }

        public void Update(string equipType, string equipGrade)
        {
            _equipType = equipType;
            _equipGrade = equipGrade;
            NotifyPropertyChanged("EquipType");
            NotifyPropertyChanged("EquipGrade");
        }
    }
}