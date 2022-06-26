using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.BlogDTOs
{
    public class BlogPostDto
    {
        public string AppUserId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Emphasis { get; set; }
        public int CategoryId { get; set; }
    }

    public class BlogPostDtoValidation : AbstractValidator<BlogPostDto>
    {
        public BlogPostDtoValidation()
        {
            RuleFor(x => x.AppUserId).NotEmpty().NotNull();
            RuleFor(x => x.CategoryId).NotNull().NotEmpty();
            RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(150);
            RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(150);
            RuleFor(x => x.Emphasis).MaximumLength(500);
            RuleFor(x => x.Image).NotNull().NotEmpty();
        }
    }

}
