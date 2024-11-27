using CateLogApi.Models;
using MongoRepo.Interfaces.Manager;

namespace CateLogApi.Interfaces.Manager
{
    public interface IProductManager : ICommonManager<Product>
    {

        public List<Product> GetByCategory(string Category);

    }
}
