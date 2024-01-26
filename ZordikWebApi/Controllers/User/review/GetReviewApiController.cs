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
    public class GetReviewApiController : ControllerBase
    {
        private readonly IGetReview _getReview;

        public GetReviewApiController(IGetReview getReview)
        {
            _getReview = getReview;
        }

        [HttpPost]
        public CommonResponse<GetReviewResponse> GetProductReview([FromBody] GetReviewRequest objRequest)
        {
            return _getReview.GetProductReview(objRequest);
        }
    }
}
