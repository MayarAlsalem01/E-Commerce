using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            //check if the id guid or not 
            RuleFor(p => p.id)
                .Must(ValidGuid)
                .WithMessage("errpr");
                
        }
        private bool ValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
       
    }
}
