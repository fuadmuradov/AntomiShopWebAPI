using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.SliderDTOs
{
    public class SliderPostDto
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public int Discount { get; set; }
    }

    public class SliderPostDtoValidation:AbstractValidator<SliderPostDto>
    {
        public SliderPostDtoValidation()
        {
            RuleFor(x => x.Image).NotNull().NotEmpty();
            RuleFor(x => x.Title).NotNull().NotEmpty();
            RuleFor(x => x.Discount).NotEmpty().NotNull();
        }
    }
}
