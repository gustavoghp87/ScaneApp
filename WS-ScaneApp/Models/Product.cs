using System;
using System.Collections.Generic;

#nullable disable

namespace WS_ScaneApp.Models
{
    public partial class Product
    {
        public Product()
        {
            Concepts = new HashSet<Concept>();
        }

        public long Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Concept> Concepts { get; set; }
    }
}
