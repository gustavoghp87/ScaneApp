using System.ComponentModel.DataAnnotations;

namespace WS_ScaneApp.Models.ProjectRequests
{
    public class ConceptRequest
    {
        [Required]
        public long ProductId { get; set; }

        [Required]
        public string SaleName { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public long Total { get; set; }
    }
}
