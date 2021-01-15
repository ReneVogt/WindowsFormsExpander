using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

#nullable enable

namespace ExpanderTestApp
{
    public partial class DemoForm : Form
    {
        class Person
        {
            [DisplayName("First name")]
            [Category("Person")]
            public string FirstName { get; set; } = "René";
            [Category("Person")]
            [DisplayName("Last name")]
            public string LastName { get; set; } = "Vogt";
            [Category("Person")]
            [DisplayName("Day of birth")]
            public string Birthday { get; set; } = new DateTime(1979, 05, 03).ToString("d", CultureInfo.InvariantCulture);
        }
        class Address
        {
            [Category("Address")]
            public string City { get; set; } = "Dresden";
            [Category("Address")]
            public string Country { get; set; } = "Germany";
        }
        public DemoForm()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = new Person();
            propertyGrid2.SelectedObject = new Address();
            
        }
    }
}
