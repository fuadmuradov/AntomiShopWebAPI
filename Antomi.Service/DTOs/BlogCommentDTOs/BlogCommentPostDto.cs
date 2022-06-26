using Antomi.Service.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.BlogCommentDTOs
{
    public class BlogCommentPostDto
    {
        public string AppUserId { get; set; }
        public string Text { get; set; }
        public int BlogId { get; set; }
    }

    public class BlogCommentPostDtoValidation : AbstractValidator<BlogCommentPostDto>
    {
        public BlogCommentPostDtoValidation()
        {
            RuleFor(x => x.Text).NotEmpty().NotNull().MaximumLength(150);
            RuleFor(x => x.AppUserId).NotNull().NotEmpty();
            RuleFor(x => x.BlogId).NotNull().NotEmpty();
           
        }
    }
}
