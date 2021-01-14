using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsFormsExpander.LocalizedAttributes;
using WindowsFormsExpander.Properties;

#nullable enable

namespace WindowsFormsExpander
{
    /// <summary>
    /// A container control that can be collapsed and expanded.
    /// </summary>
    [
        ComVisible(true),
        ClassInterface(ClassInterfaceType.AutoDispatch),
        DefaultProperty(nameof(Text)),
        DefaultEvent(nameof(ExpandedChanged)),
        ExpanderDescription("Description_Expander")
    ]
    public class Expander : Control
    {
        #region Constants
        const int defaultHeaderHeight = 24;
        static readonly ControlStyles enabledStyles =
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.ContainerControl |
            ControlStyles.DoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.Selectable |
            ControlStyles.StandardClick |
            ControlStyles.StandardDoubleClick |
            ControlStyles.SupportsTransparentBackColor |
            ControlStyles.UserPaint;
        static readonly ControlStyles disabledStyles =
            ControlStyles.CacheText | 
            ControlStyles.EnableNotifyMessage |
            ControlStyles.FixedHeight |
            ControlStyles.FixedWidth |
            ControlStyles.Opaque |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.UseTextForAccessibility |
            ControlStyles.UserMouse;
        #endregion
        #region Fields
        bool expanded = true;
        bool collapseButtonPressed;
        int expandedHeight, headerHeight;
        #endregion
        #region Private properties
        static int FocusPadding => 2;
        static int ButtonPadding => 5;
        static int ImagePadding => 10;
        Rectangle BorderRect => new(Padding.Left, Padding.Top + HeaderHeight, Width - Padding.Horizontal, ExpandedHeight - Padding.Vertical - HeaderHeight);
        Rectangle HeaderRect => new(Padding.Left, Padding.Top, Width - Padding.Horizontal, HeaderHeight);
        Rectangle FocusRect => new(Padding.Left + FocusPadding, Padding.Top + FocusPadding, HeaderHeight - 2 * FocusPadding, HeaderHeight - 2 * FocusPadding);
        Rectangle ButtonRect => new(Padding.Left + ButtonPadding, Padding.Top + ButtonPadding, HeaderHeight - 2 * ButtonPadding, HeaderHeight - 2 * ButtonPadding);
        Rectangle ImageRect => new(Padding.Left + ImagePadding -  1, Padding.Top + ImagePadding - 1, HeaderHeight - 2 * ImagePadding, HeaderHeight - 2 * ImagePadding);
        static int ImagePenWidth => 2;
        ButtonState ButtonState => Enabled
                                       ? collapseButtonPressed
                                             ? ButtonState.Pushed
                                             : ButtonState.Normal
                                       : ButtonState.Inactive;
        Rectangle TextRect => new(Padding.Left + HeaderHeight + 3,
                                  Padding.Top + (HeaderHeight - Font.Height) / 2,
                                  Width - Padding.Horizontal - HeaderHeight - 6,
                                  Font.Height);
        #endregion
        #region Events
        /// <summary>
        /// Raised when <see cref="Expanded"/> has been changed.
        /// </summary>
        [
            ExpanderDescription(nameof(Resources.Description_ExpandedChanged)),
            ExpanderCategory(nameof(Resources.Category_ChangedProperty))
        ]
        public event EventHandler? ExpandedChanged;
        /// <summary>
        /// Raised when <see cref="ExpandedHeight"/> has been changed.
        /// </summary>
        [
            ExpanderDescription(nameof(Resources.Description_ExpandedHeightChanged)),
            ExpanderCategory(nameof(Resources.Category_ChangedProperty))
        ]
        public event EventHandler? ExpandedHeightChanged;
        /// <summary>
        /// Raised when <see cref="HeaderHeight"/> has been changed.
        /// </summary>
        [
            ExpanderDescription(nameof(Resources.Description_HeaderHeightChanged)),
            ExpanderCategory(nameof(Resources.Category_ChangedProperty))
        ]
        public event EventHandler? HeaderHeightChanged;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets a value indicating if this <see cref="Expander"/> is currently
        /// expanded or collapsed.
        /// </summary>
        [
            Browsable(true),
            DefaultValue(true),
            ExpanderDescription(nameof(Resources.Description_Expanded)),
            ExpanderCategory(nameof(Resources.Category_Appearance))
        ]
        public bool Expanded
        {
            get => expanded;
            set
            {
                if (value == expanded) return;
                expanded = value;
                OnExpandedChanged(EventArgs.Empty);
            }
        }
        /// <summary>
        /// Gets or sets the height the <see cref="Expander"/>
        /// should have when it is expanded.
        /// </summary>
        [
            Browsable(true),
            Localizable(true),
            ExpanderDescription(nameof(Resources.Description_ExpandedHeight)),
            ExpanderCategory(nameof(Resources.Category_Layout))
        ]
        public int ExpandedHeight
        {
            get => expandedHeight;
            set
            {
                if (value == expandedHeight) return;
                expandedHeight = value;
                OnExpandedHeightChanged(EventArgs.Empty);
            }
        }
        /// <summary>
        /// Gets or sets the height of the <see cref="Expander"/>'s header button.
        /// </summary>
        [
            Browsable(true),
            Localizable(true),
            ExpanderDescription(nameof(Resources.Description_HeaderHeight)),
            DefaultValue(defaultHeaderHeight),
            ExpanderCategory(nameof(Resources.Category_Layout))
        ]
        public int HeaderHeight
        {
            get => headerHeight;
            set
            {
                if (headerHeight == value) return;
                headerHeight = value;
                OnHeaderHeightChanged(EventArgs.Empty);
            }
        }
        #endregion
        #region Construction
        /// <summary>
        /// Creates a new <see cref="Expander"/> control.
        /// </summary>
        public Expander()
        {
            SetStyle(enabledStyles,true);
            SetStyle(disabledStyles, false);
            TabStop = true;
        }
        #endregion
        #region Overridden methos
        /// <inheritdoc />
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (Expanded && pe.ClipRectangle.IntersectsWith(BorderRect))
                ControlPaint.DrawBorder3D(pe.Graphics, BorderRect, Border3DStyle.Etched);
            
