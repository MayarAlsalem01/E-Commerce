using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Dtos.Response.Common
{
    public class EntityErrorResponse: BaseErrorResponse
    {
       
        public EntityErrorResponse(int code,object errors):base(code)
        {
            this.errors=errors;
        }
        
    }
}
