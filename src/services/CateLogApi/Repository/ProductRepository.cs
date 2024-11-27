using CateLogApi.Context;
using CateLogApi.Interfaces.Repository;
using CateLogApi.Models;
using MongoRepo.Context;
using MongoRepo.Repository;

namespace CateLogApi.Repository
{
    public class ProductRepository : CommonRepository<Product>, IProductRepository
    {
        public ProductRepository() : base(new CatelogDbContext())
        {
        }
    }
}
