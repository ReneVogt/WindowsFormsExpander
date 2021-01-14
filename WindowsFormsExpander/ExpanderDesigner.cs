using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.Design;

namespace WindowsFormsExpander
{
    /// <summary>
    /// Provides design time support for the <see cref="Expander"/> control.
    /// </summary>
    public class ExpanderDesigner : ParentControlDesigner
    {
        /// <inheritdoc />
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            if (Control is not Expander expander) return;
            EnableDesignMode(expander, expander.Name);
        }

        /// <inheritdoc />
        public override IList SnapLines => (Control as Expander)?.SnapLines ?? base.SnapLines;

        /// <inheritdoc />
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            if (Control is Expander expander) expander.Size = new Size(250, 250);
        }
    }
}
