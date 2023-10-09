using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Dtos.Response.Common
{
    public class BaseErroResponse:BaseResponse
    {
        public BaseErroResponse(int statusCode) : base(statusCode)
        {

        }
    }
}
