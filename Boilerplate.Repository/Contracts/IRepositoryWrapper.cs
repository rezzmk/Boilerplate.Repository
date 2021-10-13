using System.Threading.Tasks;

namespace Boilerplate.Repository.Contracts {
    public interface IRepositoryWrapper {
        Task SaveAsync();
    }
}