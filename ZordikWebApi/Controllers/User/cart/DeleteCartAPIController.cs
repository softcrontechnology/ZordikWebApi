using Microsoft.AspNetCore.Authorization;
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
    public class DeleteCartAPIController : Controller
    {
        private readonly IDeleteCart _deleteCart;

        public DeleteCartAPIController(IDeleteCart deleteCart)
        {
            _deleteCart = deleteCart;
        }

        [HttpPost]
        public CommonResponse<DeleteCartItemResponse> DeleteCartItem([FromBody] DeleteCartItemRequest objRequest)
        {
            return _deleteCart.DeleteCartItem(objRequest);
        }


        [HttpPost]
        public CommonResponse<ClearAllCartResponse> ClearCartData([FromBody] ClearAllCartRequest Request)
        {
            return _deleteCart.ClearCartData(Request);
        }
    }
}
