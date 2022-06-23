using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.QuestionDTOs
{
    public class QuestionPostDto
    {
        public string Issue { get; set; }
        public string Answer { get; set; }
    }

    public class QuestionPostDtoValidation : AbstractValidator<QuestionPostDto>
    {
        public QuestionPostDtoValidation()
        {
            RuleFor(x => x.Issue).NotEmpty().NotNull().MaximumLength(250);
            RuleFor(x => x.Answer).NotEmpty().NotNull().MaximumLength(1500);

        }
    }
}
