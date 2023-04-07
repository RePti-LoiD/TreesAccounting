using System.Collections.Generic;
using TreesAccounting.Core;
using TreesAccounting.PresentationData;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace TreesAccounting
{
    public sealed partial class AccountingElementView : Page
    {
        public string forestName;
        public string forestPlace;
        private ForestType forestType;
        public UserControl forestDescription;
        public string coords;
        public string forestSquare;
        public string avgHeight;

        public List<TreesDisease> forestDisease = new List<TreesDisease>();
        public List<Elements.TreeType> treeTypes = new List<Elements.TreeType>();

        private string ForestType
        {
            get => forestType.ToString();
        }

        public AccountingElementView()
        {
            InitializeComponent();

            Loaded += (x, y) =>
            {
                foreach (TreesDisease item in forestDisease)
                    DiseaseStackPanel.Children.Add(item);

                foreach (Elements.TreeType item in treeTypes)
                    TypesList.Children.Add(item);
            };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ConnectedAnimation anim = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");
            if (anim != null)
            {
                anim.TryStart(MainGridCard);
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("ForwardConnectedAnimation", MainGridCard);
        }

        private void ReturnToMain(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MainPage.Instance.Frame.Content = new HomePage();
        }
    }
}