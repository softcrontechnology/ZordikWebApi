using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.productFeatures
{
    public class SubCategoryRequest
    {
        [Required(ErrorMessage = "Category ID Required !")]
        public int CategoryId { get; set; }
    }
}
