using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Common.Exceptions.Common
{
    public class ServerException : BaseException
    {
        public ServerException(string message) : base(message)
        {
        }
    }
}
