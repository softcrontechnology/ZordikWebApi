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
    public class AddressUpdateApiController : ControllerBase
    {
        private readonly IAddressUpdate _addressUpdate;

        public AddressUpdateApiController(IAddressUpdate addressUpdate)
        {
            _addressUpdate = addressUpdate;
        }

        [HttpPost]
        public CommonResponse<AddressUpdateResponse> UpdateAddress (AddressUpdateRequest objRequest)
        {
            return _addressUpdate.UpdateAddress(objRequest);
        }
    }
}
