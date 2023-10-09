using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Dtos.Response.Common
{
    public class EntityErrorResponse: BaseErroResponse
    {
        public EntityErrorResponse(
            int statusCode, Dictionary<string, List<string>> errors
            ) : base(statusCode)
        {
            this.errors = errors;
        }
        public EntityErrorResponse(int code):base(code)
        {

        }
        public Dictionary<string, List<string>> errors { get; set; } = new();
    }
}
