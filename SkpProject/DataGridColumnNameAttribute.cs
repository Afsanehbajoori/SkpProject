using System;
using System.Collections.Generic;
using System.Text;

namespace SkpProject
{
    class DataGridColumnNameAttribute : Attribute
    {
        public DataGridColumnNameAttribute(string Name) { this.Name = Name; }
        public string Name { get; set; }
    }
}
