using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.NotebookSpecDTOs
{
    public class NotebookSpecPostDto
    {
        public int RAM { get; set; }
        public int Storage { get; set; }
        public string Graphics { get; set; }
        public string OS { get; set; }
        public string Processor { get; set; }
        public int ProductId { get; set; }
    }

    public class NotebookSpecPostDtoValidation : AbstractValidator<NotebookSpecPostDto>
    {
        public NotebookSpecPostDtoValidation()
        {
            RuleFor(x => x.RAM).NotEmpty().NotNull();
            RuleFor(x => x.Storage).NotEmpty().NotNull();
            RuleFor(x => x.Graphics).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(x => x.OS).NotEmpty().NotNull().MaximumLength(150);
            RuleFor(x => x.Processor).NotEmpty().NotNull().MaximumLength(150);
            RuleFor(x => x.ProductId).NotEmpty().NotNull();

        }
    }
}
