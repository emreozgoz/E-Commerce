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
        [MaxLength(50, ErrorMessage = "Tracking Number cannot exceed 50 characters.")]
        public string TrackingNumber { get; set; }  // Kargo takip numarası
        public DateTime ShippedDate { get; set; }  // Kargo gönderim tarihi
        public DateTime EstimatedDeliveryDate { get; set; }  // Tahmini teslim tarihi
        [Required]
        public CargoStatus Status { get; set; } = CargoStatus.Pending;  // Kargo durumu
        [Required]
        [MaxLength(100, ErrorMessage = "ShippingProvider cannot exceed 100 characters.")]
        public string ShippingProvider { get; set; }  // Kargo şirketi
        
        [MaxLength(100, ErrorMessage = "RecipientName cannot exceed 100 characters.")]
        public string RecipientName { get; set; }  // Alıcı adı

        [MaxLength(200, ErrorMessage = "RecipientAddress cannot exceed 200 characters.")]
        public string RecipientAddress { get; set; }  // Alıcı adresi

        [MaxLength(15, ErrorMessage = "RecipientPhone cannot exceed 15 characters.")]
        public string RecipientPhone { get; set; }  // Alıcı telefon numarası

        public double Weight { get; set; }  // Kargo ağırlığı
        public double Length { get; set; }  // Kargo uzunluğu
        public double Width { get; set; }   // Kargo genişliği
        public double Height { get; set; }  // Kargo yüksekliği

        public decimal ShippingCost { get; set; }  // Kargo ücreti

        public List<TrackingUpdate> TrackingUpdates { get; set; }  // Takip güncellemeleri
    }
}
