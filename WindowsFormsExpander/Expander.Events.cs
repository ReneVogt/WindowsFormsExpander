using System;
using WindowsFormsExpander.LocalizedAttributes;
using WindowsFormsExpander.Properties;

#nullable enable

namespace WindowsFormsExpander
{
    partial class Expander
    {
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

        /// <summary>
        /// Called when <see cref="Expanded"/> has been changed.
        /// Raises the <see cref="ExpandedChanged"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnExpandedChanged(EventArgs e)
        {
            ExpandedChanged?.Invoke(this, e);
        }
        /// <summary>
        /// Called when <see cref="ExpandedHeight"/> has been changed.
        /// Raises the <see cref="ExpandedHeightChanged"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnExpandedHeightChanged(EventArgs e)
        {
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
        }
    }
}