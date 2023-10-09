using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Dtos.Response
{
    public class BaseResponse
    {
        public BaseResponse(int statusCode)
        {
            StatusCode = statusCode;
        }
        public int StatusCode { get; set; }
    }
}
