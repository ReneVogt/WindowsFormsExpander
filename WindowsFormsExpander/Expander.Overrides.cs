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
            base.OnSizeChanged(e);
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
            Invalidate(headerRect);
            base.OnLostFocus(e);
        }
        /// <inheritdoc />
        protected override void SetClientSizeCore(int x, int y)
        {
            base.SetClientSizeCore(x, Math.Max(HeaderHeight + Padding.Vertical, y));
        }
    }
}