            if (!pe.ClipRectangle.IntersectsWith(HeaderRect)) return;

            ControlPaint.DrawBorder3D(pe.Graphics, HeaderRect, Border3DStyle.Raised);

            ControlPaint.DrawButton(pe.Graphics, ButtonRect, ButtonState);
            using var imageBrush = new SolidBrush(Enabled ? Color.Black : Color.Gray);
            using var imagePen = new Pen(imageBrush, ImagePenWidth);
            var imageRect = ImageRect;
//            pe.Graphics.DrawEllipse(imagePen, imageRect);
            pe.Graphics.FillRectangle(imageBrush, imageRect.Left + 3, imageRect.Top + imageRect.Height / 2, imageRect.Width - 6, ImagePenWidth);
            if (!Expanded)
                pe.Graphics.FillRectangle(imageBrush, imageRect.Left + imageRect.Width / 2, imageRect.Top + 3, ImagePenWidth, imageRect.Height - 6);

            using var format = new StringFormat
            {
                HotkeyPrefix = ShowKeyboardCues ? HotkeyPrefix.Show : HotkeyPrefix.Hide
            };
            if (RightToLeft == RightToLeft.Yes)
                format.FormatFlags |= StringFormatFlags.DirectionRightToLeft;

            if (Enabled)
            {
                using var textBrush = new SolidBrush(ForeColor);
                pe.Graphics.DrawString(Text, Font, textBrush, TextRect);
            }
            else
                ControlPaint.DrawStringDisabled(pe.Graphics, Text, Font, BackColor, TextRect, format);

            if (Focused)
                ControlPaint.DrawFocusRectangle(pe.Graphics, FocusRect);
        }
        /// <inheritdoc />
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (Expanded)
                ExpandedHeight = Height;
        }
        /// <inheritdoc />
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }
        /// <inheritdoc />
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }
        /// <inheritdoc />
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
            if (e.Button == MouseButtons.Left && ButtonRect.Contains(e.Location) && !collapseButtonPressed)
            {
                collapseButtonPressed = true;
                Invalidate(FocusRect);
            }
        }
        /// <inheritdoc />
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!ButtonRect.Contains(e.Location) && collapseButtonPressed)
            {
                collapseButtonPressed = false;
                Invalidate(ButtonRect);
            }
        }
        /// <inheritdoc />
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (collapseButtonPressed && e.Button == MouseButtons.Left)
            {
                collapseButtonPressed = false;
                Invalidate(ButtonRect);
            }
        }
        /// <inheritdoc />
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (ButtonRect.Contains(e.Location) && e.Button == MouseButtons.Left)
                Expanded = !Expanded;
        }
        #endregion
        #region New event handlers
        /// <summary>
        /// Called when <see cref="Expanded"/> has been changed.
        /// Raises the <see cref="ExpandedChanged"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnExpandedChanged(EventArgs e)
        {
            Height = Expanded ? ExpandedHeight : HeaderHeight;
            ExpandedChanged?.Invoke(this, e);
        }
        /// <summary>
        /// Called when <see cref="ExpandedHeight"/> has been changed.
        /// Raises the <see cref="ExpandedHeightChanged"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnExpandedHeightChanged(EventArgs e)
        {
            if (Expanded)
                Height = ExpandedHeight;
            ExpandedHeightChanged?.Invoke(this, e);
        }
        /// <summary>
        /// Called when <see cref="HeaderHeight"/> has been changed.
        /// Raises the <see cref="HeaderHeightChanged"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnHeaderHeightChanged(EventArgs e)
        {
            HeaderHeightChanged?.Invoke(this, e);
            Invalidate();
        }
        #endregion
    }
}
