using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Base
{
    public class BaseOperation
    {
        private readonly AppDbContext dbContext;

        public BaseOperation(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            if (dbContext.Database.CurrentTransaction == null)
                dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (dbContext.Database.CurrentTransaction != null)
                dbContext.Database.CommitTransaction();
        }

        public TEntity SaveEntity<TEntity>(TEntity entity)
        {
            if (dbContext.Database.CurrentTransaction == null)
            {
                dbContext.Database.BeginTransaction();
            }

            dbContext.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public void UpdateEntity<TEntity>(TEntity entity)
        {
            if (dbContext.Database.CurrentTransaction == null)
            {
                dbContext.Database.BeginTransaction();
            }

            dbContext.Update(entity);
            dbContext.SaveChanges();
        }

        public void DeleteEntity<TEntity>(TEntity entity)
        {
            if (dbContext.Database.CurrentTransaction == null)
            {
                dbContext.Database.BeginTransaction();
            }

            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
