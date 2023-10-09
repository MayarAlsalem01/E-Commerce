using App.Applcation.Dtos;
using App.Applcation.Dtos.Product;
using App.Applcation.Interfaces.IRepositories;
using App.Applcation.Interfaces.IRepositories.Common;
using App.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastrcuture.Persistence.Repositories
{
    public class ProductRepository :  IProductRepository
    {
        private readonly IGenericRepository<App.Domain.Entities.Product> _repository;
        private readonly IMapper _mapper;

        public ProductRepository(IGenericRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<Product>> GetProductByPriceAsync(decimal price)
        {
            throw new NotImplementedException();
        }

       
    }
}
