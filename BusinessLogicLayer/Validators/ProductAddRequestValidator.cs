using BusinessLogicLayer.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Validators
{
    public class ProductAddRequestValidator:AbstractValidator<ProductAddRequest>
    {
        public ProductAddRequestValidator()
        {
            //Name
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product Name is required")
            .MaximumLength(100).WithMessage("Max charachters 100");

            //Category
            RuleFor(x => x.Category)
           .NotEmpty().WithMessage("Product Category is required")
           .MaximumLength(100).WithMessage("Max charachters 100");

            //Price
            RuleFor(x => x.UnitPrice)
            .GreaterThan(0)
            .WithMessage("Priice muss be greather than 0");

            //Stock
            RuleFor(x => x.QuantityInStock)
                .GreaterThanOrEqualTo(0)
                .When(x => x.QuantityInStock.HasValue);

        }
    }
}
