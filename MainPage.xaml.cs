using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace TreesAccounting
{
    public sealed partial class MainPage : Page
    {
        public static MainPage Instance { get; private set; }

        public MainPage()
        {
            InitializeComponent();

            Loaded += (x, y) =>
            {
                Instance = this;
                MainFrame.Content = new HomePage();
            };
        }

        internal void NavigateFrame(Type v, object value)
        {
            MainFrame.Navigate(v, value, new DrillInNavigationTransitionInfo());
        }
    }
}