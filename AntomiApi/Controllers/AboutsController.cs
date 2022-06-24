using Antomi.Service.DTOs.AboutDTOs;
using Antomi.Service.DTOs.QuestionDTOs;
using Antomi.Service.DTOs.TestimonialDTOs;
using Antomi.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntomiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService aboutService;

        public AboutsController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        //Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var response = await aboutService.GetAboutAsync(id);
            return Ok(response);
        }
        [Route("Testimonial/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var response = await aboutService.GetTestimonialAsync(id);
            return Ok(response);
        }
        [Route("Question/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var response = await aboutService.GetQuestionAsync(id);
            return Ok(response);
        }

       // Create
        [HttpPost]
           public async Task<IActionResult> CreateAbout(AboutPostDto postDto)
        {
            var response = await aboutService.CreateAboutAsync(postDto);
            return StatusCode(201, response);
        }

        [Route("CreateTestimonial")]
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(TestimonialPostDto postDto)
        {
            var response = await aboutService.CreateTestimonialAsync(postDto);
            return StatusCode(201, response);
        }
        [Route("CreateQuestion")]
        [HttpPost]
        public async Task<IActionResult> CreateQuestion(QuestionPostDto postDto)
        {
            var response = await aboutService.CreateQuestionAsync(postDto);
            return StatusCode(201, response);
        }

        //Update
        [Route("UpdateAbout/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(int id, AboutPostDto postDto)
        {
            var response = await aboutService.UpdateAboutAsync(id, postDto);
            return StatusCode(200, response);
        }

        [Route("UpdateTestimonial/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(int id, TestimonialPostDto postDto)
        {
            var response = await aboutService.UpdateTestimonialAsync(id, postDto);
            return StatusCode(200, response);
        }

        [Route("UpdateQuestion/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateQuestion(int id, QuestionPostDto postDto)
        {
            var response = await aboutService.UpdateQuestionAsync(id, postDto);
            return StatusCode(200, response);
        }

        //Delete
        [Route("DeleteAbout/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await aboutService.DeleteAboutAsync(id);
            return Ok();
        }

        [HttpDelete("DeleteTestimonial/{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await aboutService.DeleteTestimonialAsync(id);
            return Ok();
        }

        [HttpDelete("DeleteQuestion/{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await aboutService.DeleteQuestionAsync(id);
            return Ok();
        }

        //Get All
        [Route("GetAllQuestion")]
        [HttpGet]
        public async Task<IActionResult> GetAllQuestion()
        {
            var response = await aboutService.GetAllQuestion();
            return Ok(response);
        }
        [Route("GetAllTestimonial")]
        [HttpGet]
        public async Task<IActionResult> GetAllTestimonial()
        {
            var response = await aboutService.GetAllTestimonial();
            return Ok(response);
        }


    }
}
