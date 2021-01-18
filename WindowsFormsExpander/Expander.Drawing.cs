using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WindowsFormsExpander.Properties;

#nullable enable

namespace WindowsFormsExpander
{
    partial class Expander
    {
        Rectangle BorderRect { get; set; }
        Rectangle ImageRect { get; set; }
        Rectangle FocusRect { get; set; }
        Rectangle HeaderRect { get; set; }
        Rectangle TextRect { get; set; }
        ButtonState ButtonState => Enabled
                                       ? CollapseButtonPressed
                                             ? ButtonState.Pushed
                                             : ButtonState.Normal
                                       : ButtonState.Inactive;
        PushButtonState PushButtonState => Enabled
                                               ? CollapseButtonPressed
                                                     ? PushButtonState.Pressed
                                                     : CollapseButtonHovered
                                                         ? PushButtonState.Hot
                                                         : PushButtonState.Normal
                                               : PushButtonState.Disabled;
        Image ButtonImage => Expanded ? Resources.collapseImage : Resources.expandImage;
        
        void RefreshRectangles()
        {
            BorderRect = new(

                x: Padding.Left,
                y: Padding.Top + HeaderHeight,
                width: Math.Max(0, Width - Padding.Horizontal),
                height: Math.Max(0, ExpandedHeight - Padding.Vertical - HeaderHeight)
            );
            HeaderRect = new(
                x: Padding.Left,
                y: Padding.Top,
                width: Math.Max(0, Width - Padding.Horizontal),
                height: HeaderHeight);
            var paddedHeaderRect = new Rectangle(
                x: HeaderRect.Left + headerPadding,
                y: Padding.Top + headerPadding,
                width: HeaderRect.Width - 2 * headerPadding,
                height: HeaderRect.Height - 2 * headerPadding);
            ImageRect = new(
                x: Math.Max(paddedHeaderRect.Left, paddedHeaderRect.Right - imageSize),
                y: paddedHeaderRect.Top + Math.Max(0, paddedHeaderRect.Height - imageSize) / 2,
                width: Math.Min(imageSize, paddedHeaderRect.Width), 
                height: Math.Min(imageSize, paddedHeaderRect.Height));
            TextRect = new(
                x: paddedHeaderRect.Left,
                y: paddedHeaderRect.Top, 
                width: paddedHeaderRect.Width,
                height: paddedHeaderRect.Height);
            
            if (IsHandleCreated)
            {
                using var graphics = Graphics.FromHwnd(Handle);
                using var format = GetStringFormat();

                var textSize = Size.Ceiling(graphics.MeasureString(Text, Font, TextRect.Size, format));

                TextRect = new (
                    TextRect.Left,
                    Math.Min(HeaderRect.Bottom - headerPadding, TextRect.Top + Math.Max(0, TextRect.Height - textSize.Height) / 2),
                    Math.Min(HeaderRect.Width - 2 * headerPadding, textSize.Width),
                    Math.Min(HeaderRect.Height - 2 * headerPadding, textSize.Height));
            }

            FocusRect = new(
                x: HeaderRect.Left + focusPadding, 
                y: HeaderRect.Top + focusPadding, 
                width: Math.Max(0, HeaderRect.Width - 2 * focusPadding),
                height: Math.Max(0, HeaderRect.Height - 2 * focusPadding));
        }
        void DrawHeader(PaintEventArgs e)
        {
            if (!e.ClipRectangle.IntersectsWith(HeaderRect)) return;

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
                HeaderRect,
                Text,
                Font,
                textFormatFlags,
                ButtonImage,
                ImageRect,
                Focused && ShowFocusCues,
                PushButtonState);
        }
        void DrawButtonWithoutVisualStyles(PaintEventArgs e)
        {
            ControlPaint.DrawButton(e.Graphics, HeaderRect, ButtonState);

            if (Enabled)
            {
                using var textBrush = new SolidBrush(ForeColor);
                e.Graphics.DrawString(Text, Font, textBrush, TextRect);
                e.Graphics.DrawImageUnscaledAndClipped(ButtonImage, ImageRect);
            }
            else
            {
                using var format = GetStringFormat();
                ControlPaint.DrawStringDisabled(e.Graphics, Text, Font, BackColor, TextRect, format);
                ControlPaint.DrawImageDisabled(e.Graphics, ButtonImage, ImageRect.Left, ImageRect.Top, BackColor);
            }

            if (Focused && ShowFocusCues)
                ControlPaint.DrawFocusRectangle(e.Graphics, FocusRect);
        }
        void DrawContent(PaintEventArgs e)
        {
            if (Expanded && e.ClipRectangle.IntersectsWith(BorderRect))
                ControlPaint.DrawBorder(e.Graphics, BorderRect, SystemColors.ActiveBorder, ButtonBorderStyle.Solid);
        }
        StringFormat GetStringFormat()
        {
            var format = new StringFormat
            {
                HotkeyPrefix = ShowKeyboardCues ? HotkeyPrefix.Show : HotkeyPrefix.Hide
            };
            if (RightToLeft == RightToLeft.Yes)
                format.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
            
            return format;
        }
    }
}
