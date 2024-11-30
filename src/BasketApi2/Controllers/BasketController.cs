using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreApiResponse;
using BasketAPI.Repository;
using System.Net;
using BasketAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;


namespace BasketAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : BaseController
    {
        private readonly IBasketRepository _basketRepository;
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }


        [HttpGet]
        //[ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
        public  async Task<IActionResult> GetBasket(string user)
        {
            try
            {
                var basket = await _basketRepository.GetBasket(user);
                return Ok(basket);

            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
        public async  Task<IActionResult> UpdateBasket([FromBody]ShoppingCart basket)
        {
            try
            {
                var basket1 = await _basketRepository.UpdateBasket(basket);
                return CustomResult("Data Save SuccessFully",basket1);

            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }    
        [HttpDelete]
        [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
        public  async Task<IActionResult> DeleteBasket(string userName)
        {
            try
            {
                 await _basketRepository.DeleteBasket(userName);
                return CustomResult("Data Dekete SuccessFully");

            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

    }
}
