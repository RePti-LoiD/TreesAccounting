using System;
using System.Collections.Generic;
using TreesAccounting.Core;
using TreesAccounting.Core.DataSave;
using TreesAccounting.View.Elements.Editable;
using Windows.UI.Xaml.Controls;

namespace TreesAccounting
{
    public sealed partial class AccountingElementViewEdit : Page
    {
        private ForestData forestData = new ForestData();

        private List<TreesDiseaseEditable> treesDiseaseEditables = new List<TreesDiseaseEditable>();
        private List<TreeTypeEditable> treeTypeEditables = new List<TreeTypeEditable>();

        public AccountingElementViewEdit()
        {
            InitializeComponent();

            Loaded += (x, y) =>
            {
                List<string> vals = new List<string>();
            };
        }

        private void AddDisease(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            TreesDiseaseEditable diseaseEditable = new TreesDiseaseEditable();

            treesDiseaseEditables.Add(diseaseEditable);
            DiseaseStackPanel.Children.Add(diseaseEditable);
        }

        private void AddType(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            TreeTypeEditable treeTypeEditable = new TreeTypeEditable();

            treeTypeEditables.Add(treeTypeEditable);
            TypesList.Children.Add(treeTypeEditable);
        }

        private void ReturnToMain(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MainPage.Instance.Frame.Content = new HomePage();
        }

        private void ComboBoxForestType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ForestType selectedForestType = (ForestType) Enum.Parse(typeof(ForestType), (sender as ComboBox).SelectedItem.ToString());
            forestData.ForestType = selectedForestType;
            TextForestType.Key = selectedForestType.ToString();

            DescriptionField.Content = GetDescription(selectedForestType);
        }

        private void Tag_OnKeyChanged(PresentationData.Tag tag)
        {
            forestData.Coords = tag.TextB.Text;
        }

        private void Tag_OnKeyChanged_1(PresentationData.Tag tag)
        {
            forestData.ForestSquare = tag.TextB.Text;
        }

        private void Tag_OnKeyChanged_2(PresentationData.Tag tag)
        {
            forestData.AvgHeight = tag.TextB.Text;
        }



        private UserControl GetDescription(ForestType forestType)
        {
            switch (forestType)
            {
                case ForestType.Защитный:
                    return new ProtectForest();

                case ForestType.Эксплуатационный:
                    
                    return new ExecutableForest();

                case ForestType.Резервный:
                    return new ReserveForests();

                default:
                    return null;
            }
        }



        private void SaveData(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {


            foreach (TreesDiseaseEditable item in treesDiseaseEditables)
                forestData.ForestDisease.Add(new ForestDisease() { DiseaseName = item.editable.DiseaseName, Percents = item.editable.Percent, TreeType = item.editable.TargetType });

            foreach (var item in treeTypeEditables)
                forestData.TreeTypes.Add(new TreeType() { TypeName = item.treeType.TypeName, DensityPercent = item.treeType.DensityPercent, QuantityPercent = item.treeType.QuantityPercent });

            TreeDataHandler treeDataHandler = TreeDataHandler.Initialize();
            treeDataHandler.ForestData.Add(forestData);

            SaveHandler.SaveAllData();

            ReturnToMain(null, null);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            forestData.ForestPlace = (sender as TextBox).Text;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            forestData.ForestName = (sender as TextBox).Text;
        }
    }
}