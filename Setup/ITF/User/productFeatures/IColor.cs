using Setup.DAL;
using Setup.Request.User.productFeatures;
using Setup.Response.User.productFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.User.productFeatures
{
    public interface IColor
    {
        CommonResponse<ColorResponse> GetAllColors(ColorRequest objRequest);
    }
}
