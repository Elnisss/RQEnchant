using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using RQEnchant.CommonData;
using RQEnchant.Core;
using RQEnchant.PropertyData;

namespace RQEnchant
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        private readonly EnchPropertyData _selectEnchProperyData = new EnchPropertyData(
            DefaultEnchData.EnchAArmorValue,
            GameStaticParam.AArmorChances);

        private readonly string _defautPropertyFileName;

        private StonePrices _stonePrices = DefaultEnchData.DefaultStonePrices;
        private readonly CurrentEcnhLvls _currentEcnhLvls = new CurrentEcnhLvls();
        private readonly EquipProperties _equipPropeties = new EquipProperties(GameStaticParam.ItemTypes[0], GameStaticParam.Grades[0]);

        private readonly Dictionary<string, Tuple<List<EnchIterationStateBase>, List<double>>> _baseEnchPropeties
            = new Dictionary<string, Tuple<List<EnchIterationStateBase>, List<double>>>();

        public MainWindow()
        {
            InitializeComponent();
            SetStartParameters();
            try
            {
                _defautPropertyFileName = ConfigurationManager.AppSettings["DefaultEnchPropertiesFileName"];
                SetUserEnchProperties($"{Directory.GetCurrentDirectory()}/{_defautPropertyFileName}");
            }
            catch (Exception e)
            {
                SetDefaulEnchProperties();
                MessageBox.Show(
                    $"Выгрузить шаблон по-умолчанию не удалось! Будут использованы встроенные шаблоны. \n\n {e}",
                    "Ошибка!");
            }
        }

        private void SetUserEnchProperties(string filePath)
        {
            SaveLoadData userData;
            using (var stream = new StreamReader(filePath))
            {
                var streamRequest = stream.ReadToEnd();

                if (streamRequest.Length <= 0) return;

                userData = JsonPacker.FromJson<SaveLoadData>(streamRequest);
            }

            SetEquipEnchProperty(userData, GameNames.GradeA + GameNames.Armor, DefaultEnchData.EnchAArmorValue, GameStaticParam.AArmorChances);
            SetEquipEnchProperty(userData, GameNames.GradeB + GameNames.Armor, DefaultEnchData.EnchBArmorValue, GameStaticParam.BArmorChances);
            SetEquipEnchProperty(userData, GameNames.GradeC + GameNames.Armor, DefaultEnchData.EnchCArmorValue, GameStaticParam.CArmorChances);
            SetEquipEnchProperty(userData, GameNames.GradeA + GameNames.OneHnd, DefaultEnchData.EnchAWeapon1HValue, GameStaticParam.AWeapon1HChances);
            SetEquipEnchProperty(userData, GameNames.GradeB + GameNames.OneHnd, DefaultEnchData.EnchBWeapon1HValue, GameStaticParam.BWeapon1HChances);
            SetEquipEnchProperty(userData, GameNames.GradeC + GameNames.OneHnd, DefaultEnchData.EnchCWeapon1HValue, GameStaticParam.CWeapon1HChances);
            SetEquipEnchProperty(userData, GameNames.GradeA + GameNames.TwoHnd, DefaultEnchData.EnchAWeapon2HValue, GameStaticParam.AWeapon2HChances);
            SetEquipEnchProperty(userData, GameNames.GradeB + GameNames.TwoHnd, DefaultEnchData.EnchBWeapon2HValue, GameStaticParam.BWeapon2HChances);
            SetEquipEnchProperty(userData, GameNames.GradeC + GameNames.TwoHnd, DefaultEnchData.EnchCWeapon2HValue, GameStaticParam.CWeapon2HChances);

            _stonePrices = userData.StonePrices;
            ResourcesCost.DataContext = _stonePrices;

            _currentEcnhLvls.StartLvlText = DefaultEnchData.DefaultEcnhLvl.Contains(userData.StartEnchLvl) ? userData.StartEnchLvl : 0;
            _currentEcnhLvls.EndLvlText = DefaultEnchData.DefaultEcnhLvl.Contains(userData.EndEnchLvl) ? userData.EndEnchLvl : 1;
            _equipPropeties.Grade = GameStaticParam.Grades.Contains(userData.Grade) ? userData.Grade : GameNames.GradeA ;
            _equipPropeties.ItemType = GameStaticParam.ItemTypes.Contains(userData.ItemType) ? userData.ItemType : GameNames.Armor;

            SetNewEcnhPropetyData(_equipPropeties.Grade, _equipPropeties.ItemType);
        }

        private void SetDefaulEnchProperties()
        {
            SetEquipEnchProperty(GameNames.GradeA + GameNames.Armor, DefaultEnchData.EnchAArmorValue, GameStaticParam.AArmorChances);
            SetEquipEnchProperty(GameNames.GradeB + GameNames.Armor, DefaultEnchData.EnchBArmorValue, GameStaticParam.BArmorChances);
            SetEquipEnchProperty(GameNames.GradeC + GameNames.Armor, DefaultEnchData.EnchCArmorValue, GameStaticParam.CArmorChances);
            SetEquipEnchProperty(GameNames.GradeA + GameNames.OneHnd, DefaultEnchData.EnchAWeapon1HValue, GameStaticParam.AWeapon1HChances);
            SetEquipEnchProperty(GameNames.GradeB + GameNames.OneHnd, DefaultEnchData.EnchBWeapon1HValue, GameStaticParam.BWeapon1HChances);
            SetEquipEnchProperty(GameNames.GradeC + GameNames.OneHnd, DefaultEnchData.EnchCWeapon1HValue, GameStaticParam.CWeapon1HChances);
            SetEquipEnchProperty(GameNames.GradeA + GameNames.TwoHnd, DefaultEnchData.EnchAWeapon2HValue, GameStaticParam.AWeapon2HChances);
            SetEquipEnchProperty(GameNames.GradeB + GameNames.TwoHnd, DefaultEnchData.EnchBWeapon2HValue, GameStaticParam.BWeapon2HChances);
            SetEquipEnchProperty(GameNames.GradeC + GameNames.TwoHnd, DefaultEnchData.EnchCWeapon2HValue, GameStaticParam.CWeapon2HChances);
        }

        private void SetEquipEnchProperty(SaveLoadData userData, string equipType,
            List<EnchIterationStateBase> defaultEnchStates, List<double> chances)
        {
            var equipStates = GetEquipIterationStates(userData, equipType, defaultEnchStates);
            SetEquipEnchProperty(equipType, equipStates, chances);
        }

        private List<EnchIterationStateBase> GetEquipIterationStates(SaveLoadData userData, string equipType,
            List<EnchIterationStateBase> defaultData)
        {
            return userData.EnchLvlData.ContainsKey(equipType)
                ? userData.EnchLvlData[equipType]
                : defaultData;
        }

        private void SetEquipEnchProperty(string equipType, List<EnchIterationStateBase> enchStates,
            List<double> chances)
        {
            _baseEnchPropeties[equipType]
                = new Tuple<List<EnchIterationStateBase>, List<double>>(enchStates, chances);
        }

        private void SetStartParameters()
        {
            var cbs = EnchPropetyData.Children.OfType<ComboBox>();

            foreach (var cb in cbs)
            {
                cb.ItemsSource = GameStaticParam.EnchStoneNames;
            }

            CurrentEcnhLvls.DataContext = _currentEcnhLvls;
            EnchPropetyData.DataContext = _selectEnchProperyData;
            ResourcesCost.DataContext = _stonePrices;
            EquipPropeties.DataContext = _equipPropeties;
        }

        private void SaveEnchProperties(object sender, RoutedEventArgs e)
        {
            SaveSelectedEnchProperty();

            var enchLvlData = _baseEnchPropeties.ToDictionary(ench => ench.Key, ench => ench.Value.Item1);

            var saveData = new SaveLoadData(
                enchLvlData, _stonePrices, _equipPropeties.Grade, _equipPropeties.ItemType,
                _currentEcnhLvls.StartLvlText, _currentEcnhLvls.EndLvlText);

            var saveFileDialog = new SaveFileDialog
            {
                FileName = _defautPropertyFileName,
                Filter = "Json format (*.json)|*.json",
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            if (saveFileDialog.ShowDialog() != true) return;

            try
            {
                var saveDataJson = JsonPacker.ToJson(saveData);

                using (var outfile = new StreamWriter(saveFileDialog.FileName))
                {
                    outfile.Write(saveDataJson);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сохранить шаблон не удалось!\n{ex}", "Ошибка");
            }
        }

        private void LoadEnchProperties(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Json format (*.json)|*.json",
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            if (openFileDialog.ShowDialog() != true) return;

            try
            {
                SetUserEnchProperties(openFileDialog.FileName);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Выгрузить шаблон не удалось! Будут использованы встроенные шаблоны. \n\n {ex}", "Ошибка!");
                SetDefaulEnchProperties();
            }
        }

        private void RunCalculation_Click(object sender, RoutedEventArgs e)
        {
            var result = new EnchCalcResult(_selectEnchProperyData, _stonePrices);
            result.Calculate(_currentEcnhLvls.StartLvlText, _currentEcnhLvls.EndLvlText);
            CalculationResultData.DataContext = result;
        }

        private void OnlyIntValueChecker(object sender, TextCompositionEventArgs e)
        {
            var tb = (TextBox) sender;
            if (tb.Text.Length > 7)
            {
                e.Handled = true;
            }
            else
            {
                var regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
        }

        private void ItemGradeChanged(object sender, SelectionChangedEventArgs e)
        {
            var grade = (ComboBox) sender;
            SetNewEcnhPropetyData((string)grade.SelectedItem, _equipPropeties.ItemType);
        }

        private void ItemTypeChanged(object sender, SelectionChangedEventArgs e)
        {
            var type = (ComboBox)sender;
            SetNewEcnhPropetyData(_equipPropeties.Grade, (string)type.SelectedItem);
        }

        private void SaveSelectedEnchProperty()
        {
            _baseEnchPropeties[_equipPropeties.Grade + _equipPropeties.ItemType] =
                new Tuple<List<EnchIterationStateBase>, List<double>>(
                    _selectEnchProperyData.EnchLvls.Select(
                            e => new EnchIterationStateBase(e._ecnhPremPiece, e._ecnhAshkPiece, e.StoneType, e.RuneIsUsed))
                        .ToList(),
                    _baseEnchPropeties[_equipPropeties.Grade + _equipPropeties.ItemType].Item2);

        }

        private void SetNewEcnhPropetyData(string grade, string type)
        {
            var newEnchLvl = _baseEnchPropeties[grade + type].Item1;
            var newChances = _baseEnchPropeties[grade + type].Item2;

            _selectEnchProperyData.Update(newEnchLvl, newChances);
        }
        
        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            SaveSelectedEnchProperty();
        }
    }
}
