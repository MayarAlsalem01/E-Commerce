﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Dtos.Product
{
    public class ProductRequsetDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        
    }
}
