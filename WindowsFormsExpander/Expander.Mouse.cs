using System;
using System.Windows.Forms;

#nullable enable

namespace WindowsFormsExpander
{
    partial class Expander
    {
        bool collapseButtonPressed, collapseButtonHovered;
        bool CollapseButtonPressed
        {
            get => collapseButtonPressed;
            set
            {
                if (collapseButtonPressed == value) return;
                collapseButtonPressed = value;
                Invalidate(HeaderRect);
            }
        }
        bool CollapseButtonHovered
        {
            get => collapseButtonHovered;
            set
            {
                if (collapseButtonHovered == value) return;
                collapseButtonHovered = value;
                Invalidate(HeaderRect);
            }
        }

        /// <inheritdoc />
        protected override void OnMouseLeave(EventArgs e)
        {
            CollapseButtonHovered = false;
            base.OnMouseLeave(e);
        }
        /// <inheritdoc />
        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            if (e.Button == MouseButtons.Left && HeaderRect.Contains(e.Location) && !CollapseButtonPressed)
            {
                CollapseButtonPressed = true;
                Invalidate(HeaderRect);
            }

            base.OnMouseDown(e);
        }
        /// <inheritdoc />
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (HeaderRect.Contains(e.Location))
                CollapseButtonHovered = true;
            else
                CollapseButtonHovered = CollapseButtonPressed = false;

            base.OnMouseMove(e);
        }
        /// <inheritdoc />
        protected override void OnMouseUp(MouseEventArgs e)
        {
            CollapseButtonPressed = false;
            Invalidate(HeaderRect);
            base.OnMouseUp(e);
        }
        /// <inheritdoc />
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (HeaderRect.Contains(e.Location) && e.Button == MouseButtons.Left)
            {
                Expanded = !Expanded;
                if (e is HandledMouseEventArgs he)
                    he.Handled = true;
            }

            base.OnMouseClick(e);
        }
    }
}