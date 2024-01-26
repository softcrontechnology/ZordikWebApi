using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.User.cart;
using Setup.Request.User.cart;
using Setup.Response.User.cart;

namespace ZordikWebApi.Controllers.User.cart
{
    [Route("api/[action]")]
    [ApiController]
    public class UpdateCartAPIController : Controller
    {
        private readonly IUpdateCart _updateCart;

        public UpdateCartAPIController (IUpdateCart updateCart)
        {
            _updateCart = updateCart;
        }

        [HttpPost]
        public CommonResponse<UpdateCartResponse> UpdateCartQty([FromBody] UpdateCartRequest objRequest)
        {
            return _updateCart.UpdateCartQty(objRequest);
        }
    }
}
