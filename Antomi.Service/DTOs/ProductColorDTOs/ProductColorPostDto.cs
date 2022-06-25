using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.ProductColorDTOs
{
    public class ProductColorPostDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }
    }

    public class ProductColorPostDtoValidation : AbstractValidator<ProductColorPostDto>
    {
        public ProductColorPostDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(300);
            RuleFor(x => x.Price).NotEmpty().NotNull();
            RuleFor(x => x.Count).NotEmpty().NotNull();
            RuleFor(x => x.ProductName).NotEmpty().NotNull().MaximumLength(150);

        }
    }
}
