using DatabaseModel.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Interfaces
{
    public interface IProductRepository
    {
        IList<Product> Search(string customerIdentifier, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount);
        Product AddProduct(Product product); // Yeni bir ürün ekler
        List<Product> GetAllProducts(); // Tüm ürünleri döndürür
        Product GetProductById(long id); // ID ile ürünü alır
        Product UpdateProduct(Product updatedProduct); // Var olan bir ürünü günceller
        void DeactiveProduct(long id); // Ürünü aktif eder
        void ActiveProduct(long id); // Ürünü siler
        List<Product> GetPublishedProducts(); // Yayınlanmış ürünleri döndürür
        List<Product> GetProductsByCategory(long category); // Kategoriye göre ürünleri döndürür
        List<Product> GetProductsByBrand(string brand); // Markaya göre ürünleri döndürür
        List<Product> GetDiscountedProducts(); // İndirimli ürünleri döndürür
        List<Product> SearchProducts(string searchTerm); // Ürünlerde arama yapar
        void UpdateStock(long productId, int quantity); // Ürün stokunu günceller
        List<Product> GetRelatedProducts(long productId); // İlgili ürünleri döndürür
        List<Product> GetTopRatedProducts(); // Yüksek puanlı ürünleri döndürür
        decimal GetProductWeight(long id); //Ürün desisini hesaplar
        Product AddRelatedProducts(List<Product> productList); //İlgili Ürün ekleme Fonksiyonu
        int GetLeadTime(int productId); //Tedarik süresini getirir.
        string GetSeoMetaTitle(int productId); //Seo Meta title ını getirir

    }
}
