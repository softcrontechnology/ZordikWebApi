using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.User.review;
using Setup.Request.User.review;
using Setup.Response.User.review;

namespace ZordikWebApi.Controllers.User.review
{
    [Route("api/[action]")]
    [ApiController]
    public class AddReviewApiController : ControllerBase
    {
        private readonly IAddReview _addReview;

        public AddReviewApiController(IAddReview addReview)
        {
            _addReview = addReview;
        }

        [HttpPost]
        public CommonResponse<AddReviewResponse> AddProductreview([FromBody] AddReviewRequest objRequest)
        {
            return _addReview.AddProductReview(objRequest);
        }
    }
}
