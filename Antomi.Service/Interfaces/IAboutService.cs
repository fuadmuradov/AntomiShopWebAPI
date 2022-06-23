using Antomi.Service.DTOs.AboutDTOs;
using Antomi.Service.DTOs.QuestionDTOs;
using Antomi.Service.DTOs.TestimonialDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.Interfaces
{
    public interface IAboutService
    {
        //About Entity
        Task<AboutGetDto> CreateAboutAsync(AboutPostDto aboutPostDto);
        Task<AboutGetDto> UpdateAboutAsync(int id, AboutPostDto aboutPostDto);
        Task<AboutGetDto> GetAboutAsync(int id);
        Task DeleteAboutAsync(int id);
        ////Testimonial Entity
        //Task<TestimonialGetDto> CreateTestimonialAsync(TestimonialPostDto testimonialPostDto);
        //Task<TestimonialGetDto> UpdateTestimonialAsync(int id, TestimonialPostDto testimonialPostDto);
        //Task<TestimonialGetDto> GetTestimonialAsync(int id);
        //Task<List<TestimonialGetDto>> GetAllTestimonial();
        //Task DeleteTestimonialAsync(int id);
        ////Question Entity
        //Task<QuestionGetDto> CreateQuestionAsync(QuestionPostDto questionPostDto);
        //Task<QuestionGetDto> UpdateQuestionAsync(int id, QuestionPostDto questionPostDto);
        //Task<QuestionGetDto> GetQuestionAsync(int id);
        //Task<List<QuestionGetDto>> GetAllQuestion();
        //Task DeleteQuestionAsync(int id);

    }
}
