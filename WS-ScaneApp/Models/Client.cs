using System;
using System.Collections.Generic;

#nullable disable

namespace WS_ScaneApp.Models
{
    public partial class Client
    {
        public Client()
        {
            Sales = new HashSet<Sale>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
