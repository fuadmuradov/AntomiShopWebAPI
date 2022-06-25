using Antomi.Core.Entities;
using Antomi.Service.DTOs.AboutDTOs;
using Antomi.Service.DTOs.CategoryDTOs;
using Antomi.Service.DTOs.CommentDTOs;
using Antomi.Service.DTOs.MarkaDTOs;
using Antomi.Service.DTOs.NotebookSpecDTOs;
using Antomi.Service.DTOs.PhoneSpecDTOs;
using Antomi.Service.DTOs.ProductColorDTOs;
using Antomi.Service.DTOs.ProductColorImageDTOs;
using Antomi.Service.DTOs.ProductDTOs;
using Antomi.Service.DTOs.QuestionDTOs;
using Antomi.Service.DTOs.SpecificationDTOs;
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
            //Category Service
            CreateMap<Category, CategoryGetDto>();
            CreateMap<CategoryPostDto, Category>();
            CreateMap<Category, CategoryListItemDto>();
            CreateMap<Marka, MarkaGetDto>();
            CreateMap<MarkaPostDto, Marka>();
            CreateMap<SubCategory, SubCategoryGetDto>();
            CreateMap<SubCategoryPostDto, SubCategory>();
            //About Service
            CreateMap<About, AboutGetDto>();
            CreateMap<AboutPostDto, About>();
            CreateMap<TestimonialPostDto, Testimonial>();
            CreateMap<Testimonial, TestimonialGetDto>();
            CreateMap<Question, QuestionGetDto>();
            CreateMap<QuestionPostDto, Question>();
            //Product Service
            CreateMap<ProductPostDto, Product>();
            CreateMap<Product, ProductPostDto>();
            CreateMap<ProductColorPostDto, ProductColor>();
            CreateMap<ProductColor, ProductColorGetDto>();
            CreateMap<ProductColorImagePostDto, ProductColorImage>();
            CreateMap<ProductColorImage, ProductColorImageGetDto>();
            CreateMap<List<NotebookSpecification>, List<NotebookSpecGetDto>>();
            CreateMap<NotebookSpecification, NotebookSpecGetDto>();
            CreateMap<List<PhoneSpecification>, List<PhoneSpecGetDto>>();
            CreateMap<PhoneSpecification, PhoneSpecGetDto>();
            CreateMap<Specification, SpecificationGetDto>();
            CreateMap<Comment, CommentGetDto>();
            CreateMap<Product, ProductItemGetDto>();
            CreateMap<ProductColor, ProductColorItemGetDto>();
        }
    }
}
