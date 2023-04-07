using TreesAccounting.Core;
using TreesAccounting.ViewModel;
using Windows.UI.Xaml.Controls;

namespace TreesAccounting
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            Loaded += (x, y) =>
            {
                MainPageDataPresenter mainPageDataPresenter = new MainPageDataPresenter();

                TreeDataHandler treeDataHandler = TreeDataHandler.Initialize();

                mainPageDataPresenter.RestoreData();
                MainList.ItemsSource = mainPageDataPresenter.GetFullView();
            };
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MainPage.Instance.Frame.Content = new AccountingElementViewEdit();
        }
    }
}
