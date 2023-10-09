using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Common.Exceptions.LogicException
{
    public sealed class NotFoundException:BaseException
    {
        public NotFoundException(string message=""):base(message)
        {
            Code = 404;
        }
    }
}
