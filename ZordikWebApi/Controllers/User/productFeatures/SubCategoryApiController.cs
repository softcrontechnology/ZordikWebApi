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
    public class SubCategoryApiController : ControllerBase
    {
        private readonly ISubCategory _subCategory;

        public SubCategoryApiController(ISubCategory subCategory)
        {
            _subCategory = subCategory;
        }

        [HttpPost]
        public CommonResponse<SubCategoryResponse> GetSubCategories(SubCategoryRequest objRequest)
        {
            return _subCategory.GetSubCategories(objRequest);
        }
    }
}
