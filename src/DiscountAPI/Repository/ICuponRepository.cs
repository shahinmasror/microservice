using DiscountAPI.Models;

namespace DiscountAPI.Repository
{
    public interface ICuponRepository
    {

        Task<CuponDTO> GetDiscount(long ProductId);
        Task<bool> CreateCupon(string name);
        Task<bool> UpdateCupon(string name);
        Task<bool> DeleteCupon(long ProductId);
    }
}
