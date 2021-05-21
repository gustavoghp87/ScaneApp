using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WS_ScaneApp.Models.ProjectRequests
{
    public class SaleRequest
    {
        [Required]
        public long ClientId { get; set; }
        
        [Required]
        public virtual ICollection<ConceptRequest> Concepts { get; set; }
    }
}
