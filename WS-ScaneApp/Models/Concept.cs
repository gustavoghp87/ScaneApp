using System;
using System.Collections.Generic;

#nullable disable

namespace WS_ScaneApp.Models
{
    public partial class Concept
    {
        public long Id { get; set; }
        public long SaleId { get; set; }
        public long ProductId { get; set; }
        public string SaleName { get; set; }
        public decimal SalePrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
