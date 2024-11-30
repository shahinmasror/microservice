using DiscountAPI.Models;

namespace DiscountAPI.Repository
{
    public interface ICuponRepository
    {

        Task<Cupon> GetDiscount(string ProductId);
        Task<bool> CreateCupon(Cupon cupon);
        Task<bool> UpdateCupon(Cupon cupon);
        Task<bool> DeleteCupon(string ProductId);
        Task<bool> TestDatabaseConnection();
    }
}
