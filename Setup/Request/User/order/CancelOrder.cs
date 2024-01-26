using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.order
{
    public class CancelOrderRequest
    {
        [Required (ErrorMessage = "Order Cancel Reason Required !")]
        public string? Reason { get; set; }

        [Required (ErrorMessage = "Order Id Required !")]
        public int OrderId { get; set; }
    }
}
