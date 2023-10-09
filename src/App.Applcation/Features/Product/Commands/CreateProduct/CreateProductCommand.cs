using App.Applcation.Common.Exceptions.DomainException;
using App.Applcation.Dtos.Product;
using App.Applcation.Interfaces.IRepositories;
using App.Applcation.Interfaces.IRepositories.Common;
using MediatR;
using ProductTable = App.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using App.Domain.Events;
using App.Domain.Common.Interfaces;

namespace App.Applcation.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommand:BaseProductCommand
    {
       
        
       
       
    }
    public class CreateProductCommandHandler : BaseCommandHandler<ProductTable>,IRequestHandler<CreateProductCommand, ProductResponseDto>
    {
      
        public CreateProductCommandHandler(
            IMediator mediator,
            IGenericRepository<ProductTable> repository,
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IDomainEventDispatcher dispatcher):base(
                mediator,
                mapper
                ,unitOfWork,
                repository
                ,dispatcher)
        {
          
        }



        public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
         
            var validations=new CreateProductCommandValidator();
            var result = validations.Validate(request);
            
            if (!result.IsValid) 
            { 
                throw new EntityException("bad entity requsted", result); 
            }
            var product = _mapper.Map<ProductTable>(request);
            product.AddDomainEvent(new ProductCreateEvent(product));
            await _dispatcher.DispatchAndClearEvents(new ProductCreateEvent(product));
            await _unitOfWork.Repository<ProductTable>().AddAsync(product,cancellationToken);
            await _unitOfWork.Save(cancellationToken);
            return _mapper.Map<ProductResponseDto>(product);

        }
    }
}
