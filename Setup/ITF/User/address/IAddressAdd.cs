using Setup.DAL;
using Setup.Request.User.address;
using Setup.Response.User.address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.User.address
{
    public interface IAddressAdd
    {
        CommonResponse<AddressAddResponse> AddAddress(AddressAddRequest objRequest);
    }
}
