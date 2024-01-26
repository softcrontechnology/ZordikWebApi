using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.product
{
    public class ProductByCategoryRequest
    {
        [Required (ErrorMessage = "Category Id Required !")]
        public int CategoryId { get; set; }
    }
}
