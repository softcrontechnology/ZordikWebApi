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
    public class CreateOrderApiController : ControllerBase
    {
        private readonly ICreateOrder _createOrder;

        public CreateOrderApiController (ICreateOrder createOrder)
        {
            _createOrder = createOrder;
        }

        [HttpPost]
        public CommonResponse<CreateOrderResponse> CreateUserOrder ([FromBody] CreateOrderRequest objRequest)
        {
            return _createOrder.CreateUserOrder(objRequest);
        }


        [HttpPost]
        public CommonResponse<OrderItemResponse> InsertOrderItem([FromBody] OrderItemRequest Request)
        {
            return _createOrder.InsertOrderItem(Request);
        }

    }
}
