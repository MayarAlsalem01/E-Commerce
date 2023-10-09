using App.Applcation.Common.Exceptions.LogicException;
using App.Applcation.Dtos.Product;
using App.Applcation.Interfaces.IRepositories.Common;
using App.Domain.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using ProductTable = App.Domain.Entities.Product;

namespace App.Applcation.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand:BaseProductCommand
    {
        
        public Guid Id { get;  set; }
      
        public void SetImageData(byte[] ImageData) { this.Image = ImageData; }


    }
    internal class UpdateProductCommandHandler :BaseCommandHandler<ProductTable>, IRequestHandler<UpdateProductCommand, ProductResponseDto>
    {
        public UpdateProductCommandHandler(
            IMediator mediator,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IGenericRepository<ProductTable> repository,
            IDomainEventDispatcher dispatcher) : base(mediator, mapper, unitOfWork, repository, dispatcher)
        {
        }

        public async Task<ProductResponseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {     
            
                //check if the product existing or not 
                if(!_unitOfWork.Repository<ProductTable>().Any(p => p.Id == request.Id))
                throw new NotFoundException($"the product with id:{request.Id} not found");
            //get prudct 
            var product = await _unitOfWork.Repository<ProductTable>().GetByIdAsync(request.Id);
             _mapper.Map(request,product);
            _unitOfWork.Repository<ProductTable>().Update(product);
            await _unitOfWork.Save(cancellationToken);
            return _mapper.Map<ProductResponseDto>(product);
        }
     
    }
}
