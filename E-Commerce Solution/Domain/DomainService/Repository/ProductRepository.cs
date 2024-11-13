using DatabaseModel;
using DatabaseModel.Entities.Product;
using DatabaseModel.Enumerations;
using DomainService.Base;
using DomainService.Extensions;
using DomainService.Interfaces;
using DomainService.Logging.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Repository
{
    public class ProductRepository : BaseOperation
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILoggerService _loggerService;



        public ProductRepository(AppDbContext appDbContext, ILoggerService loggerService) : base(appDbContext)
        {
            _appDbContext = appDbContext;
            _loggerService = loggerService;
        }

        public async void ActiveProduct(long id)
        {
            var product = await _appDbContext.Products.FindAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            if (product.Status != ProductStatus.Active)
            {
                product.Status = ProductStatus.Active;

                // Durum güncellemesini logla
                UpdateEntity(product);
            }
            else
            {
                //loglama yap
                throw new System.Exception($"Product with ID {id} is already active.");
            }
        }

        public Product AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product AddRelatedProducts(List<Product> productList)
        {
            throw new NotImplementedException();
        }

        public async void DeactiveProduct(long id)
        {
            var product = await _appDbContext.Products.FindAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            if (product.Status != ProductStatus.Passive)
            {
                product.Status = ProductStatus.Passive;

                // Durum güncellemesini logla
                UpdateEntity(product);
            }
            else
            {
                //loglama yap
                throw new System.Exception($"Product with ID {id} is already passive.");
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _appDbContext.Products.Where(x => !x.IsDeleted).ToListAsync();
            if (!products.Any())
            {
                throw new System.Exception("Product list is empty");
            }
            return products;
        }

        public async Task<List<Product>> GetDiscountedProducts()
        {
            var discountedProducts = await _appDbContext.Products
                .Where(x => x.DiscountedPrice > 0)
                .Take(10)
                .ToListAsync();
            if (!discountedProducts.Any())
            {
                throw new System.Exception("Discounted Product list is empty");
            }
            return discountedProducts;
        }

        public async Task<int> GetLeadTime(int productId)
        {
            var product = await _appDbContext.Products.FindAsync(productId);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            return product.LeadTimeDays;
        }

        public async Task<Product> GetProductById(long id)
        {
            var product = (await _appDbContext.Products.FindAsync(id));
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            return product;
        }

        public async Task<List<Product>> GetProductsByBrand(string brand)
        {
            var product = await _appDbContext.Products.Where(x => x.Brand == brand).ToListAsync();
            if (!product.Any())
                throw new KeyNotFoundException($"Product with brand {brand} not found.");
            return product;
        }

        public async Task<List<Product>> GetProductsByCategory(long category)
        {
            var product = await _appDbContext.Products.Where(x => x.CategoryId == category).ToListAsync();
            if (!product.Any())
                throw new KeyNotFoundException($"Product with CategoryId {category} not found.");
            return product;
        }

        public async Task<decimal> GetProductDesiAsync(long id)
        {
            var product = await GetProductById(id);

            if (product == null)
            {
                throw new InvalidOperationException($"Product with ID {id} not found.");
            }

            return CalculateDesi(product);
        }

        public List<Product> GetPublishedProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetRelatedProducts(long productId)
        {
            throw new NotImplementedException();
        }

        public string GetSeoMetaTitle(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetTopRatedProducts()
        {
            throw new NotImplementedException();
        }

        public IList<Product> Search(string customerIdentifier, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = _appDbContext.Products.AsQueryable().AsNoTracking();

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public List<Product> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product updatedProduct)
        {
            throw new NotImplementedException();
        }

        public void UpdateStock(long productId, int quantity)
        {
            throw new NotImplementedException();
        }

        #region PrivateMethods
        private decimal CalculateDesi(Product product)
        {
            return (product.Weight * product.Height * product.Width) / 3000;
        }
        #endregion
    }
}
