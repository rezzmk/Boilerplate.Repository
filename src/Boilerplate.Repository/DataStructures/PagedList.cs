using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Repository.DataStructures {
    public class PagedList<T> : List<T> {
        public PagingMetadata PagingMetadata { get; }
        
        public bool HasPrevious => PagingMetadata.CurrentPage > 1;
        public bool HasNext => PagingMetadata.CurrentPage < PagingMetadata.TotalPages;

        private PagedList(IEnumerable<T> items, int count, QueryParameters qParams) {
            PagingMetadata = new PagingMetadata(count, qParams.PageSize, qParams.PageNumber);
            AddRange(items);
        }

        public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> source, QueryParameters qParams) {
            var count = await source.CountAsync();
            var items = await source
                .Skip((qParams.PageNumber - 1) * qParams.PageSize)
                .Take(qParams.PageSize)
                .ToListAsync();

            return new PagedList<T>(items, count, qParams);
        }
    }
}