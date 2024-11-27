using CateLogApi.Models;
using MongoRepo.Interfaces.Repository;

namespace CateLogApi.Interfaces.Repository
{
    public interface IProductRepository : ICommonRepository<Product>
    {
    }
}
