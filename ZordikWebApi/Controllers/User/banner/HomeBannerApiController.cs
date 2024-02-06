using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.User.banner;
using Setup.Request.User.banner;
using Setup.Response.User.banner;

namespace ZordikWebApi.Controllers.User.banner
{
    [Route("api/[action]")]
    [ApiController]
    public class HomeBannerApiController : ControllerBase
    {
        private readonly IHomeBanner _homeBanner;

        public HomeBannerApiController(IHomeBanner homeBanner)
        {
            _homeBanner = homeBanner;
        }

        [HttpPost]
        public CommonResponse<GetHomeBannerResponse> GetHomeBanner([FromBody] GetHomeBannerRequest objRequest)
        {
            return _homeBanner.GetHomeBanner(objRequest);
        }     
        


    }
}
 