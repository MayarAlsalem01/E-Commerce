using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Dtos.Response.Common
{
    public class ServerErrorRespose:BaseErrorResponse
    {
        public ServerErrorRespose(string message):base(500)
        {
                Messagge=message;
        }
        public string Messagge { get; set; }
    }
}
