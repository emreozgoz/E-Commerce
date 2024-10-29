using DatabaseModel.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModel.Entities.Order
{
    public class OrderItem : EntityBase<long>
    {
        
        [Required]
        public long ProductId { get; set; }  // Ürün kimliği
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }  // Ürün adedi
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "UnitPrice cannot be negative.")]
        public decimal UnitPrice { get; set; }  // Birim fiyat
        [Range(0, double.MaxValue, ErrorMessage = "DiscountedUnitPrice cannot be negative.")]
        public decimal DiscountedUnitPrice { get; set; }  // İndirimli birim fiyat

        [ForeignKey("Order")]
        public long OrderId { get; set; }  // Sipariş kimliği
        public Order Order { get; set; }  // Sipariş referansı
    }
}
