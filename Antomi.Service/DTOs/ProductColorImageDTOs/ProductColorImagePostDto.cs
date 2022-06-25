using Antomi.Service.DTOs.ProductDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.ProductColorImageDTOs
{
    public class ProductColorImagePostDto
    {
        public string Image { get; set; }
        public bool IsMain { get; set; }
        public string ProductColorName { get; set; }
    }

    public class ProductColorImagePostDtoValidation : AbstractValidator<ProductColorImagePostDto>
    {
        public ProductColorImagePostDtoValidation()
        {
            RuleFor(x => x.Image).NotEmpty().NotNull();
            RuleFor(x => x.ProductColorName).NotEmpty().NotNull();
        }
    }
}
