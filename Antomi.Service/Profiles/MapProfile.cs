using Antomi.Core.Entities;
using Antomi.Service.DTOs.AboutDTOs;
using Antomi.Service.DTOs.CategoryDTOs;
using Antomi.Service.DTOs.MarkaDTOs;
using Antomi.Service.DTOs.QuestionDTOs;
using Antomi.Service.DTOs.SubCategoryDTOs;
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
            CreateMap<Marka, MarkaGetDto>();
            CreateMap<MarkaPostDto, Marka>();
            CreateMap<SubCategory, SubCategoryGetDto>();
            CreateMap<SubCategoryPostDto, SubCategory>();
            //AboutService
            CreateMap<About, AboutGetDto>();
            CreateMap<AboutPostDto, About>();
            CreateMap<TestimonialPostDto, Testimonial>();
            CreateMap<Testimonial, TestimonialGetDto>();
            CreateMap<Question, QuestionGetDto>();
            CreateMap<QuestionPostDto, Question>();
        }
    }
}
