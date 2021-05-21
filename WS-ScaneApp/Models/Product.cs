using System;
using System.Collections.Generic;

#nullable disable

namespace WS_ScaneApp.Models
{
    public partial class Product
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
