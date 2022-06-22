using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.TestimonialDTOs
{
    public class TestimonialPostDto
    {
        public string Image { get; set; }
        public string Fullname { get; set; }
        public string Jobname { get; set; }
        public string Description { get; set; }
    }

    public class TestimonialPostDtoValidation : AbstractValidator<TestimonialPostDto>
    {
        public TestimonialPostDtoValidation()
        {
            RuleFor(x => x.Image).NotNull().NotEmpty();
            RuleFor(x => x.Fullname).NotNull().NotEmpty().MaximumLength(120);
            RuleFor(x => x.Jobname).NotNull().NotEmpty().MaximumLength(150);
            RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(3000);

        }
    }

}
