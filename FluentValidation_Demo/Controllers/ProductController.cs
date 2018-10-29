using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using FluentValidation_Demo.Models;

namespace FluentValidation_Demo.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        [HttpPost]
        public IHttpActionResult AddProduct(Product addProduct)
        {
            try
            {
                if(addProduct != null)
                {
                    return Ok();
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