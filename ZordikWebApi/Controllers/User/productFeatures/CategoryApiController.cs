using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.User.productFeatures;
using Setup.Request.User.productFeatures;
using Setup.Response.User.productFeatures;

namespace ZordikWebApi.Controllers.User.productFeatures
{
    [Route("api/[action]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly ICategory _category;

        public CategoryApiController(ICategory category)
        {
            _category = category;
        }

        [HttpPost]
        public CommonResponse<CategoryResponse> GetAllCategory( [FromBody] CategoryRequest objRequest)
        {
            return _category.GetAllCategory(objRequest);
        }
    }
}
