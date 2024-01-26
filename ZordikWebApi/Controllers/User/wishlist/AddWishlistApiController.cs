using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.User.wishlist;
using Setup.Request.User.wishlist;
using Setup.Response.User.wishlist;

namespace ZordikWebApi.Controllers.User.wishlist
{
    [Route("api/[action]")]
    [ApiController]
    public class AddWishlistApiController : ControllerBase
    {
        private readonly IAddWishlist _addWishlist;
        
        public AddWishlistApiController(IAddWishlist addWishlist)
        {
            _addWishlist = addWishlist;
        }

        [HttpPost]
        public CommonResponse<AddWishlistResponse> AddToWishlist([FromBody] AddWishlistRequest objRequest)
        {
            return _addWishlist.AddToWishlist(objRequest);
        }
    }
}
