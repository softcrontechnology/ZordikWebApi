using Setup.DAL;
using Setup.Request.User.cart;
using Setup.Response.User.cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.User.cart
{
    public interface IDeleteCart
    {
        CommonResponse<DeleteCartItemResponse> DeleteCartItem(DeleteCartItemRequest objRequest );
        CommonResponse<ClearAllCartResponse> ClearCartData(ClearAllCartRequest Request );
    }
}

