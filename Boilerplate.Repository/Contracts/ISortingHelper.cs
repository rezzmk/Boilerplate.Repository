using System.Linq;

namespace Boilerplate.Repository.Contracts {
    public interface ISortingHelper<T> {
        IQueryable<T> ApplySort(IQueryable<T> records, string orderBy);
    }
}