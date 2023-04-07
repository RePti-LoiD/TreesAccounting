using TreesAccounting.PresentationData;
using Windows.UI.Xaml.Controls;

namespace TreesAccounting.View.Elements.Editable
{
    public sealed partial class TreesDiseaseEditable : UserControl
    {
        public TreesDisease editable = new TreesDisease();

        public TreesDiseaseEditable()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string message = (sender as TextBox).Text;

            editable.DiseaseName = message;
            DiseaseText.Text = message;
        }

        private void Tag_OnKeyChanged(Tag tag)
        {
            editable.TargetType = tag.TextB.Text;
        }

        private void Tag_OnKeyChanged_1(Tag tag)
        {
            editable.Percent = tag.TextB.Text;
        }

        public TreesDisease GetTreesDisease() => editable;
    }
}
