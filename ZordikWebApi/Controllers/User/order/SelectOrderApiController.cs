using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.User.order;
using Setup.Request.User.order;
using Setup.Response.User.order;

namespace ZordikWebApi.Controllers.User.order
{
    [Route("api/[action]")]
    [ApiController]
    public class SelectOrderApiController : ControllerBase
    {
        private readonly ISelectOrder _selectOrder;

        public SelectOrderApiController (ISelectOrder selectOrder)
        {
            _selectOrder = selectOrder;
        }

        [HttpPost]
        public CommonResponse<SelectOrderResponse> GetUserOrders( [FromBody] SelectOrderRequest objRequest)
        {
            return _selectOrder.GetUserOrders(objRequest);
        }
    }
}
