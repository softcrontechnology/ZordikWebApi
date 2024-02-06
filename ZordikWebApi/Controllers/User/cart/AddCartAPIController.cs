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
    public class AddCartAPIController : Controller
    {
        private readonly IAddCart _addCart;

        public AddCartAPIController(IAddCart addCart)
        {
            _addCart = addCart;
        }

        [HttpPost]
        public CommonResponse<AddCartResponse> AddToCart([FromBody] AddCartRequest objRequest)
        {
            return _addCart.AddToCart(objRequest);
        }
    }
}
