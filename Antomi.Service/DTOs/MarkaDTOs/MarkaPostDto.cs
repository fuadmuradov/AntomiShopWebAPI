using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.MarkaDTOs
{
    public class MarkaPostDto
    {
        public string Name { get; set; }
    }

    public class MarkaPostDtoValidation : AbstractValidator<MarkaPostDto>
    {
        public MarkaPostDtoValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(250);
        }
    }
}
