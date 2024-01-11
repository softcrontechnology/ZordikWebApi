using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup.DAL
{
    public class CommonResponse<T>
    {
        public List<T>? responseObject { get; set; }

        public int ResponseCode { get; set; }

        public string? ResponseMessage { get; set; }

        public string? ResponseData { get; set;}

        public string? Token { get; set; }
    }
}
