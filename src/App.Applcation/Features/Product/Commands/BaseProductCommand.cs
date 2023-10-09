using App.Applcation.Dtos.Product;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Features.Product.Commands
{
    public class BaseProductCommand:IRequest<ProductResponseDto>
    {
        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }


    }
}
