using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.wishlist
{
    public class AddWishlistRequest
    {
        [Required(ErrorMessage = "Product Id Required !")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Color Id Required !")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "Variation Id Required !")]
        public int VariationId { get; set; }

        [Required(ErrorMessage = "Qty Required !")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "User Id Required !")]
        public string? UserId { get; set; }

    }
}
