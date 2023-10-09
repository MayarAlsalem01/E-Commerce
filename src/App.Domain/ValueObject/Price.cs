using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ValueObject
{
    public record Price(Guid Id,string Currncy,decimal amount);
    
}
