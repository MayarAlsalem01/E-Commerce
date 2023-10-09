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
        public EntityException(string message=""):base(message)
        {
            
        }
        public EntityException(string message,ValidationResult result) :base(message)
        {
            ErorrsMesage = result.Errors
                    .GroupBy(failure => failure.PropertyName)
                    .ToDictionary(
                        group => group.Key,
                        group => group.Select(failure => failure.ErrorMessage).ToList()
                    );
            
        }
        public Dictionary<string,List<string>> ErorrsMesage { get;private set; }

    }
}
