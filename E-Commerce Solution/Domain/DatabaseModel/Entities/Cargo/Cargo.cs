using DatabaseModel.Entities.Base;
using DatabaseModel.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModel.Entities.Cargo
{
    public class Cargo : EntityBase<long>
    {
        [Required]
        public long OrderId { get; set; }  // İlgili sipariş kimliği
        [Required]
        [MaxLength(50,ErrorMessage ="Tracking Number cannot exceed 50 characters.")]
        public string TrackingNumber { get; set; }  // Kargo takip numarası
        public DateTime ShippedDate { get; set; }  // Kargo gönderim tarihi
        public DateTime EstimatedDeliveryDate { get; set; }  // Tahmini teslim tarihi
        [Required]
        public CargoStatus Status { get; set; } = CargoStatus.Pending;  // Kargo durumu
        [Required]
        [MaxLength(100,ErrorMessage = "ShippingProvider cannot exceed 100 characters.")]
        public string ShippingProvider { get; set; }  // Kargo şirketi
    }
}
