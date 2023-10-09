using App.Applcation.Dtos;
using App.Applcation.Dtos.Pagination;
using App.Applcation.Dtos.Product;
using App.Applcation.Dtos.Response.Common;
using App.Applcation.Features.Product.Commands.CreateProduct;
using App.Applcation.Features.Product.Commands.DeleteProduct;
using App.Applcation.Features.Product.Commands.UpdateProduct;
using App.Applcation.Features.Product.Queries;
using App.Applcation.Features.Product.Queries.GetAllProducts;
using App.Applcation.Features.Product.Queries.GetPaginatedProduct;
using App.Applcation.Interfaces.IServices;
using App.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
       
        
        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            
        }
        [HttpPost("create")]
        public async Task<IActionResult>Create(IFormFile image, [FromForm]ProductRequsetDto dto)
        {
                var command = _mapper.Map<CreateProductCommand>(dto);

            if(image != null && image.Length>0)
            {
                var imageData = await ConvertToBytes(image);
                command.Image=imageData;
            }
             var product=   await _mediator.Send(command);
            var result = ResponseApi<ProductResponseDto>.Response(product, "sucsess",201);
            return  CreatedAtAction(nameof(GetProductById), new { id=product.Id },result);
           
        }




        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteProductCommand command)
        {
            
            var product = await _mediator.Send(command);
           
            var result= ResponseApi<ProductResponseDto>.Response(product,"sucsess",200);
            return Ok(result);
        }


        [HttpPut("{Id}/update")]
        public async Task<IActionResult>Update(string Id, IFormFile Image, [FromForm] ProductRequsetDto dto)
        {
            var command = _mapper.Map<UpdateProductCommand>(dto);
            command.Id = Guid.Parse(Id);
            var imageData = await ConvertToBytes(Image);
            command.Image=imageData;  
            
            var product = await _mediator.Send(command);
            var response = ResponseApi<ProductResponseDto>.Response( product,"sucsess",200);
            return Ok(response);

        }


       
        [HttpGet("id")]
        public async Task<IActionResult> GetProductById([FromQuery]Guid id)
        {
            
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            var response = ResponseApi<ProductResponseDto>.Response( product, "sucsess",200);
            return Ok(response);
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetPaginatedEntities([FromQuery] PaginationRequestDto dto, CancellationToken cancellationToken)
        {
            
            
            var query = new GetPaginatedProductQuery(dto);
            var result =await _mediator.Send(query,cancellationToken);
            
            return Ok(result);
        }
        private bool CheckImage(IFormFile image)
        {
            return true;
        }

        private async Task<byte[]> ConvertToBytes(IFormFile image)
        {
            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
   
}
