using Microsoft.Extensions.Configuration;
using Setup.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.cart
{
    public class GetCartRequest
    {
        [Required(ErrorMessage = "UserId Required !")]
        public int UserId { get; set; }
    }
}
