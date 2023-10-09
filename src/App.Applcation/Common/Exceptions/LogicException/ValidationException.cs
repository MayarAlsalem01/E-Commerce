using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Common.Exceptions.LogicException
{
    public class ValidationException:BaseException
    {
        public ValidationResult Result { get; set; }
        public ValidationException(string message, ValidationResult result) :base(message)
        {
            Result = result; 
        }
    }
}
