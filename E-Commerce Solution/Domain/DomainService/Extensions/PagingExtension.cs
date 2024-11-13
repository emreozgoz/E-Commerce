using System.Linq.Dynamic.Core;

namespace DomainService.Extensions
{
    public static class PagingExtension
    {
        public static IList<T> GetPagedAndSorted<T>(this IQueryable<T> query, int page, int pageSize, string orderDirection, string orderByField, out int totalCount) 
        {
            totalCount = query.Count();
            int count = (page - 1) * pageSize;

            // Order by field and direction dynamically
            var sortedQuery = query.OrderBy($"{orderByField} {orderDirection}");

            return sortedQuery.Skip(count).Take(pageSize).ToList();
        }
    }
}
