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
    public class ProductBySubCategoryApiController : ControllerBase
    {
        private readonly IProductBySubcategory _productBySubcategory;

        public ProductBySubCategoryApiController(IProductBySubcategory productBySubcategory)
        {
            _productBySubcategory = productBySubcategory;
        }

        [HttpPost]
        public CommonResponse<ProductBySubCategoryResponse> GetProductBySubCategory ( [FromBody] ProductBySubCategoryRequest objRequest)
        {
            return _productBySubcategory.GetProductBySubCategory (objRequest);
        }
    }
}
