using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WindowsFormsExpander.Properties;

#nullable enable

namespace WindowsFormsExpander
{
    partial class Expander : Control
    {
        Rectangle borderRect, headerRect, imageRect, displayRect;
        ButtonState ButtonState => Enabled
                                       ? collapseButtonPressed
                                             ? ButtonState.Pushed
                                             : ButtonState.Normal
                                       : ButtonState.Inactive;
        PushButtonState PushButtonState => Enabled
                                               ? collapseButtonPressed
                                                     ? PushButtonState.Pressed
                                                     : collapseButtonHovered
                                                         ? PushButtonState.Hot
                                                         : PushButtonState.Normal
                                               : PushButtonState.Disabled;

        void RefreshRectangles()
        {
            borderRect =  new(Padding.Left, Padding.Top + HeaderHeight, Width - Padding.Horizontal, ExpandedHeight - Padding.Vertical - HeaderHeight);
            headerRect = new(Padding.Left, Padding.Top, Width - Padding.Horizontal, HeaderHeight);

            const int imageMargin = 8;
            const int proposedSize = 16;// Math.Min(16, Math.Max(0, headerRect.Height - 2 * imageMargin));
            imageRect = new(
                Math.Max(0, Width - Padding.Right - imageMargin - proposedSize),
                Padding.Top + Math.Max(0, headerRect.Height - proposedSize) / 2,
                proposedSize, proposedSize);
            displayRect = new(
                Padding.Left + 2,
                Padding.Top + HeaderHeight + 2,
                Math.Max(0, Width - Padding.Horizontal - 4),
                Math.Max(0, Height - Padding.Vertical - HeaderHeight - 4));
        }
        void DrawHeader(PaintEventArgs e)
        {
            if (!e.ClipRectangle.IntersectsWith(headerRect)) return;

            if (Application.RenderWithVisualStyles)
                DrawButtonWithVisualStyles(e);
            else
                DrawButtonWithoutVisualStyles(e);
        }
        void DrawButtonWithVisualStyles(PaintEventArgs e)
        {
            var textFormatFlags =
                TextFormatFlags.Default |
                TextFormatFlags.PreserveGraphicsClipping |
                TextFormatFlags.PreserveGraphicsTranslateTransform |
                TextFormatFlags.TextBoxControl |
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.WordBreak;

            if (RightToLeft == RightToLeft.Yes)
                textFormatFlags |= TextFormatFlags.Right | TextFormatFlags.RightToLeft;

            ButtonRenderer.DrawButton(
                e.Graphics,
                headerRect,
                Text,
                Font,
                textFormatFlags,
                Expanded ? Resources.collapseImage : Resources.expandImage,
                imageRect,
                Focused,
                PushButtonState);
        }
        void DrawButtonWithoutVisualStyles(PaintEventArgs e)
        {
            ControlPaint.DrawButton(e.Graphics, headerRect, ButtonState);
            

            //using var format = new StringFormat
            //{
            //    HotkeyPrefix = ShowKeyboardCues ? HotkeyPrefix.Show : HotkeyPrefix.Hide
            //};
            //if (RightToLeft == RightToLeft.Yes)
            //    format.FormatFlags |= StringFormatFlags.DirectionRightToLeft;

            //if (Enabled)
            //{
            //    using var textBrush = new SolidBrush(ForeColor);
            //    e.Graphics.DrawString(Text, Font, textBrush, TextRect);
            //}
            //else
            //    ControlPaint.DrawStringDisabled(e.Graphics, Text, Font, BackColor, TextRect, format);

            //if (Focused)
            //    ControlPaint.DrawFocusRectangle(e.Graphics, FocusRect);
        }
        void DrawContent(PaintEventArgs e)
        {
            if (Expanded && e.ClipRectangle.IntersectsWith(borderRect))
                //ControlPaint.DrawBorder3D(e.Graphics, borderRect, Border3DStyle.Flat);
                ControlPaint.DrawBorder(e.Graphics, borderRect, SystemColors.ActiveBorder, ButtonBorderStyle.Solid);
        }
    }
}
