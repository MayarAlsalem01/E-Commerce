using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Dtos.Response.Common.ExceptionsResponse
{
    public class ValidationExceptionResponse : BaseErrorResponse
    {
        public string message { get; set; }
       
        public ValidationExceptionResponse(int statusCode,string message,object errors) : base(statusCode)
        {
            this.message = message;
            this.errors = errors;
        }
    }
}
