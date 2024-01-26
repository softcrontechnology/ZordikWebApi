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
    public class SizeApiController : ControllerBase
    {
        private readonly ISize _size;

        public SizeApiController(ISize size)
        {
            _size = size;
        }

        [HttpPost]
        public CommonResponse<SizeResponse> GetAllSizes( [FromBody] SizeRequest objrequest)
        {
            return _size.GetAllSizes(objrequest);
        }
    }
}
