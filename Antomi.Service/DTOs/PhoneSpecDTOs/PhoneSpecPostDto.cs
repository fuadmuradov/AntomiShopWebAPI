using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.PhoneSpecDTOs
{
    public class PhoneSpecPostDto
    {
        public int RAM { get; set; }
        public string Storage { get; set; }
        public string DisplayType { get; set; }
        public string OS { get; set; }
        public string MainCamera { get; set; }
        public string SelfieCamera { get; set; }
        public string Processor { get; set; }
        public int ProductId { get; set; }
    }
    public class PhoneSpecPostDtoValidation : AbstractValidator<PhoneSpecPostDto>
    {
        public PhoneSpecPostDtoValidation()
        {
            RuleFor(x => x.RAM).NotEmpty().NotNull();
            RuleFor(x => x.Storage).NotEmpty().NotNull().MaximumLength(150);
            RuleFor(x => x.DisplayType).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(x => x.OS).NotEmpty().NotNull().MaximumLength(150);
            RuleFor(x => x.MainCamera).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(x => x.SelfieCamera).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(x => x.Processor).NotEmpty().NotNull().MaximumLength(150);
            RuleFor(x => x.ProductId).NotEmpty().NotNull();

        }
    }
}
