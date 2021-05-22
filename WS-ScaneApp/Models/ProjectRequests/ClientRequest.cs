using System;
using System.ComponentModel.DataAnnotations;

namespace WS_ScaneApp.Models.ProjectRequests
{
    public class ClientRequest
    {
        [Required] [Range(1, Int64.MaxValue, ErrorMessage = "Product Id must be higher than 0")]
        public int Id { get; set; }

        [Required] [MinLength(1)]
        public string Name { get; set; }

        public string Phone { get; set; }
    }
}
