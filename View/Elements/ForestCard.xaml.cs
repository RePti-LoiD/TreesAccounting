using Windows.UI.Xaml.Controls;

namespace TreesAccounting.Elements
{
    public sealed partial class ForestCard : UserControl
    {
        private AccountingElementView accountingElement;

        public AccountingElementView AccountingElement
        {
            get => accountingElement;
            set => accountingElement = value;
        }

        public ForestCard()
        {
            InitializeComponent();
        }

        private void Grid_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            MainPage.Instance.Frame.Content = accountingElement;
        }
    }
}