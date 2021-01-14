using System;
using System.Drawing;
using System.Windows.Forms;

#nullable enable

namespace WindowsFormsExpander
{
    partial class Expander : Control
    {
        /// <inheritdoc />
        public override Rectangle DisplayRectangle => displayRect;

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
        protected override void OnMouseLeave(EventArgs e)
        {
            if (collapseButtonHovered)
            {
                collapseButtonHovered = false;
                Invalidate(headerRect);
            }
            base.OnMouseLeave(e);
        }
        /// <inheritdoc />
        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            if (e.Button == MouseButtons.Left && headerRect.Contains(e.Location) && !collapseButtonPressed)
            {
                collapseButtonPressed = true;
                Invalidate(headerRect);
            }
            base.OnMouseDown(e);
        }
        /// <inheritdoc />
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (headerRect.Contains(e.Location))
            {
                if (!collapseButtonHovered)
                {
                    collapseButtonHovered = true;
                    Invalidate(headerRect);
                }
            }
            else
            {
                if (collapseButtonHovered)
                {
                    collapseButtonHovered = false;
                    Invalidate(headerRect);

                }

                if (collapseButtonPressed)
                {
                    collapseButtonPressed = false;
                    Invalidate(headerRect);
                }
            }

            base.OnMouseMove(e);
        }
        /// <inheritdoc />
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (collapseButtonPressed && e.Button == MouseButtons.Left)
            {
                collapseButtonPressed = false;
                Invalidate(headerRect);
            }
            base.OnMouseUp(e);
        }
        /// <inheritdoc />
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (headerRect.Contains(e.Location) && e.Button == MouseButtons.Left)
            {
                Expanded = !Expanded;
                if (e is HandledMouseEventArgs he)
                    he.Handled = true;
            }

            base.OnMouseClick(e);
        }
        /// <inheritdoc />
        protected override void OnFontChanged(EventArgs e)
        {
            Invalidate();
            base.OnFontChanged(e);
        }
    }
}
