using System.Collections.Generic;
using TreesAccounting.Core;
using TreesAccounting.Core.DataSave;
using TreesAccounting.Elements;
using TreesAccounting.PresentationData;
using Windows.UI.Xaml.Controls;

namespace TreesAccounting.ViewModel
{
    public class MainPageDataPresenter
    {
        private List<ForestData> forestData = new List<ForestData>();

        public void RestoreData()
        {
            forestData.Clear();
            forestData = SaveHandler.RestoreData().ForestData;
        }

        public List<ForestCard> GetFullView()
        {
            List<ForestCard> cards = new List<ForestCard>();
            foreach (var item in forestData)
                cards.Add(new ForestCard() { AccountingElement = GetView(item)});

            return cards;
        }

        public AccountingElementView GetView(ForestData data)
        {
            AccountingElementView view = new AccountingElementView()
            {
                forestName = data.ForestName,
                forestDescription = GetDescription(data.ForestType),
                forestPlace = data.ForestPlace,
                forestSquare = data.ForestSquare,
                avgHeight = data.AvgHeight,
                coords = data.Coords,
            };

            foreach (Core.TreeType item in data.TreeTypes)
                view.treeTypes.Add(new Elements.TreeType() { treeType = item.TypeName, dencity = item.DensityPercent, percent = item.QuantityPercent });

            foreach (ForestDisease item in data.ForestDisease)
                view.forestDisease.Add(new TreesDisease() { DiseaseName = item.DiseaseName, TargetType = item.TreeType, Percent = item.Percents });

            return view;
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
    }
}