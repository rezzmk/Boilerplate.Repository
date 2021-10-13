using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using Boilerplate.Repository.Contracts;

namespace Boilerplate.Repository.Helpers {
    public class SortingHelper<T> : ISortingHelper<T> {
        public IQueryable<T> ApplySort(IQueryable<T> records, string orderBy) {
            if (!records.Any()) return records;
            if (string.IsNullOrWhiteSpace(orderBy)) return records;

            var orderParams = orderBy.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams) {
                if (string.IsNullOrWhiteSpace(param)) continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(p =>
                    p.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null) continue;

                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            return records.OrderBy(orderQuery);
        }
    }
}