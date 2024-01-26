using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.product
{
    public class ProductByTagRequest
    {
        [Required(ErrorMessage = "Product Tag Required !")]
        public string? TagName { get; set; }

        public int Limit { get; set; }
    }
}
