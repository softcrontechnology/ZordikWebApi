using Microsoft.AspNetCore.Mvc;
using Setup.BL.User.auth;
using Setup.DAL;
using Setup.Request.User.auth;
using Setup.Response.User.auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.User.auth
{
    public interface ICreateAccount
    {
         CommonResponse<CreateAccountResponse> CreateUserAccount([FromBody] CreateAccountRequest objRequest);
    }
}
