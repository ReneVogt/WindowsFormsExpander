using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsExpander.LocalizedAttributes;
using WindowsFormsExpander.Properties;

#nullable enable

namespace WindowsFormsExpander
{
    /// <summary>
    /// A container control that can be collapsed and expanded.
    /// </summary>
    [DefaultProperty(nameof(Text))]
    [DefaultEvent(nameof(ExpandedChanged))]
    public partial class Expander : GroupBox
    {
        #region Fields
        bool expanded = true;
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
            InitializeComponent();
        }
        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
        #region Event handlers
        /// <inheritdoc />
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.DrawImage(Expanded ? Resources.collapseImage : Resources.expandImage, new Point(Width - 16 - Padding.Right, 0));
        }
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
