﻿using DatabaseModel.Entities.Base;
using DatabaseModel.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModel.Entities.Payment
{
    public class Payment : EntityBase<long>
    {
        [Required]
        public long OrderId { get; set; }  // İlgili sipariş kimliği
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount cannot be nagative.")]
        public decimal Amount { get; set; }  // Ödeme tutarı
        [Required]
        public PaymentMethod Method { get; set; }  // Ödeme yöntemi
        [Required]
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;  // Ödeme durumu
        public DateTime PaymentDate { get; set; }  // Ödeme tarihi
        [MaxLength(50)]
        public string TransactionId { get; set; }  // İşlem kimliği (ödeme sağlayıcısı tarafından sağlanır)
    }
}