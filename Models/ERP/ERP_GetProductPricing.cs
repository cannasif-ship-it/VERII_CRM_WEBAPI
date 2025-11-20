using System.ComponentModel.DataAnnotations.Schema;

namespace depoWebAPI.Models
{
    public class ERP_GetProductPricing
    {
        public string? STOK_KODU { get; set; }
        public string? STOK_ADI { get; set; }
        public string? Currency { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? ListPrice { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? CostPrice { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? Discount1 { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? Discount2 { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? Discount3 { get; set; }
    }
}