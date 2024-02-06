using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.Request.User.review
{
    public class AddReviewRequest
    {
        [Required(ErrorMessage = "User Id Required !")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Product Id Required !")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Review Required !")]
        public string? Review { get; set; }
    }
}
