using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.cart
{
    public class AddCartRequest
    {
        [Required(ErrorMessage = "Product id Required!")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Variation id Required !")]
        public int VariationId { get; set; }

        [Required(ErrorMessage = "Product Qty Required !")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "User Id Required !")]
        public string? UserId { get; set; }
    }
}
