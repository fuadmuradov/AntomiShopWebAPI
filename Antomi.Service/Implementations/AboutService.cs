using Antomi.Core;
using Antomi.Core.Entities;
using Antomi.Service.DTOs.AboutDTOs;
using Antomi.Service.DTOs.QuestionDTOs;
using Antomi.Service.DTOs.TestimonialDTOs;
using Antomi.Service.Exceptions;
using Antomi.Service.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.Implementations
{
    public class AboutService : IAboutService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AboutService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<AboutGetDto> CreateAboutAsync(AboutPostDto aboutPostDto)
        {

            About about = mapper.Map<About>(aboutPostDto);
            await unitOfWork.AboutRepository.AddAsync(about);
            await unitOfWork.AboutRepository.SaveDbAsync();
            AboutGetDto aboutGet = mapper.Map<AboutGetDto>(about);
            return aboutGet;
        }

        public async Task<QuestionGetDto> CreateQuestionAsync(QuestionPostDto questionPostDto)
        {
            Question question = mapper.Map<Question>(questionPostDto);
            await unitOfWork.QuestionRepository.AddAsync(question);
            await unitOfWork.QuestionRepository.SaveDbAsync();
            QuestionGetDto questionGetDto = mapper.Map<QuestionGetDto>(question);
            return questionGetDto;
        }

        public async Task<TestimonialGetDto> CreateTestimonialAsync(TestimonialPostDto testimonialPostDto)
        {
            Testimonial testimonial = mapper.Map<Testimonial>(testimonialPostDto);
            await unitOfWork.TestimonialRepository.AddAsync(testimonial);
            await unitOfWork.TestimonialRepository.SaveDbAsync();
            TestimonialGetDto testimonialGet = mapper.Map<TestimonialGetDto>(testimonial);
            return testimonialGet;
        }

        public async Task DeleteAboutAsync(int id)
        {
            About existAbout = await unitOfWork.AboutRepository.GetAsync(x => x.Id == id);
            if (existAbout == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            unitOfWork.AboutRepository.Remove(existAbout);
            await unitOfWork.AboutRepository.SaveDbAsync();
        }

        public async Task DeleteQuestionAsync(int id)
        {
            Question question = await unitOfWork.QuestionRepository.GetAsync(x => x.Id == id);
            if (question == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            unitOfWork.QuestionRepository.Remove(question);
            await unitOfWork.QuestionRepository.SaveDbAsync();

        }

        public async Task DeleteTestimonialAsync(int id)
        {
            Testimonial testimonial = await unitOfWork.TestimonialRepository.GetAsync(x => x.Id == id);
            if (testimonial == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            unitOfWork.TestimonialRepository.Remove(testimonial);
            await unitOfWork.TestimonialRepository.SaveDbAsync();
        }

        public async Task<AboutGetDto> GetAboutAsync(int id)
        {
            About about = await unitOfWork.AboutRepository.GetAsync(x => x.Id == id);
            if (about == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            AboutGetDto aboutGet = mapper.Map<AboutGetDto>(about);
            return aboutGet;
        }

        public async Task<List<QuestionGetDto>> GetAllQuestion()
        {
            List<QuestionGetDto> questions =  unitOfWork.QuestionRepository.GetAll(x => x.Id > 0).Select(x=> new QuestionGetDto {Id = x.Id, Issue = x.Issue, Answer = x.Answer }).ToList();
            return questions;
        }

        public async Task<List<TestimonialGetDto>> GetAllTestimonial()
        {
            List<TestimonialGetDto> testimonials = unitOfWork.TestimonialRepository.GetAll(x => x.Id > 0).Select(x=> new TestimonialGetDto {
                Id=x.Id,
                Fullname = x.Fullname,
                Jobname = x.Jobname,
                Image = x.Image,
                Description = x.Description
            }).ToList();
            return testimonials;
        }

        public async Task<QuestionGetDto> GetQuestionAsync(int id)
        {
            Question question = await unitOfWork.QuestionRepository.GetAsync(x => x.Id == id);
            if (question == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            QuestionGetDto questionGet = mapper.Map<QuestionGetDto>(question);
            return questionGet;

        }

        public async Task<TestimonialGetDto> GetTestimonialAsync(int id)
        {
            Testimonial testimonial = await unitOfWork.TestimonialRepository.GetAsync(x => x.Id == id);
            if (testimonial == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            TestimonialGetDto testimonialGet = mapper.Map<TestimonialGetDto>(testimonial);
            return testimonialGet;
        }

        public async Task<AboutGetDto> UpdateAboutAsync(int id, AboutPostDto aboutPostDto)
        {
            About existAbout = await unitOfWork.AboutRepository.GetAsync(x => x.Id == id);
            if (existAbout == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            existAbout.Image = aboutPostDto.Image;
            existAbout.Signature = aboutPostDto.Signature;
            existAbout.Title = aboutPostDto.Title;
            existAbout.Description = aboutPostDto.Description;

            await unitOfWork.AboutRepository.SaveDbAsync();
            AboutGetDto aboutGet = mapper.Map<AboutGetDto>(existAbout);
            return aboutGet;

        }

        public async Task<QuestionGetDto> UpdateQuestionAsync(int id, QuestionPostDto questionPostDto)
        {
            Question existQuestion = await unitOfWork.QuestionRepository.GetAsync(x => x.Id == id);
            if (existQuestion == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            existQuestion.Issue = questionPostDto.Issue;
            existQuestion.Answer = questionPostDto.Answer;
            await unitOfWork.QuestionRepository.SaveDbAsync();
            QuestionGetDto questionGet = mapper.Map<QuestionGetDto>(existQuestion);
            return questionGet;
        }

        public async Task<TestimonialGetDto> UpdateTestimonialAsync(int id, TestimonialPostDto testimonialPostDto)
        {

            Testimonial ExistTestimonial = await unitOfWork.TestimonialRepository.GetAsync(x => x.Id == id);
            if (ExistTestimonial == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            ExistTestimonial.Image = testimonialPostDto.Image;
            ExistTestimonial.Fullname = testimonialPostDto.Fullname;
            ExistTestimonial.Jobname = testimonialPostDto.Jobname;
            ExistTestimonial.Description = testimonialPostDto.Description;

            await unitOfWork.TestimonialRepository.SaveDbAsync();
            TestimonialGetDto testimonialGet = mapper.Map<TestimonialGetDto>(ExistTestimonial);
            return testimonialGet;
        }
    }
}
