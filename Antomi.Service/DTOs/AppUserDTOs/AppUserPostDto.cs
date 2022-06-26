using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.AppUserDTOs
{
    public class AppUserPostDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class AppUserPostDtoValidation : AbstractValidator<AppUserPostDto>
    {
        public AppUserPostDtoValidation()
        {
            RuleFor(x => x.Firstname).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.Lastname).NotNull().NotEmpty().MaximumLength(60);
            RuleFor(x => x.Email).NotNull().NotEmpty().MaximumLength(150);
            RuleFor(x => x.Username).NotNull().NotEmpty().MaximumLength(150);
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().MaximumLength(40);
            RuleFor(x => x.Country).NotNull().NotEmpty().MaximumLength(150);
            RuleFor(x => x.City).NotNull().NotEmpty().MaximumLength(150);
            RuleFor(x => x.StreetAddress).NotNull().NotEmpty().MaximumLength(300);
        }
    }
}
