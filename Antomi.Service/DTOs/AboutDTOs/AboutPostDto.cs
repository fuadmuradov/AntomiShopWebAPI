using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.AboutDTOs
{
    public class AboutPostDto
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Signature { get; set; }
    }

    public class AboutPostDtoValidation : AbstractValidator<AboutPostDto>
    {
        public AboutPostDtoValidation()
        {
            RuleFor(x => x.Image).NotEmpty().NotNull();
            RuleFor(x => x.Title).NotEmpty().NotNull().MaximumLength(250);
            RuleFor(x => x.Description).NotEmpty().NotNull().MaximumLength(3000);
            RuleFor(x => x.Signature).NotEmpty().NotNull();

        }
    }


}
