﻿using System.ComponentModel.DataAnnotations;

namespace DatabaseModel.Entities.Coupon
{
    public class Coupon
    {
        public int Id { get; set; } // Primary Key
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }  // Kupon kodu

        [Required]
        public decimal DiscountAmount { get; set; }  // İndirim miktarı

        [Required]
        public DateTime ValidFrom { get; set; }  // Geçerlilik başlangıcı

        [Required]
        public DateTime ValidTo { get; set; }  // Geçerlilik bitiş tarihi

        public bool IsActive { get; set; } = true;  // Kuponun aktif olup olmadığını belirler
        public int UsageLimit { get; set; } = 1;  // Kuponun kullanılabileceği maksimum sayıda kullanım
        public int TimesUsed { get; set; } = 0;  // Kuponun kaç kez kullanıldığını izler
    }
}