using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.wishlist
{
    public class GetWishlistRequest
    {
        [Required(ErrorMessage = "User Id required !")]
        public string? UserId { get; set; }
    }
}
