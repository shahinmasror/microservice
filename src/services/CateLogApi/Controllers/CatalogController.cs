using CateLogApi.Models;
using CateLogApi.Repository;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CateLogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : BaseController
    {

         ProductManeger _ProductManeger;
        public CatalogController(ProductManeger productManeger)
        { 
        _ProductManeger = productManeger;
        }
        [HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<Product>),(int)HttpStatusCode.OK)]
        [ResponseCache(Duration =30)]
        public IActionResult GetALLProdduct()
        {
            try
            {
                var products = _ProductManeger.GetAll();
                return CustomResult("data Loded Successfully", products);
            }
            catch (Exception ex)
            {

               return CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
        }
       

    }
}
