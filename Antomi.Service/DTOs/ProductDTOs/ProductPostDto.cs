using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.ProductDTOs
{
    public class ProductPostDto
    {
        public string Model { get; set; }
        public string Description { get; set; }
        public int MarkaId { get; set; }
        public int SubCategoryId { get; set; }
    }
    public class ProductPostDtoValidation : AbstractValidator<ProductPostDto>
    {
        public ProductPostDtoValidation()
        {
            RuleFor(x => x.Model).NotEmpty().NotNull().MaximumLength(300);
            RuleFor(x => x.Description).NotEmpty().NotNull().MaximumLength(2500);
            RuleFor(x => x.MarkaId).NotEmpty().NotNull();
            RuleFor(x => x.SubCategoryId).NotEmpty().NotNull();

        }
    }

}
