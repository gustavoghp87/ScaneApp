using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WS_ScaneApp.Models.ProjectRequests
{
    public class SaleRequest
    {
        [Required] [Range(1, Int64.MaxValue, ErrorMessage = "Client Id must be higher than 0")] [ClientExists(ErrorMessage = "Client does not exist")]
        public long ClientId { get; set; }

        [Required]
        public virtual ICollection<ConceptRequest> Concepts { get; set; }
    }
}
