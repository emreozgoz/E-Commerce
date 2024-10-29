using DatabaseModel.Entities.Base;
using DatabaseModel.Entities.Base.Interface;
using DatabaseModel.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [MaxLength(50)]
        public string Category { get; set; }

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

        public List<DiscountRule> DiscountRules { get; set; }

        // Envanter durumu için alarm seviyesi (Stok azaldığında uyarı)
        public int StockThreshold { get; set; }

        // Ürün için tedarik süresi (Stokta değilse kaç gün içinde temin edileceği)
        public int LeadTimeDays { get; set; }

        // İlgili Ürünler (Öneri için kullanılabilir)
        public List<Product> RelatedProducts { get; set; }
    }

    // Ürün varyantları örneğin renk, beden, vb.
    public class ProductVariant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    // Ürün görselleri
    public class ProductImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
    }

    // İndirim kuralları
    public class DiscountRule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}

