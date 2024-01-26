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
    public class CreateAccountAPIController : Controller
    {
        private readonly ICreateAccount _createAccount;

        public CreateAccountAPIController(ICreateAccount createAccount)
        {
            _createAccount = createAccount;
        }

        [HttpPost]
        public CommonResponse<CreateAccountResponse> CreateUserAccount([FromBody] CreateAccountRequest objRequest)
        {
            return _createAccount.CreateUserAccount(objRequest);
        }
    }
}
