using System;
using System.Drawing;
using System.Windows.Forms;

#nullable enable

namespace WindowsFormsExpander
{
    partial class Expander : Control
    {
        /// <inheritdoc />
        public override Rectangle DisplayRectangle => Expanded ? new(borderRect.Location, borderRect.Size) : Rectangle.Empty;
        /// <inheritdoc />
        protected override bool ShowFocusCues => true;
        /// <inheritdoc />
        protected override bool ShowKeyboardCues => true;
        /// <inheritdoc />
        protected override Padding DefaultPadding => new (3);
        /// <inheritdoc />
        protected override Size DefaultSize => new (200, defaultExpandedHeight);

        /// <inheritdoc />
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawContent(e);
            DrawHeader(e);
            base.OnPaint(e);
        }
        /// <inheritdoc />
        protected override void OnSizeChanged(EventArgs e)
        {
            RefreshRectangles();
            if (Expanded)
                ExpandedHeight = Height;
            ClientSize = Size;
            base.OnSizeChanged(e);
        }
        /// <inheritdoc />
        protected override void OnEnter(EventArgs e)
        {
            // This prevents child controls form gaining
            // focus via tab etc while we are collapsed.
            if (!Expanded) Focus();

            base.OnEnter(e);
        }
        /// <inheritdoc />
        protected override void OnGotFocus(EventArgs e)
        {
            Invalidate(headerRect);
            base.OnGotFocus(e);
        }
        /// <inheritdoc />
        protected override void OnLostFocus(EventArgs e)
        {
            // Don't let child controls take focus
            // while we're collapsed.
            if (!Expanded && ContainsFocus)
                Parent?.SelectNextControl(this, true, true, false, true);

            Invalidate(headerRect);
            base.OnLostFocus(e);
        }
    }
}
