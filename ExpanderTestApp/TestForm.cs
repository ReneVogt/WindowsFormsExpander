using System.Windows.Forms;

namespace ExpanderTestApp
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            propertyGrid.SelectedObject = expander;
        }
    }
}
