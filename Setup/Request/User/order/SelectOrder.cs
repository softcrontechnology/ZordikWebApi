using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.order
{
    public class SelectOrderRequest
    {
        [Required (ErrorMessage = "User Id Required !")]
        public int UserId { get; set; }
    }
}
