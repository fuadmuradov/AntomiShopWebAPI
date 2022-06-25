using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.CommentDTOs
{
    public class CommentPostDto
    {
        public string Text { get; set; }
        public int ProductId { get; set; }
        public bool isActive { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string AppUserId { get; set; }
        public DateTime CretadAt { get; set; }
    }

    public class CommentPostDtoValidation : AbstractValidator<CommentPostDto>
    {
        public CommentPostDtoValidation()
        {
            RuleFor(x => x.Text).NotEmpty().NotNull().MaximumLength(250);
            RuleFor(x => x.Username).NotEmpty().NotNull().MaximumLength(40);
            RuleFor(x => x.ProductId).NotEmpty().NotNull();
            RuleFor(x => x.AppUserId).NotEmpty().NotNull();
            RuleFor(x => x.Email).NotEmpty().NotNull();

        }
    }
}
