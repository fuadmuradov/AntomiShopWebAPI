using Antomi.Core.IRepositories;
using Antomi.Service.DTOs.CategoryDTOs;
using Antomi.Service.DTOs.MarkaDTOs;
using Antomi.Service.DTOs.SubCategoryDTOs;
using Antomi.Service.DTOs.SubCategoryToMarkaDTOs;
using Antomi.Service.Exceptions;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [Route("CreateCategory")]
        [HttpPost]
        public async Task<IActionResult> Create(CategoryPostDto categoryPost)
        {
           
                var response = await categoryService.CreateAsync(categoryPost);
                return StatusCode(201, response);
   
        }

        [Route("CreateMarka")]
        [HttpPost]
        public async Task<IActionResult> CreateMarka(MarkaPostDto postDto)
        {
            var response = await categoryService.CreateMarkaAsync(postDto);
            return StatusCode(201, response);
        }

        [Route("CreateSubCategory")]
        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(SubCategoryPostDto postDto)
        {
            var response = await categoryService.CreateSubCategoryAsync(postDto);
            return StatusCode(201, response);
        }

        [Route("CreateSubCategoryToMarka")]
        [HttpPost]
        public async Task<IActionResult> CreateSubCategoryToMarka(SubCategoryMarkaPostDto categoryPost)
        {

            var response = await categoryService.CreateSubCategoryMarkaAsync(categoryPost);
            return StatusCode(201, response);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryPostDto categoryPost)
        {
           
                var response = await categoryService.UpdateAsync(id, categoryPost);

                return StatusCode(200, response);
          
        }

        [Route("UpdateMarka/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateMarka(int id, MarkaPostDto postDto)
        {
            var response = await categoryService.UpdateMarkaAsync(id, postDto);
            return Ok(response);
        }

        [Route("UpdateSubCategory/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateSubCategory(int id, SubCategoryPostDto postDto)
        {
            var response = await categoryService.UpdateSubCategoryAsync(id, postDto);
            return Ok(response);
        }

        [Route("UpdateSubCategoryToMarka/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateSubCateogoryMarka(int id, SubCategoryMarkaPostDto postDto)
        {
            var response = await categoryService.UpdateSubCategoryMarkaAsync(id, postDto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
                await categoryService.Delete(id);
                return StatusCode(200);
           
        }

        [Route("DeleteMarka/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMarka(int id)
        {
            await categoryService.DeleteMarka(id);
            return Ok();
        }

        [Route("DeleteSubCategory/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            await categoryService.DeleteSubCategory(id);
            return Ok();
        }

        [Route("DeleteSubCategoryMarka/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSubCateogoryMarka(int id)
        {
            await categoryService.DeleteSubCategoryMarkaAsync(id);
            return Ok();
        }

        [Route("GetCateogory/{id}")]
        [HttpGet()]
        public async Task<IActionResult> Get(int id)
        {
         
            return Ok(await categoryService.GetByIdAsync(id));
        }

        [Route("GetMarka/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetMarka(int id)
        {
            var response = await categoryService.GetMarkaAsync(id);
            return Ok(response);
        }

        [Route("GetSubCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetSubCategory(int id)
        {
            var response = await categoryService.GetSubCategoryAsync(id);
            return Ok(response);
        }

        [Route("GetSubCateogryToMarka/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetSubCategoryMarka(int id)
        {
            var response = await categoryService.GetSubCategoryMarkaAsync(id);
            return Ok(response);
        }

        [Route("GetAllCategory/{PageIndex}")]
        [HttpGet]
        public async Task<IActionResult> GetAll(int PageIndex)
        {
            return Ok(await categoryService.GetAll(PageIndex));
        }

        [Route("GetAllMarka")]
        [HttpGet]
        public async Task<IActionResult> GetAllMarka()
        {
            var response = await categoryService.GetAllMarka();
            return Ok(response);
        }

        [Route("GetAllSubCategory")]
        [HttpGet]
        public async Task<IActionResult> GetAllSubCategory()
        {
            var response = await categoryService.GetAllSubCategory();
            return Ok(response);
        }

        [Route("GetAllSubCategoryToMarka")]
        [HttpGet]
        public async Task<IActionResult> GetAllSubCategoryToMarka()
        {
            var response = await categoryService.GetAllSubCategoryMarka();
            return Ok(response);
        }
    }
}
