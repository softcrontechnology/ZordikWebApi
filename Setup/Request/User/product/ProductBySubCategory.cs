using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.product
{
    public class ProductBySubCategoryRequest
    {
        [Required (ErrorMessage = "SubCategory Id required !")]
        public int SubCategoryId { get; set; }
    }
}
