using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.auth
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email Required")]
        [MaxLength(50, ErrorMessage = "Email Max Length is 50")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [MaxLength(50, ErrorMessage = "Password Max Length is 50")]
        public string? PassWord { get; set; }

        public string? SessionId { get; set; }
    }
}
