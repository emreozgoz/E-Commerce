using DatabaseModel.Entities.Base;
using DatabaseModel.Enumerations;
using DatabaseModel.Entities.Cargo;

using System.ComponentModel.DataAnnotations;

namespace DatabaseModel.Entities.Order
{
    public class Order : EntityBase<long>
    {
        [Required]
        public int CustomerId { get; set; }  // Müşteri kimliği
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;  // Sipariş tarihi
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Total Amount cannot be negative.")]
        public decimal TotalAmount { get; set; }  // Toplam sipariş tutarı
        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;  // Sipariş durumu
        [Required]
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();  // Sipariş kalemleri
        [Range(0, double.MaxValue, ErrorMessage = "Discount Amount cannot be negative.")]
        public decimal DiscountAmount { get; set; }  // Uygulanan indirim miktarı
        [Range(0, double.MaxValue, ErrorMessage = "Total Amount cannot be negative.")]
        public decimal ShippingCost { get; set; }  // Kargo ücreti
        public DateTime? EstimatedDeliveryDate { get; set; }  // Tahmini teslim tarihi

        public Payment.Payment Payment { get; set; }  // Siparişe bağlı ödeme
        public Cargo.Cargo Cargo { get; set; }  // Siparişe bağlı kargo
    }


}
