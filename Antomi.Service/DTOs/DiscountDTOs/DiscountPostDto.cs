using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.DiscountDTOs
{
    public class DiscountPostDto
    {
        public int Percent { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProductColorId { get; set; }
        public bool DealofMonth { get; set; }
    }

    public class DiscountPostDtoValidation : AbstractValidator<DiscountPostDto>
    {
        public DiscountPostDtoValidation()
        {
            RuleFor(x => x.Percent).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty().NotNull();
            RuleFor(x => x.EndDate).NotEmpty().NotNull();
            RuleFor(x => x.ProductColorId).NotEmpty().NotNull();

        }
    }
}
