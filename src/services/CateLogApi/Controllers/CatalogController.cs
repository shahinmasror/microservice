using CateLogApi.Models;
using CateLogApi.Repository;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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

        [HttpGet]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public IActionResult GetById(string id)
        {
            try
            {
                var products = _ProductManeger.GetById(id);
                return CustomResult("data Loded Successfully", products);
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public IActionResult GetByCategory(string Category)
        {
            try
            {
                var products = _ProductManeger.GetByCategory(Category);
                return CustomResult("data Loded Successfully", products);
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public IActionResult CreateProduct([FromBody]Product product)
        {
            try
            {
                product.Id=ObjectId.GenerateNewId().ToString();
                bool isSaved = _ProductManeger.Add(product);
                if (isSaved)
                {
                    return CustomResult("Save SuccessFully", product.Id);
                }
                else {

                    return CustomResult("Product Not Saved",product,HttpStatusCode.BadRequest);
                        }
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                if(string.IsNullOrEmpty(product.Id)){
                    return CustomResult("Product Id Not  Found", product, HttpStatusCode.NotFound);

                }
                bool isUpdate = _ProductManeger.Update(product.Id,product);
                if (isUpdate)
                {
                    return CustomResult("Update SuccessFully", product.Id);
                }
                else
                {

                    return CustomResult("Product Modified Faild", product, HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public IActionResult DeleteProduct(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return CustomResult("Product Id Not  Found", HttpStatusCode.NotFound);

                }
                bool isDelete = _ProductManeger.Delete(id);
                if (isDelete)
                {
                    return CustomResult("Delete SuccessFully");
                }
                else
                {

                    return CustomResult("Product delete Faild", HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }


    }
}
