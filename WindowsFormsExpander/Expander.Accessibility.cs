using System.Drawing;
using System.Windows.Forms;

#nullable enable

namespace WindowsFormsExpander
{
    partial class Expander
    {
        /// <inheritdoc />
        protected override AccessibleObject CreateAccessibilityInstance() => new ExpanderAccessibleObject(this);
        /// <inheritdoc />
        protected override AccessibleObject? GetAccessibilityObjectById(int objectId) => AccessibilityObject?.GetChild(objectId);

        sealed class ExpanderAccessibleObject : ControlAccessibleObject
        {
            internal HeaderAccessibleObject HeaderAccessibleObject { get; }
            internal ContentAccessibleObject ContentAccessibleObject { get; }

            internal Expander Expander { get; }

            public override AccessibleRole Role => AccessibleRole.Grouping;
            public override AccessibleStates State
            {
                get
                {
                    if (!Expander.Visible) return AccessibleStates.Invisible;
                    if (!Expander.Enabled) return AccessibleStates.None;

                    var state = AccessibleStates.Focusable |
                                (Expander.Expanded ? AccessibleStates.Expanded : AccessibleStates.Collapsed);
                    if (Expander.Focused)
                        state |= AccessibleStates.Focused;

                    return state;
                }
            }

            internal ExpanderAccessibleObject(Expander expander)
                : base(expander)
            {
                Expander = expander;
                HeaderAccessibleObject = new(this);
                ContentAccessibleObject = new(this);
            }

            public override int GetChildCount() => 2;
            public override AccessibleObject? GetChild(int index) => index switch
            {
                0 => HeaderAccessibleObject,
                1 => ContentAccessibleObject,
                _ => null
            };
        }
        sealed class HeaderAccessibleObject : AccessibleObject
        {
            readonly ExpanderAccessibleObject parent;
            readonly HeaderTextAccessibleObject textAccessibleObject;

            internal Expander Expander => parent.Expander;
            public override Rectangle Bounds => Expander.HeaderRect;
            public override AccessibleObject Parent => parent;
            public override AccessibleRole Role => AccessibleRole.PushButton;
            public override AccessibleStates State
            {
                get
                {
                    if (!Expander.Visible) return AccessibleStates.Invisible;
                    if (!Expander.Enabled) return AccessibleStates.None;
                    var state = AccessibleStates.Focusable | AccessibleStates.Selectable;
                    if (Expander.Focused)
                        state |= AccessibleStates.Focused;
                    if (Expander.CollapseButtonHovered)
                        state |= AccessibleStates.HotTracked;
                    if (Expander.CollapseButtonPressed)
                        state |= AccessibleStates.Pressed;
                    return state;
                }
            }

            internal HeaderAccessibleObject(ExpanderAccessibleObject parent)
            {
                this.parent = parent;
                textAccessibleObject = new(this);
            }

            public override int GetChildCount() => 1;
            public override AccessibleObject? GetChild(int index) =>
                index == 0 ? textAccessibleObject : null;

            public override AccessibleObject Navigate(AccessibleNavigation navdir) => parent.ContentAccessibleObject;
        };
        sealed class HeaderTextAccessibleObject : AccessibleObject
        {
            readonly HeaderAccessibleObject parent;

            public override AccessibleRole Role => AccessibleRole.StaticText;
            public override AccessibleStates State => AccessibleStates.ReadOnly;
            public override Rectangle Bounds => parent.Expander.TextRect;
            public override AccessibleObject Parent => parent;
            public HeaderTextAccessibleObject(HeaderAccessibleObject parent)
            {
                this.parent = parent;
            }
        }
        sealed class ContentAccessibleObject : ControlAccessibleObject
        {
            readonly ExpanderAccessibleObject parent;
            public override Rectangle Bounds => new(parent.Expander.BorderRect.Location, parent.Expander.BorderRect.Size);
            public override AccessibleObject Parent => parent;
            internal ContentAccessibleObject(ExpanderAccessibleObject parent) : base(parent.Expander)
            {
                this.parent = parent;
            }
            public override AccessibleObject Navigate(AccessibleNavigation navdir) => parent.HeaderAccessibleObject;
        }
    }
}
