using App.Applcation.Dtos;
using App.Applcation.Dtos.Product;
using App.Applcation.Interfaces.IRepositories.Common;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Interfaces.IRepositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductByPriceAsync(decimal price);
       
    }
}
