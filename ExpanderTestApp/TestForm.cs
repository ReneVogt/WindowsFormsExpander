using System.Diagnostics;
using System.Windows.Forms;

namespace ExpanderTestApp
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            propertyGrid.SelectedObject = expander;
            button1.GotFocus += (_, _) => Debug.WriteLine("BUTTON1 FOCUSED");
            button1.LostFocus += (_, _) => Debug.WriteLine("BUTTON1 LOST FOCUS");
            button2.GotFocus += (_, _) => Debug.WriteLine("BUTTON2 FOCUSED");
            button2.LostFocus += (_, _) => Debug.WriteLine("BUTTON2 LOST FOCUS");
        }
    }
}
