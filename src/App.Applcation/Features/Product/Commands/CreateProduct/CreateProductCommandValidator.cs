using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} this Field is requierd")
                .MaximumLength(100)
                .WithMessage("{PropertyName} the max length of the field is 100");

            RuleFor(c => c.Price)
                .GreaterThanOrEqualTo(1)
                .WithMessage("{PropertyName} this feild cannot be nagitve")
                .NotNull()
                .WithMessage("{PropertyName} this field is required")
                .NotEmpty()
                .WithMessage("asd");

           
        }
    }
}
