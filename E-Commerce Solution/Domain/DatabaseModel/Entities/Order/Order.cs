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

        [Range(0, double.MaxValue, ErrorMessage = "Shipping Cost cannot be negative.")]
        public decimal ShippingCost { get; set; }  // Kargo ücreti

        public DateTime? EstimatedDeliveryDate { get; set; }  // Tahmini teslim tarihi

        public Payment.Payment Payment { get; set; }  // Siparişe bağlı ödeme

        public Cargo.Cargo Cargo { get; set; }  // Siparişe bağlı kargo

        public string CustomerName { get; set; }  // Müşteri adı

        [EmailAddress]
        public string CustomerEmail { get; set; }  // Müşteri e-posta

        public List<OrderStatusHistory> StatusHistory { get; set; } = new List<OrderStatusHistory>();  // Sipariş durum geçmişi

        public string ShippingAddress { get; set; }  // Kargo adresi

        public string TrackingNumber { get; set; }  // Kargo takip numarası

        public string PaymentMethod { get; set; }  // Ödeme yöntemi

        public string PaymentStatus { get; set; }  // Ödeme durumu

        public string Notes { get; set; }  // Sipariş notları

        public int? CouponId { get; set; }  // Kupon kimliği
        public decimal TotalDiscount { get; set; }  // Toplam indirim
    }


}
