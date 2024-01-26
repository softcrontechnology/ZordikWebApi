using Setup.DAL;
using Setup.Request.User.review;
using Setup.Response.User.review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.User.review
{
    public interface IGetReview
    {
        CommonResponse<GetReviewResponse> GetProductReview(GetReviewRequest objRequest);
    }
}
