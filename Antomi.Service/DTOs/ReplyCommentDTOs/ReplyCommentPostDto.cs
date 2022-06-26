using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.ReplyCommentDTOs
{
    public class ReplyCommentPostDto
    {
        public string Text { get; set; }
        public int BlogCommentId { get; set; }
        public string AppUserId { get; set; }
    }

    public class ReplyCommentPostDtoValidation : AbstractValidator<ReplyCommentPostDto>
    {
        public ReplyCommentPostDtoValidation()
        {
            RuleFor(x => x.Text).NotEmpty().NotNull().MaximumLength(150);
            RuleFor(x => x.AppUserId).NotNull().NotEmpty();
            RuleFor(x => x.BlogCommentId).NotNull().NotEmpty();

        }
    }
}
