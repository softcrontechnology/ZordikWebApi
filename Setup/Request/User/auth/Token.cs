using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.auth
{
    public class TokenRequest
    {
        [Required(ErrorMessage = "UserName is Required !")]
        public string? Email { get; set; }
    }
}
