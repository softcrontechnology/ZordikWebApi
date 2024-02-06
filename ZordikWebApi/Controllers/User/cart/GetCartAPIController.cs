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
    public class GetCartAPIController : Controller
    {
        private readonly IGetCart _getCart;

        public GetCartAPIController(IGetCart getCart)
        {
            _getCart = getCart;
        }


        [HttpPost]
        public CommonResponse<GetCartResponse> GetUserCartItems([FromBody] GetCartRequest objRequest)
        {
            return _getCart.GetUserCartItems(objRequest);
        }
    }
}
