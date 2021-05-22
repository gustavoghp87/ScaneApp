using System;
using System.ComponentModel.DataAnnotations;

namespace WS_ScaneApp.Models.ProjectRequests
{
    public class ConceptRequest
    {
        [Required] [Range(1, Int64.MaxValue, ErrorMessage = "Product Id must be higher than 0")]
        public long ProductId { get; set; }

        [Required] [MinLength(1, ErrorMessage = "Product Name cannot be null")]
        public string SaleName { get; set; }

        [Required] [Range(1, float.MaxValue, ErrorMessage = "Sale Price must be higher than 0")]
        public decimal SalePrice { get; set; }

        [Required] [Range(1, Int32.MaxValue, ErrorMessage = "Quantity must be higher than 0")]
        public int Quantity { get; set; }
    }
}
