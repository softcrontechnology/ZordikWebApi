using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.cart
{
    public class DeleteCartRequest
    {
        [Required(ErrorMessage = "User Id Required !")]
        public int CartId { get; set; }
    }
}
