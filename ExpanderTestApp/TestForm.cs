using System.Windows.Forms;

namespace ExpanderTestApp
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void btUpperRefresh_Click(object sender, System.EventArgs e)
        {
            pgUpper.Refresh();
        }

        private void btLowerRefresh_Click(object sender, System.EventArgs e)
        {
            pgLower.Refresh();
        }
    }
}
