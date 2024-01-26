using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.User.cart;
using Setup.ITF.User.wishlist;
using Setup.Request.User.wishlist;
using Setup.Response.User.wishlist;

namespace ZordikWebApi.Controllers.User.wishlist
{
    [Route("api/[action]")]
    [ApiController]
    public class GetWishlistApiController : ControllerBase
    {
        private readonly IGetWishlist _getWishlist;

        public GetWishlistApiController(IGetWishlist getWishlist)
        {
            _getWishlist = getWishlist;
        }


        [HttpPost]
        public CommonResponse<GetWishlistResponse> GetWishlistItem ([FromBody] GetWishlistRequest objRequest)
        {
            return _getWishlist.GetWishlistItem(objRequest);
        }

        
    }
}
