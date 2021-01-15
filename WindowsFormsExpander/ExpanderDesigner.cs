using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WindowsFormsExpander
{
    /// <summary>
    /// Provides design time support for the <see cref="WindowsFormsExpander.Expander"/> control.
    /// </summary>
    sealed class ExpanderDesigner : ParentControlDesigner
    {
        Expander Expander => (Expander)Control;

        /// <inheritdoc />
        protected override Point DefaultControlLocation => Expander.DisplayRectangle.Location;

        /// <inheritdoc />
        public override IList SnapLines => Expander.SnapLines;

        /// <inheritdoc />
        protected override void OnPaintAdornments(PaintEventArgs e)
        {
            if (!DrawGrid) return;
            var displayRect = Expander.DisplayRectangle;
            displayRect.Width++;
            displayRect.Height++;
            ControlPaint.DrawGrid(e.Graphics, displayRect, GridSize, Expander.BackColor);
        }
    }
}
