using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.auth
{
    public class CreateAccountRequest
    {
        [Required(ErrorMessage = "Name Required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email ID Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone Number Required")]
        public int Phone { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string? Password { get; set; }

        public int ReferralCode { get; set; }

        public int SponsoredBy { get; set; }
    }
}
