using App.Domain.Common;
using App.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Product:BaseAuditableEntity
    {
        public Product()
        {
           
        }
        public Product(string name, decimal price, byte[] image)
        {
            Name = name;
            Price = price;
            Image = image;
        }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
    }
}
