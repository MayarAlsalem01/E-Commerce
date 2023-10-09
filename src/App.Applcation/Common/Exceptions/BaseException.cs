using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Common.Exceptions
{
    public abstract class BaseException:Exception
    {
        public BaseException(string message):base(message)
        {
              
        }
        public int Code { get; protected set; }
    }
}
