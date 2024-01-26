using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.address
{
    public class AddressAddRequest
    {
        [Required (ErrorMessage = "User Id Required !")]
        public int UserID { get; set; }


        [Required (ErrorMessage = "Name Required !")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Phone Number Required !")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must be 10 digits and numeric.")]
        public string? Phone { get; set; }


        public string? HouseNo { get; set; }


        public string? Area { get; set; }

        
        public string? Landmark { get; set; }

        [Required (ErrorMessage = "City Required !")]
        public string? City { get; set; }

        [Required (ErrorMessage = "State Required !")]
        public string? State { get; set; }

        [Required (ErrorMessage = "Country Required !")]
        public string? Country { get; set; }

        [Required (ErrorMessage = "ZipCode Required !")]
        public int ZipCode { get; set;}
    }
}
