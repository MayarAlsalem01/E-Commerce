using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Common.Exceptions.DomainException
{
    public class EntityException:BaseException
    {
       
        public EntityException(string message,ValidationResult result) :base(message)
        {
            Result = result;
                   
            
        }
        public ValidationResult Result { get;private set; }

    }
}
