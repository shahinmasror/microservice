using CateLogApi.Context;
using CateLogApi.Interfaces.Manager;
using CateLogApi.Models;
using MongoRepo.Context;
using MongoRepo.Repository;

namespace CateLogApi.Repository
{
    public class ProductManeger : CommonRepository<Product>, IProductManager
    {
        public ProductManeger() : base(new CatelogDbContext())
        {
        }

        public List<Product> GetByCategory( string Category )
        {
            return GetAll(c => c.Category == Category).ToList();
        }
    }
}
