using FluentValidation_Demo.Models;
using System;
using System.Web.Http;

namespace FluentValidation_Demo.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        [HttpPost]
        [Route("NewProduct")]
        public IHttpActionResult AddProduct(Product addProduct)
        {
            try
            {
                if(addProduct != null)
                {
                    if(ModelState.IsValid)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                    
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}