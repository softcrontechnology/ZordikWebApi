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
    public class AllProductApiController : ControllerBase
    {
        private readonly IAllProduct _allProduct;

        public AllProductApiController(IAllProduct allProduct)
        {
            _allProduct = allProduct;
        }

        [HttpPost]
        public CommonResponse<AllProductResponse> GetAllProduct([FromBody] AllProductRequest objRequest)
        {
            return _allProduct.GetAllProduct(objRequest);
        }
    }
}
