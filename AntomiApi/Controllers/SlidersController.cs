using Antomi.Service.DTOs.SliderDTOs;
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
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService sliderService;

        public SlidersController(ISliderService sliderService)
        {
            this.sliderService = sliderService;
        }

        #region Slider

        [HttpPost]
        [Route("CreateSlider")]
        public async Task<IActionResult> CreateSlider(SliderPostDto postDto)
        {
            var response = await sliderService.CreateSliderAsync(postDto);
            return StatusCode(201, response);
        }

        [HttpGet]
        [Route("GetSlider/{id}")]
        public async Task<IActionResult> GetSlider(int id)
        {
            var response = await sliderService.GetSliderAsync(id);
            return StatusCode(200, response);
        }

        [HttpGet]
        [Route("GetAllSlider")]
        public async Task<IActionResult> GetAllSlider()
        {
            var response = await sliderService.GetAllSliderAsync();
            return StatusCode(200, response);
        }

        [HttpPut]
        [Route("UpdateSlider/{id}")]
        public async Task<IActionResult> UpdateSlider(int id, SliderPostDto postDto)
        {
            var response = await sliderService.UpdateSliderAsync(id, postDto);
            return StatusCode(200, response);
        }

        [HttpDelete]
        [Route("GetSlider")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
             await sliderService.DeleteSlider(id);
            return StatusCode(200);
        }


        #endregion

    }
}
