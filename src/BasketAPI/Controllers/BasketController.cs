using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreApiResponse;
using BasketAPI.Repository;
using System.Net;
using BasketAPI.Models;


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
        [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
        public async Task<IAsyncResult> GetBasket(string user)
        {
            try
            {
                var basket = await _basketRepository.GetBasket(user);
                return CustomResult("Data Loded SuccessFully",basket);

            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message ,HttpStatusCode.BadRequest)
            }
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
        public async Task<IAsyncResult> UpdateBasket(FromBody[ShoppingCart] basket)
        {
            try
            {
                var basket = await _basketRepository.UpdateBasket(basket);
                return CustomResult("Data Save SuccessFully",basket);

            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message ,HttpStatusCode.BadRequest)
            }
        }    
        [HttpDelete]
        [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
        public async Task<IAsyncResult> DeleteBasket(string userName)
        {
            try
            {
                var basket = await _basketRepository.DeleteBasket(userName);
                return CustomResult("Data Dekete SuccessFully");

            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message ,HttpStatusCode.BadRequest)
            }
        }

    }
}
