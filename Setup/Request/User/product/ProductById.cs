using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.product
{
    public class ProductByIdRequest
    {
        [Required(ErrorMessage = "Product Id Required !")]
        public int ProductId { get; set; }
    }
}
