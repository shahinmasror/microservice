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

        public async Task<bool> CreateCupon(Cupon cupon)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
            var data = await connection.ExecuteAsync("Insert into Cupon(ProductId,ProductName,Description,Amount) Values(@ProductId,@ProductName,@Description,@Amount)", new { ProductId = cupon.ProductId, ProductName = cupon.ProductName, Description = cupon.Description, Amount = cupon.Amount });
            if(data == null)
            {
                return false;
            } 
            return true;

        }

        public async Task<bool> DeleteCupon(string ProductId)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
            var delete = await connection.ExecuteAsync("Delete from Cupon where productId= @productId  ",new {ProductId = ProductId});
            if (delete > 0)
            {
                return false;
            }
            return true;

        }

        public async Task<Cupon> GetDiscount(string ProductId)
        {
            await using var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
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
                var copon = await connection.QueryFirstOrDefaultAsync<Cupon>(
                    "SELECT * FROM Cupon WHERE ProductId = @ProductId",
                    new { ProductId }).ConfigureAwait(false);
                return copon ?? new Cupon() { Amount = 0, ProductName = "No Discount" };
            }
            catch (Exception ex)
            {
               // ILogger.LogError(ex, "An error occurred while fetching the discount.");
                throw ex;
            }

        }

        public async Task<bool> TestDatabaseConnection()
        {
            await using var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
            await connection.OpenAsync();
            var result = await connection.QueryFirstOrDefaultAsync<string>("SELECT 'Test Connection';");
            return result == "Test Connection";
        }



        public async Task<bool> UpdateCupon(Cupon cupon)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
            var update = await connection.ExecuteAsync("Update Cupon Set ProductId= @ProductId,ProductName = @ProductName,Description= @Description,Amount=@Amount", new { ProductId = cupon.ProductId, ProductName = cupon.ProductName, Description = cupon.Description, Amount = cupon.Amount });
            if(update > 0)
            {
                return true;
            }
            return false;
        }
    }
}
