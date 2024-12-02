using Dapper;
using DiscountAPI.Models;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace DiscountAPI.Repository
{
    public class CuounRepository : ICuponRepository
    {
        IConfiguration _configuration;

        public CuounRepository(IConfiguration configuration) 
        {
        _configuration = configuration;
        }

        public async Task<bool> CreateCupon(string name)
        {
            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("Discount"));
            var data = await connection.ExecuteAsync("Insert into Cupon(name) Values(@name)", new { @name = name});
            if(data == null)
            {
                return false;
            } 
            return true;

        }

        public async Task<bool> DeleteCupon(long ProductId)
        {
            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("Discount"));
            var delete = await connection.ExecuteAsync("Delete from Cupon where id= @productId  ",new { productId = ProductId});
            if (delete > 0)
            {
                return false;
            }
            return true;

        }

        public async Task<CuponDTO> GetDiscount(long ProductId)
        {
             using var connection = new NpgsqlConnection(_configuration.GetConnectionString("Discount"));
            //await connection.OpenAsync(); // Ensure connection is open
            //var copon = await connection.QueryFirstOrDefaultAsync<Cupon>(
            //    //"SELECT * FROM Cupon WHERE ProductId = @ProductId",
            //    "SELECT Id, ProductId, Amount, ProductName FROM Cupon WHERE ProductId = @ProductId",new { ProductId }).ConfigureAwait(false);

            //if (copon == null)
            //{
            //    return new Cupon() { Amount = 0, ProductName = "No Discount" };
            //}

            //return copon;

            try
            {
                var copon =  await connection.QueryFirstOrDefaultAsync<CuponDTO>(
                    "select * from Cupon where id=@productId", new { productId = ProductId })
                   ;
                return copon;
            }
            catch (Exception ex)
            {
               // ILogger.LogError(ex, "An error occurred while fetching the discount.");
                throw ex;
            }

        }

       


        public async Task<bool> UpdateCupon(string name)
        {
            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("Discount"));
            var update = await connection.ExecuteAsync("Update Cupon Set name= @name where id=1", new { name = name});
            if(update > 0)
            {
                return true;
            }
            return false;
        }
    }
}
