using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.User.address;
using Setup.Request.User.address;
using Setup.Response.User.address;

namespace ZordikWebApi.Controllers.User.address
{
    [Route("api/[action]")]
    [ApiController]
    public class AddressAddApiController : ControllerBase
    {
        private readonly IAddressAdd _addressAdd;

        public AddressAddApiController (IAddressAdd addressAdd)
        {
            _addressAdd = addressAdd;
        }

        [HttpPost]
        public CommonResponse<AddressAddResponse> AddAddress( [FromBody] AddressAddRequest objRequest)
        {
            return _addressAdd.AddAddress(objRequest);
        }
    }
}
