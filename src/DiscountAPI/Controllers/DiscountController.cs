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

        public async Task<IActionResult> GetDiscount(long ProductId)
        {
            var dis = await _configuration.GetDiscount(ProductId);
            return Ok(dis);
        }
        [HttpPost]

        public async Task<IActionResult> CreateCupon(string name)
        {
            var dis = _configuration.CreateCupon(name);
            if (dis == null) {
                BadRequest();
            
            }
            return Ok("Save SuccessFully");
        }
        [HttpPost]

        public async Task<IActionResult> UpdateCupon(string name)
        {
            var dis = _configuration.UpdateCupon(name);
            if (dis != null)
            {
                return Ok("Update SuccessFully");
            }
            
            return BadRequest();
        }
        [HttpDelete]
          public async Task<IActionResult> DeleteCupon(long ProductId)
        {
            var dis = _configuration.DeleteCupon(ProductId);
            if (dis != null) {
                return Ok("Delete SuccessFully");
            }
            return BadRequest();
            
        }

      




    }
}
