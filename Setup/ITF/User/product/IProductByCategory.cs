using Setup.DAL;
using Setup.Request.User.product;
using Setup.Response.User.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.ITF.User.product
{
    public interface IproductByCategory
    {
        CommonResponse<ProductByCategoryResponse> GetProductByCategory(ProductByCategoryRequest objRequest);
    }
}
