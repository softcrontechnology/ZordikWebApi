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
    public class TestimonialApiController : ControllerBase
    {
        private readonly ITestimonial _testimonial;

        public TestimonialApiController(ITestimonial testimonial)
        {
            _testimonial = testimonial;
        }

        [HttpPost]
        public CommonResponse<TestimonialResponse> GetTestimonials([FromBody] TestimonialRequest ojRequest)
        {
            return _testimonial.GetTestimonials(ojRequest);
        }
    }
}
