using System.ComponentModel;
using WindowsFormsExpander.Properties;

#nullable enable

namespace WindowsFormsExpander.LocalizedAttributes
{
    sealed class ExpanderCategory : CategoryAttribute
    {
        internal ExpanderCategory(string category) : base(category){}
        /// <inheritdoc />
        protected override string GetLocalizedString(string value) => 
            Resources.ResourceManager.GetString(value) ?? base.GetLocalizedString(value) ?? value;
    }
}
