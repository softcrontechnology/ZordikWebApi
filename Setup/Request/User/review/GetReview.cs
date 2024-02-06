using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.review
{
    public class GetReviewRequest
    {
        [Required(ErrorMessage = "Product Id Required !")]
        public int ProductID { get; set; }
    }
}
