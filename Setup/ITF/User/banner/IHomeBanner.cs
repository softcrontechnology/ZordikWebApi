using Setup.DAL;
using Setup.Request.User.banner;
using Setup.Response.User.banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.User.banner
{
    public interface IHomeBanner
    {
        CommonResponse<GetHomeBannerResponse> GetHomeBanner(GetHomeBannerRequest objRequest);
    }
}
