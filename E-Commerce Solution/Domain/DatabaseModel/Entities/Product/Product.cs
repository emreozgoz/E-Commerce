using DatabaseModel.Entities.Base;
using DatabaseModel.Entities.Base.Interface;
using DatabaseModel.Entities.Category;
using DatabaseModel.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModel.Entities.Product
{
    public class Product : EntityBase<long>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal? DiscountedPrice { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        [MaxLength(10)]
        public string SKU { get; set; }

        [Required]
        public long CategoryId { get; set; }  // Kategori kimliği
        public Category.Category Category { get; set; }  // Kategori referansı

        [Required]
        [MaxLength(50)]
        public string SubCategory { get; set; }

        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }

        [Required]
        public List<ProductVariant> Variants { get; set; }

        [Required]
        public List<ProductImage> Images { get; set; }

        [Required]
        public bool IsPublished { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public decimal ShippingCost { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public string Dimensions { get; set; }

        [Required]
        public int ReviewCount { get; set; }

        [Required]
        public double AverageRating { get; set; }

        [Required]
        [MaxLength(50)]
        public string SeoMetaTitle { get; set; }

        [Required]
        [MaxLength(50)]
        public string SeoMetaDescription { get; set; }

        [Required]
        [MaxLength(50)]
        public string Slug { get; set; }

        [Required]
        public ProductStatus Status { get; set; }

        public decimal Width { get; set; }  // En (width)
        public decimal Length { get; set; } // Boy (length)
        public decimal Height { get; set; } // Yükseklik (height)


        public List<DiscountRule> DiscountRules { get; set; }

        // Envanter durumu için alarm seviyesi (Stok azaldığında uyarı)
        public int StockThreshold { get; set; }

        // Ürün için tedarik süresi (Stokta değilse kaç gün içinde temin edileceği)
        public int LeadTimeDays { get; set; }

        // İlgili Ürünler (Öneri için kullanılabilir)
        public List<Product> RelatedProducts { get; set; }
    }
}
