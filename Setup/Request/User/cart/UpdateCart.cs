using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.cart
{
    public class UpdateCartRequest
    {
        [Required(ErrorMessage = "Product Qty Required !")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Cart Id Required !")]
        public int CartId { get; set; }
    }
}
