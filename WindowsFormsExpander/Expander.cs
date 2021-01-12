using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
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
        Rectangle buttonRectangle;
        #endregion
        #region Events
        /// <summary>
        /// Raised when <see cref="Expanded"/> has been changed.
        /// </summary>
        [ExpanderDescription("Description_ExpandedChanged")]
        public event EventHandler? ExpandedChanged;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets a value indicating if this <see cref="Expander"/> is currently
        /// expanded or collapsed.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [ExpanderDescription("Description_Expanded")]
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

            pe.Graphics.DrawImage(Expanded ? Resources.collapseImage : Resources.expandImage, buttonRectangle.Location);
            Debug.WriteLine($"ONPAINT: {Focused}");
            if (Focused)
                ControlPaint.DrawFocusRectangle(pe.Graphics, buttonRectangle);
        }
        /// <inheritdoc />
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            buttonRectangle = new Rectangle(Width - 16, 0, 16, 16);
        }
        /// <inheritdoc />
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate(buttonRectangle);
            Debug.WriteLine($"GOT FOCUS ({Name}): {Controls.Count}");
        }
        /// <inheritdoc />
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate(buttonRectangle);
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
            ExpandedChanged?.Invoke(this, e);
        }
        #endregion

    }
}
