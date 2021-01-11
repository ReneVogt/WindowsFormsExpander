using System.ComponentModel;
using WindowsFormsExpander.Properties;

#nullable enable

namespace WindowsFormsExpander.LocalizedAttributes
{
    sealed class ExpanderDescription : DescriptionAttribute
    {
        internal ExpanderDescription(string description) : base(description){}
        public override string Description => Resources.ResourceManager.GetString(base.Description) ?? base.Description;
    }
}
