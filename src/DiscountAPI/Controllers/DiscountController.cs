using DiscountAPI.Models;
using DiscountAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscountAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        ICuponRepository _configuration;  
        public DiscountController(ICuponRepository configuration) 
        
        {
            _configuration = configuration;
        
        }


        [HttpGet]   

        public async Task<IActionResult> GetDiscount(string ProductId)
        {
            var dis = _configuration.GetDiscount(ProductId);
            return Ok(dis);
        }
        [HttpPost]

        public async Task<IActionResult> CreateCupon(Cupon cupon)
        {
            var dis = _configuration.CreateCupon(cupon);
            if (cupon == null) {
                BadRequest();
            
            }
            return Ok("Save SuccessFully");
        }
        [HttpPost]

        public async Task<IActionResult> UpdateCupon(Cupon cupon)
        {
            var dis = _configuration.UpdateCupon(cupon);
            if (dis != null)
            {
                return Ok("Update SuccessFully");
            }
            
            return BadRequest();
        }
        [HttpDelete]
          public async Task<IActionResult> DeleteCupon(string ProductId)
        {
            var dis = _configuration.DeleteCupon(ProductId);
            if (dis != null) {
                return Ok("Delete SuccessFully");
            }
            return BadRequest();
            
        }

        [HttpGet]
        public async Task<IActionResult> TestDatabaseConnection()
        {
            var data = _configuration.TestDatabaseConnection();
            return Ok("Connection Sucess");
        }




    }
}
