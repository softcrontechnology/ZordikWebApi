using Setup.DAL;
using Setup.Request.User.order;
using Setup.Response.User.order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.User.order
{
    public interface ISelectOrder
    {
        CommonResponse<SelectOrderResponse> GetUserOrders(SelectOrderRequest objRequest);
    }
}
