using Windows.UI.Xaml.Controls;

namespace TreesAccounting.PresentationData
{
    public sealed partial class TreesDisease : UserControl
    {
        private string diseaseName;
        private string targetType;
        private string percent;

        public TreesDisease()
        {
            InitializeComponent();
        }

        public string DiseaseName { get => diseaseName; set => diseaseName = value; }
        public string TargetType { get => targetType; set => targetType = value; }
        public string Percent { get => percent + "%"; set => percent = value; }
    }
}