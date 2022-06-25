using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.SpecificationDTOs
{
    public class SpecificationPostDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
    }

    public class SpecificationPostDtoValidation : AbstractValidator<SpecificationPostDto>
    {
        public SpecificationPostDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(150);
            RuleFor(x => x.Description).NotEmpty().NotNull().MaximumLength(1000);
            RuleFor(x => x.ProductId).NotEmpty().NotNull();

        }
    }
}
