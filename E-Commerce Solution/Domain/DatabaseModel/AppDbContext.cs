using DatabaseModel.Entities.Cargo;
using DatabaseModel.Entities.Coupon;
using DatabaseModel.Entities.Order;
using DatabaseModel.Entities.Payment;
using DatabaseModel.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class AppDbContext : DbContext
    {
        public DbContextOptions currentOptions;
        public AppDbContext(DbContextOptions options) : base(options)
        {
            this.currentOptions = options;
        }

        #region Cargo
        public DbSet<Cargo> Cargos { get; set; }
        #endregion

        #region Coupon
        public DbSet<Coupon> Coupones { get; set; }
        #endregion

        #region Order
        public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> orderItems { get; set; }
        #endregion

        #region Payment
        public DbSet<Payment> Purchases { get; set; }
        #endregion

        #region Product
        public DbSet<Product> Products { get; set; }
        #endregion
    }
}
