using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

#nullable enable

namespace WindowsFormsExpander
{
    partial class Expander
    {
        sealed class ExpanderDesigner : ParentControlDesigner
        {
            Expander Expander => (Expander)Control;

            /// <inheritdoc />
            protected override Point DefaultControlLocation => Expander.DisplayRectangle.Location;

            /// <inheritdoc />
            public override IList SnapLines => new List<SnapLine>()
            {
                new(SnapLineType.Left, 0, SnapLinePriority.High),
                new(SnapLineType.Left, Expander.Margin.Left, SnapLinePriority.High),
                new(SnapLineType.Top, 0, SnapLinePriority.High),
                new(SnapLineType.Top, Expander.Margin.Top, SnapLinePriority.High),
                new(SnapLineType.Right, Expander.Width, SnapLinePriority.High),
                new(SnapLineType.Right, Expander.Width - Expander.Margin.Right, SnapLinePriority.High),
                new(SnapLineType.Bottom, Expander.Height, SnapLinePriority.High),
                new(SnapLineType.Bottom, Expander.Height - Expander.Margin.Bottom, SnapLinePriority.High),
                new(SnapLineType.Baseline, Expander.TextRect.Bottom, SnapLinePriority.High),
                new(SnapLineType.Top, Expander.HeaderRect.Height, SnapLinePriority.High),
                new(SnapLineType.Baseline, Expander.HeaderRect.Height, SnapLinePriority.High),
                new(SnapLineType.Horizontal, Expander.HeaderRect.Height, SnapLinePriority.High)
            };
        }
    }
}
