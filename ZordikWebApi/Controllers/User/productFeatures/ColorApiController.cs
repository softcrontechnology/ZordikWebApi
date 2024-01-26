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
    public class ColorApiController : ControllerBase
    {
        private readonly IColor _color;

        public ColorApiController(IColor color)
        {
            _color = color;
        }

        [HttpPost]
        public CommonResponse<ColorResponse> GetAllColors([FromBody] ColorRequest objResponse)
        {
            return _color.GetAllColors(objResponse);
        }
    }
}
