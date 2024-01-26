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
    public class AddressDeleteApiController : ControllerBase
    {
        private readonly IAddressDelete _addressDelete;

        public AddressDeleteApiController(IAddressDelete addressDelete)
        {
            _addressDelete = addressDelete;
        }

        [HttpPost]
        public CommonResponse<AddressDeleteResponse> DeleteAddress([FromBody] AddressDeleteRequest objRequest)
        {
            return _addressDelete.DeleteAddress(objRequest);
        }
    }
}
