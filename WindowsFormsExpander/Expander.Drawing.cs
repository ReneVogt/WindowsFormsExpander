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
        Rectangle borderRect, headerRect, imageRect, textRect, focusRect;
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
            borderRect = new(

                x: Padding.Left,
                y: Padding.Top + HeaderHeight,
                width: Math.Max(0, Width - Padding.Horizontal),
                height: Math.Max(0, ExpandedHeight - Padding.Vertical - HeaderHeight)
            );
            headerRect = new(
                x: Padding.Left,
                y: Padding.Top,
                width: Math.Max(0, Width - Padding.Horizontal),
                height: HeaderHeight);
            var paddedHeaderRect = new Rectangle(
                x: headerRect.Left + headerPadding,
                y: Padding.Top + headerPadding,
                width: headerRect.Width - 2 * headerPadding,
                height: headerRect.Height - 2 * headerPadding);
            imageRect = new(
                x: Math.Max(paddedHeaderRect.Left, paddedHeaderRect.Right - imageSize),
                y: paddedHeaderRect.Top + Math.Max(0, paddedHeaderRect.Height - imageSize) / 2,
                width: Math.Min(imageSize, paddedHeaderRect.Width), 
                height: Math.Min(imageSize, paddedHeaderRect.Height));
            textRect = new(
                x: paddedHeaderRect.Left,
                y: paddedHeaderRect.Top, 
                width: paddedHeaderRect.Width,
                height: paddedHeaderRect.Height);
            
            if (IsHandleCreated)
            {
                using var graphics = Graphics.FromHwnd(Handle);
                using var format = GetStringFormat();

                var textSize = Size.Ceiling(graphics.MeasureString(Text, Font, textRect.Size, format));

                textRect = new (
                    textRect.Left,
                    Math.Min(headerRect.Bottom - headerPadding, textRect.Top + Math.Max(0, textRect.Height - textSize.Height) / 2),
                    Math.Min(headerRect.Width - 2 * headerPadding, textSize.Width),
                    Math.Min(headerRect.Height - 2 * headerPadding, textSize.Height));
            }

            focusRect = new(
                x: headerRect.Left + focusPadding, 
                y: headerRect.Top + focusPadding, 
                width: Math.Max(0, headerRect.Width - 2 * focusPadding),
                height: Math.Max(0, headerRect.Height - 2 * focusPadding));
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
            new(SnapLineType.Left, 0, SnapLinePriority.High),
            new(SnapLineType.Left, Margin.Left, SnapLinePriority.High),
            new(SnapLineType.Top, 0, SnapLinePriority.High),
            new(SnapLineType.Top, Margin.Top, SnapLinePriority.High),
            new(SnapLineType.Right, Width, SnapLinePriority.High),
            new(SnapLineType.Right, Width - Margin.Right, SnapLinePriority.High),
            new(SnapLineType.Bottom, Height, SnapLinePriority.High),
            new(SnapLineType.Bottom, Height - Margin.Bottom, SnapLinePriority.High),
            new(SnapLineType.Baseline, textRect.Bottom, SnapLinePriority.High),
            new(SnapLineType.Top, headerRect.Height, SnapLinePriority.High),
            new(SnapLineType.Baseline, headerRect.Height, SnapLinePriority.High),
            new(SnapLineType.Horizontal, headerRect.Height, SnapLinePriority.High)
        };
    }
}
