using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.CategoryDTOs
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
    }

    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(200);
        }
    }
}
