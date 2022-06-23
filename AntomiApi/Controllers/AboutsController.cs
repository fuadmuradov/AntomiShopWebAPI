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
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetAbout(int id)
        //{
        //    var response = await aboutService.GetAboutAsync(id);
        //    return Ok(response);
        //}
        //[HttpGet("Testimonial/{id}")]
        //public async Task<IActionResult> GetTestimonial(int id)
        //{
        //    var response = await aboutService.GetTestimonialAsync(id);
        //    return Ok(response);
        //}
        //[HttpGet("Question/{id}")]
        //public async Task<IActionResult> GetQuestion(int id)
        //{
        //    var response = await aboutService.GetQuestionAsync(id);
        //    return Ok(response);
        //}

        //Create
     //[HttpPost]
     //   public async Task<IActionResult> CreateAbout(AboutPostDto postDto)
     //   {
     //       var response = await aboutService.CreateAboutAsync(postDto);
     //       return StatusCode(201, response);
     //   }

     //   [Route("CreateTestimonial")]
     //   [HttpPost]
     //   public async Task<IActionResult> CreateTestimonial(TestimonialPostDto postDto)
     //   {
     //       var response = await aboutService.CreateTestimonialAsync(postDto);
     //       return StatusCode(201, response);
     //   }
     //   [Route("CreateQuestion")]
     //   [HttpPost]
     //   public async Task<IActionResult> CreateQuestion(QuestionPostDto postDto)
     //   {
     //       var response = await aboutService.CreateQuestionAsync(postDto);
     //       return StatusCode(201, response);
     //   }

     //   //Update
     //   [HttpPut("UpdateAbout/{id}")]
     //   public async Task<IActionResult> UpdateAbout(int id,AboutPostDto postDto)
     //   {
     //       var response = await aboutService.UpdateAboutAsync(id, postDto);
     //       return StatusCode(200, response);
     //   }

     //   [HttpPut("UpdateTestimonial/{id}")]
     //   public async Task<IActionResult> UpdateTestimonial(int id, TestimonialPostDto postDto)
     //   {
     //       var response = await aboutService.UpdateTestimonialAsync(id, postDto);
     //       return StatusCode(200, response);
     //   }

     //   [HttpPut("UpdateQuestion/{id}")]
     //   public async Task<IActionResult> UpdateQuestion(int id, QuestionPostDto postDto)
     //   {
     //       var response = await aboutService.UpdateQuestionAsync(id, postDto);
     //       return StatusCode(200, response);
     //   }

     //   //Delete
     //   [HttpDelete("DeleteAbout/{id}")]
     //   public async Task<IActionResult> DeleteAbout(int id)
     //   {
     //       return Ok(aboutService.DeleteAboutAsync(id));
     //   }

     //   [HttpDelete("DeleteTestimonial/{id}")]
     //   public async Task<IActionResult> DeleteTestimonial(int id)
     //   {
     //       return Ok(aboutService.DeleteTestimonialAsync(id));
     //   }

     //   [HttpDelete("DeleteQuestion/{id}")]
     //   public async Task<IActionResult> DeleteQuestion(int id)
     //   {
     //       return Ok(aboutService.DeleteQuestionAsync(id));
     //   }

     //   //Get All
     //   [HttpGet("GetAllQuestion/")]
     //   public async Task<IActionResult> GetAllQuestion()
     //   {
     //       var response = aboutService.GetAllQuestion();
     //       return Ok(response);
     //   }
     //   [HttpGet("GetAllTestimonial/")]
     //   public async Task<IActionResult> GetAllTestimonial()
     //   {
     //       var response = aboutService.GetAllTestimonial();
     //       return Ok(response);
     //   }


    }
}
