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
    public class AddressSelectApiController : ControllerBase
    {
        private readonly IAddressSelect _addressSelect;

        public AddressSelectApiController(IAddressSelect addressSelect)
        {
            _addressSelect = addressSelect;
        }

        [HttpPost]
        public CommonResponse<AddressSelectResponse> GetAddress([FromBody] AddressSelectRequest objRequest)
        {
            return _addressSelect.GetAddress(objRequest);
        }
    }
}
