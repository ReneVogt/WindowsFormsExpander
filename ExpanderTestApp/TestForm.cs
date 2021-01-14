using System;
using System.Windows.Forms;

namespace ExpanderTestApp
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            lowerExpander.GotFocus += OnExpanderFocused;
            upperExpander.GotFocus += OnExpanderFocused;
        }
        void OnExpanderFocused(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = sender;
        }
    }
}
