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
    public class ProductByCategoryApiController : ControllerBase
    {
        private readonly IproductByCategory _productByCategory;

        public ProductByCategoryApiController(IproductByCategory iproductByCategory)
        {
            _productByCategory = iproductByCategory;
        }

        [HttpPost]
        public CommonResponse<ProductByCategoryResponse> GetProductByCategory([FromBody] ProductByCategoryRequest objrequest)
        {
            return _productByCategory.GetProductByCategory(objrequest);
        }
    }
}
