using System.Windows.Forms;

#nullable enable

namespace WindowsFormsExpander
{
    partial class Expander : Control
    {
        /// <inheritdoc />
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None)
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                    case Keys.Return:
                        Expanded = !Expanded;
                        e.Handled = true;
                        break;
                    case Keys.Subtract:
                    case Keys.OemMinus:
                        Expanded = false;
                        e.Handled = true;
                        break;
                    case Keys.Add:
                    case Keys.Oemplus:
                        Expanded = true;
                        e.Handled = true;
                        break;
                }
            }
            base.OnKeyDown(e);
        }
    }
}