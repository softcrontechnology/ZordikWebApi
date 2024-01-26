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
    public class ProductByTagApiController : ControllerBase
    {
        private readonly IProductByTag _productByTag;

        public ProductByTagApiController(IProductByTag productByTag)
        {
            _productByTag = productByTag;
        }

        [HttpPost]
        public CommonResponse<ProductByTagResponse> GetProductByTag([FromBody] ProductByTagRequest objRequest)
        {
          return _productByTag.GetProductByTag(objRequest);
        }
    }
}
