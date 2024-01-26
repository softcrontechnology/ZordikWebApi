using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.address
{
    public class AddressDeleteRequest
    {
        [Required (ErrorMessage = "Address Id Required !") ]
        public int AddressId { get; set; }
    }
}
