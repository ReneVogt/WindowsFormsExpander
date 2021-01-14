using System;
using System.Drawing;
using System.Windows.Forms;

#nullable enable

namespace WindowsFormsExpander
{
    partial class Expander : Control
    {
        /// <inheritdoc />
        // ReSharper disable once ConvertToAutoProperty
        public override Rectangle DisplayRectangle => displayRect;
        /// <inheritdoc />
        protected override bool ShowFocusCues => true;
        /// <inheritdoc />
        protected override bool ShowKeyboardCues => true;

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
            Invalidate();
            base.OnGotFocus(e);
        }
        /// <inheritdoc />
        protected override void OnLostFocus(EventArgs e)
        {
            Invalidate();
            base.OnLostFocus(e);
        }
        /// <inheritdoc />
        protected override void OnFontChanged(EventArgs e)
        {
            Invalidate();
            base.OnFontChanged(e);
        }
        /// <inheritdoc />
        protected override void OnRightToLeftChanged(EventArgs e)
        {
            Invalidate();
            base.OnRightToLeftChanged(e);
        }
    }
}
