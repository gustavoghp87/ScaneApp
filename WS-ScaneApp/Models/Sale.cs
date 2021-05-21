using System;
using System.Collections.Generic;

#nullable disable

namespace WS_ScaneApp.Models
{
    public partial class Sale
    {
        public Sale()
        {
            Concepts = new HashSet<Concept>();
        }

        public long Id { get; set; }
        public long ClientId { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Concept> Concepts { get; set; }
    }
}
