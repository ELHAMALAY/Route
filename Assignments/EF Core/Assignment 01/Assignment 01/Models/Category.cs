using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_01.Models
{
    internal class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
