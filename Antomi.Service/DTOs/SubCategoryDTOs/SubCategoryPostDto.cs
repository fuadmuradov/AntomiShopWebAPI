using Antomi.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.SubCategoryDTOs
{
    public class SubCategoryPostDto
    {
        public string Name { get; set; }
    }

    public class SubCategoryPostDtoValidation : AbstractValidator<SubCategory>
    {
        public SubCategoryPostDtoValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(250);
        }
    }
}
