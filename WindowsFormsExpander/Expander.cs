using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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
        ExpanderDescription("Description_Expander"),
        Designer(typeof(ExpanderDesigner))
    ]
    public partial class Expander : Control
    {
        bool expanded = true;
        int expandedHeight = defaultExpandedHeight, headerHeight = defaultHeaderHeight;

        Form? ParentForm
        {
            get
            {
                Control? parent = Parent;
                while (parent?.Parent is { } p) parent = p;
                return parent as Form;
            }
        }

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
                SetExpansionMode();
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
                if (Expanded) Height = expandedHeight;
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
                Height = Math.Max(Height, headerHeight + Padding.Vertical);
            }
        }

        /// <summary>
        /// Creates a new <see cref="Expander"/> control.
        /// </summary>
        public Expander()
        {
            SetStyle(enabledStyles,true);
            SetStyle(disabledStyles, false);
            TabStop = true;
            RefreshRectangles();
        }

        void SetExpansionMode()
        {
            if (expanded)
            {
                Height = ExpandedHeight;
                ResumeLayout();
                return;
            }

            if (ContainsFocus)
                Focus();
            SuspendLayout();
            Height = HeaderHeight + Padding.Vertical;
        }

        [Conditional("DEBUG")]
        void Log(string? msg = null, [CallerMemberName] string? caller = null) => Debug.WriteLine($"{Name}.{caller}: {msg}");
        
    }
}
