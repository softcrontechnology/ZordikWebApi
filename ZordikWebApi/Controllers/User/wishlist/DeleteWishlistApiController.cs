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
    public class DeleteWishlistApiController : ControllerBase
    {
        private readonly IDeleteWishlist _deleteWishlist;

        public DeleteWishlistApiController(IDeleteWishlist deleteWishlist)
        {
            _deleteWishlist = deleteWishlist;
        }


        [HttpPost]
        public CommonResponse<DeleteWishlistResponse> DeleteWishlistItem([FromBody] DeleteWishlistRequest objRequest)
        {
            return _deleteWishlist.DeleteWishlistItem(objRequest);
        }
    }
}
