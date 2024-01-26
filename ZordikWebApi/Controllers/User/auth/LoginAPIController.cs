using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.User.auth;
using Setup.Request.User.auth;
using Setup.Response.User.auth;

namespace ZordikWebApi.Controllers.User.auth
{
    [Route("api/[action]")]
    [ApiController]
    public class LoginAPIController : Controller
    {
        private readonly ILogin _login;

        public LoginAPIController(ILogin login)
        {
            _login = login;
        }

        [HttpPost]
        public CommonResponse<LoginResponse> AppLogin([FromBody] LoginRequest objRequest)
        {
            return _login.AppLogin(objRequest);
        }
    }
}
