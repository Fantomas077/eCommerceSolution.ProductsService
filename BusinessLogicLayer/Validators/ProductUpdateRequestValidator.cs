using BusinessLogicLayer.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Validators
{
    public class ProductUpdateRequestValidator:AbstractValidator<ProductUpdateRequest>
    {
        public ProductUpdateRequestValidator()
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
                .When(x => x.UnitPrice.HasValue);

            //Stock
            RuleFor(x => x.QuantityInStock)
                    .GreaterThanOrEqualTo(0)
                    .When(x => x.QuantityInStock.HasValue);
        }
       

    }
}
