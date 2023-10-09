using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Dtos.Response.Common
{
    public sealed class LogicErrorResponse : BaseErrorResponse
    {
        public LogicErrorResponse(int statusCode,string message) : base(statusCode)
        {
            this.message = message;
        }
        public string message { get; private set; }
    }
}
