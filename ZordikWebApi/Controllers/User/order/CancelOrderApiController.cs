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
    public class CancelOrderApiController : ControllerBase
    {
        private readonly ICancelOrder _cancelOrder;

        public CancelOrderApiController(ICancelOrder cancelOrder)
        {
            _cancelOrder = cancelOrder;
        }

        [HttpPost]
        public CommonResponse<CancelOrderResponse> OrderCancel([FromBody] CancelOrderRequest objRequest)
        {
            return _cancelOrder.OrderCancel(objRequest);
        }
    }
}
