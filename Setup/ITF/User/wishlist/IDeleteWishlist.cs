using Setup.DAL;
using Setup.Request.User.wishlist;
using Setup.Response.User.wishlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.User.wishlist
{
    public interface IDeleteWishlist
    {
        CommonResponse<DeleteWishlistResponse> DeleteWishlistItem(DeleteWishlistRequest objRequest);
    }
}
