using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.User.cart;
using Setup.Request.User.cart;
using Setup.Response.User.cart;

namespace ZordikWebApi.Controllers.User.cart
{
    [Authorize]
    [Route("api/[action]")]
    [ApiController]
    public class DeleteCartAPIController : Controller
    {
        private readonly IDeleteCart _deleteCart;

        public DeleteCartAPIController(IDeleteCart deleteCart)
        {
            _deleteCart = deleteCart;
        }

        [HttpPost]
        public CommonResponse<DeleteCartResponse> DeleteCartItem([FromBody] DeleteCartRequest objRequest)
        {
            return _deleteCart.DeleteCartItem(objRequest);
        }
    }
}
