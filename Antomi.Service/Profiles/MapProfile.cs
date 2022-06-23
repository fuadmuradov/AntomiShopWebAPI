using Antomi.Core.Entities;
using Antomi.Service.DTOs.AboutDTOs;
using Antomi.Service.DTOs.CategoryDTOs;
using Antomi.Service.DTOs.QuestionDTOs;
using Antomi.Service.DTOs.TestimonialDTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.Profiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            //CategoryService
            CreateMap<Category, CategoryGetDto>();
            CreateMap<CategoryPostDto, Category>();
            CreateMap<Category, CategoryListItemDto>();
            //AboutService
            CreateMap<About, AboutGetDto>();
            CreateMap<AboutPostDto, About>();
            CreateMap<TestimonialPostDto, Testimonial>();
            CreateMap<Testimonial, TestimonialGetDto>();
            CreateMap<List<Testimonial>, List<TestimonialGetDto>>();
            CreateMap<Question, QuestionGetDto>();
            CreateMap<QuestionPostDto, Question>();
            CreateMap<List<Question>, List<QuestionGetDto>>();
        }
    }
}
