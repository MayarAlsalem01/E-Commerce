using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Dtos.Response.Common
{
    public class BaseErrorResponse:BaseResponse
    {
        public BaseErrorResponse(int statusCode) : base(statusCode)
        {

        }
        public object Errors { get; set; }
    }
}
