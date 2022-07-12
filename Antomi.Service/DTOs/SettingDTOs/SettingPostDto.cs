using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.SettingDTOs
{
    public class SettingPostDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class SettingPostDtoValidation : AbstractValidator<SettingPostDto>
    {
        public SettingPostDtoValidation()
        {
            RuleFor(x => x.Key).NotNull().NotEmpty();
            RuleFor(x => x.Value).NotNull().NotEmpty();
        }

    }
}
