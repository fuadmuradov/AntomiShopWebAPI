using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.SubCategoryToMarkaDTOs
{
    public class SubCategoryMarkaPostDto
    {
        public int SubCategoryId { get; set; }
        public int MarkaId { get; set; }
   
    }

    public class SubCategoryMarkaPostDtoValidation : AbstractValidator<SubCategoryMarkaPostDto>
    {
        public SubCategoryMarkaPostDtoValidation()
        {
            RuleFor(x => x.SubCategoryId).NotEmpty().NotNull();
            RuleFor(x => x.MarkaId).NotEmpty().NotNull();


        }
    }


}
