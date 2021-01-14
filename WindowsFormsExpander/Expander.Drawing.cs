using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;
using System.Windows.Forms.VisualStyles;
using WindowsFormsExpander.Properties;

#nullable enable

namespace WindowsFormsExpander
{
    partial class Expander : Control
    {
        const int headerPadding = 4;
        const int focusPadding = 2;
        const int imageSize = 16;

        Rectangle borderRect, headerRect, imageRect, displayRect, textRect, focusRect;
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
            borderRect =  new(Padding.Left, Padding.Top + HeaderHeight, Width - Padding.Horizontal, ExpandedHeight - Padding.Vertical - HeaderHeight);
            headerRect = new(Padding.Left, Padding.Top, Width - Padding.Horizontal, HeaderHeight);

            imageRect = new(
                Math.Max(0, Width - Padding.Right - headerPadding - imageSize),
                Padding.Top + Math.Max(0, headerRect.Height - imageSize) / 2,
                imageSize, imageSize);

            textRect = new(headerRect.Left + headerPadding, headerRect.Top + headerPadding, headerRect.Width - 2 * headerPadding,
                           headerRect.Height - 2 * headerPadding);
            if (IsHandleCreated)
            {
                using var graphics = Graphics.FromHwnd(Handle);
                using var format = GetStringFormat();

                var textSize = Size.Ceiling(graphics.MeasureString(Text, Font, textRect.Size, format));

                textRect = new (
                    textRect.Left,
                    textRect.Top + (textRect.Height - textSize.Height) / 2,
                    textSize.Width, textSize.Height);

            }

            focusRect = new(headerRect.Left + focusPadding, headerRect.Top + focusPadding, headerRect.Width - 2 * focusPadding,
                            headerRect.Height - 2 * focusPadding);

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
                ButtonImage,
                imageRect,
                Focused && ShowFocusCues,
                PushButtonState);
        }
        void DrawButtonWithoutVisualStyles(PaintEventArgs e)
        {
            ControlPaint.DrawButton(e.Graphics, headerRect, ButtonState);

            if (Enabled)
            {
                using var textBrush = new SolidBrush(ForeColor);
                e.Graphics.DrawString(Text, Font, textBrush, textRect);
                e.Graphics.DrawImageUnscaledAndClipped(ButtonImage, imageRect);
            }
            else
            {
                using var format = GetStringFormat();
                ControlPaint.DrawStringDisabled(e.Graphics, Text, Font, BackColor, textRect, format);
                ControlPaint.DrawImageDisabled(e.Graphics, ButtonImage, imageRect.Left, imageRect.Top, BackColor);
            }

            if (Focused && ShowFocusCues)
                ControlPaint.DrawFocusRectangle(e.Graphics, focusRect);
        }
        void DrawContent(PaintEventArgs e)
        {
            if (Expanded && e.ClipRectangle.IntersectsWith(borderRect))
                ControlPaint.DrawBorder(e.Graphics, borderRect, SystemColors.ActiveBorder, ButtonBorderStyle.Solid);
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
        internal List<SnapLine> SnapLines => new()
        {
            new (SnapLineType.Left, 0, SnapLinePriority.High),
            new(SnapLineType.Top, 0, SnapLinePriority.High),
            new(SnapLineType.Right, Width, SnapLinePriority.High),
            new(SnapLineType.Bottom, Height, SnapLinePriority.High),

            new(SnapLineType.Baseline, textRect.Bottom, SnapLinePriority.High),

            new (SnapLineType.Top, headerRect.Height, SnapLinePriority.High)
        };
    }
}
