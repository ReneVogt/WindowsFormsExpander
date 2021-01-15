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
                Invalidate(headerRect);
            }
        }
        bool CollapseButtonHovered
        {
            get => collapseButtonHovered;
            set
            {
                if (collapseButtonHovered == value) return;
                collapseButtonHovered = value;
                Invalidate(headerRect);
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
            if (e.Button == MouseButtons.Left && headerRect.Contains(e.Location) && !CollapseButtonPressed)
            {
                CollapseButtonPressed = true;
                Invalidate(headerRect);
            }

            base.OnMouseDown(e);
        }
        /// <inheritdoc />
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (headerRect.Contains(e.Location))
                CollapseButtonHovered = true;
            else
                CollapseButtonHovered = CollapseButtonPressed = false;

            base.OnMouseMove(e);
        }
        /// <inheritdoc />
        protected override void OnMouseUp(MouseEventArgs e)
        {
            CollapseButtonPressed = false;
            Invalidate(headerRect);
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
    }
}