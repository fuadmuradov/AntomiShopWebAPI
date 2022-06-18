using Antomi.Core.IRepositories;
using Antomi.Service.DTOs.CategoryDTOs;
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
        [HttpGet]
        public async Task<IActionResult> Create(CategoryPostDto categoryPost)
        {
            var response = await categoryService.CreateAsync(categoryPost);
            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryPostDto categoryPost)
        {
            var response = await categoryService.UpdateAsync(id, categoryPost);

            return StatusCode(200, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await categoryService.Delete(id);
            return StatusCode(200);
        }


        public async Task<IActionResult> Get(int id)
        {
            var response = await categoryService.GetByIdAsync(id);

            return StatusCode(200, response);
        }

    }
}
