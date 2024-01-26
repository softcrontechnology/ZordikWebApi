using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.User.product;
using Setup.Request.User.product;
using Setup.Response.User.product;

namespace ZordikWebApi.Controllers.User.product
{
    [Route("api/[action]")]
    [ApiController]
    public class ProductByIdApiController : ControllerBase
    {
        private readonly IProductById _productById;

        public ProductByIdApiController(IProductById productById)
        {
            _productById = productById;
        }

        [HttpPost]
        public CommonResponse<ProductByIdResponse> GetProductById( [FromBody] ProductByIdRequest objrequest)
        {
            return _productById.GetProductById(objrequest);
        }
    }
}
