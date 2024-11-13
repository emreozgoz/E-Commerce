using DatabaseModel.Entities.Base;
using DatabaseModel.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities.Category
{
    public class Category : EntityBase<long>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }  // Kategori adı

        [MaxLength(200)]
        public string Description { get; set; }  // Kategori açıklaması

        public bool IsActive { get; set; } = true;  // Kategorinin aktif olup olmadığını belirler

        public List<Product.Product> Products { get; set; } = new List<Product.Product>();  // Kategoriye ait ürünler
    }
}
