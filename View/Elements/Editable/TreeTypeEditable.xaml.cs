using TreesAccounting.Core;
using Windows.UI.Xaml.Controls;

namespace TreesAccounting.View.Elements.Editable
{
    public sealed partial class TreeTypeEditable : UserControl
    {
        public TreeType treeType = new TreeType();

        public TreeTypeEditable()
        {
            InitializeComponent();
        }

        private void Tag_OnKeyChanged(PresentationData.Tag tag)
        {
            treeType.QuantityPercent = tag.TextB.Text;
        }

        private void Tag_OnKeyChanged_1(PresentationData.Tag tag)
        {
            treeType.DensityPercent = tag.TextB.Text;
        }

        private void TypeChanged(object sender, TextChangedEventArgs e)
        {
            treeType.TypeName = (sender as TextBox).Text;
        }

        public TreeType GetTreeType() => treeType;
    }
}
