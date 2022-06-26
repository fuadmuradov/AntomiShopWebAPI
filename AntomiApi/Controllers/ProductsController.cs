using Antomi.Service.DTOs.NotebookSpecDTOs;
using Antomi.Service.DTOs.PhoneSpecDTOs;
using Antomi.Service.DTOs.ProductColorDTOs;
using Antomi.Service.DTOs.ProductColorImageDTOs;
using Antomi.Service.DTOs.ProductDTOs;
using Antomi.Service.DTOs.SpecificationDTOs;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        [Route("CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductPostDto postDto)
        {
            var response = await productService.CreateProductAsync(postDto);
            return StatusCode(201, response);
        }

        [Route("CreateProductColor")]
        [HttpPost]
        public async Task<IActionResult> CreateProductColor(ProductColorPostDto postDto)
        {
            var response = await productService.CreateProductColorAsync(postDto);
            return StatusCode(201, response);
        }

        [Route("CreateProductColorImage")]
        [HttpPost]
        public async Task<IActionResult> CreateProductColorImage(ProductColorImagePostDto postDto)
        {
            var response = await productService.CreateProductColorImageAsync(postDto);
            return StatusCode(201, response);
        }

        [Route("AddSpecification")]
        [HttpPost]
        public async Task<IActionResult> AddSpecification(SpecificationPostDto postDto)
        {
            var response = await productService.CreateSpecificationAsync(postDto);
            return StatusCode(201, response);
        }

        [Route("AddNotebookSpecification")]
        [HttpPost]
        public async Task<IActionResult> AddNotebookSpecification(NotebookSpecPostDto postDto)
        {
            var response = await productService.CreateNotebookSpecAsync(postDto);
            return StatusCode(201, response);
        }

        [Route("AddPhoneSpecification")]
        [HttpPost]
        public async Task<IActionResult> AddPhoneSpecification(PhoneSpecPostDto postDto)
        {
            var response = await productService.CreatePhoneSpecAsync(postDto);
            return StatusCode(201, response);
        }

        //Update
        [Route("UpdateProduct/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, ProductPostDto postDto)
        {
            var response = await productService.UpdateProductAsync(id, postDto);
            return StatusCode(200, response);
        }

        [Route("UpdateProductColor/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProductColor(int id, ProductColorPostDto postDto)
        {
            var response = await productService.UpdateProductColorAsync(id, postDto);
            return StatusCode(200, response);
        }

        [Route("UpdateProductColorImage/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProductColorImage(int id, ProductColorImagePostDto postDto)
        {
            var response = await productService.UpdateProductColorImageAsync(id, postDto);
            return StatusCode(200, response);
        }

        [Route("UpdateSpecification/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateSpecification(int id, SpecificationPostDto postDto)
        {
            var response = await productService.UpdateSpecificationAsync(id, postDto);
            return StatusCode(200, response);
        }

        [Route("UpdateNotebookSpecification/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateNotebookSpecification(int id, NotebookSpecPostDto postDto)
        {
            var response = await productService.UpdateNotebookSpecAsync(id, postDto);
            return StatusCode(200, response);
        }

        [Route("UpdatePhoneSpecification/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePhoneSpecification(int id, PhoneSpecPostDto postDto)
        {
            var response = await productService.UpdatePhoneSpecAsync(id, postDto);
            return StatusCode(200, response);
        }

        //Get
        [Route("GetProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProduct(int id)
        {
            var response = await productService.GetProductAsync(id);
            return StatusCode(200, response);
        }

        [Route("GetProductColor/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProductColor(int id)
        {
            var response = await productService.GetProductColorAsync(id);
            return StatusCode(200, response);
        }

        [Route("GetProductColorImage/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProductColorImage(int id)
        {
            var response = await productService.GetProductColorImageAsync(id);
            return StatusCode(200, response);
        }

        [Route("GetSpecification/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetSpecification(int id)
        {
            var response = await productService.GetSpecificationAsync(id);
            return StatusCode(200, response);
        }

        [Route("GetPhoneSpecification/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetPhoneSpecification(int id)
        {
            var response = await productService.GetPhoneSpecAsync(id);
            return StatusCode(200, response);
        }

        [Route("GetNotebookSpecification/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetNotebookSpecification(int id)
        {
            var response = await productService.GetNotebookSpecAsync(id);
            return StatusCode(200, response);
        }


        //Get All
        [Route("GetAllProduct")]
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var response = await productService.GetAllProductAsync();
            return StatusCode(200, response);
        }

        [Route("GetAllProductColor")]
        [HttpGet]
        public async Task<IActionResult> GetAllProductColor()
        {
            var response = await productService.GetAllProductColorAsync();
            return StatusCode(200, response);
        }

        [Route("GetAllProductColorImage")]
        [HttpGet]
        public async Task<IActionResult> GetAllProductColorImage()
        {
            var response = await productService.GetAllProductColorImageAsync();
            return StatusCode(200, response);
        }

        [Route("GetAllSpecification/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAllSpecification(int id)
        {
            var response = await productService.GetAllSpecificationAsync(id);
            return StatusCode(200, response);
        }

        [Route("GetAllPhoneSpecification")]
        [HttpGet]
        public async Task<IActionResult> GetAllPhoneSpecification()
        {
            var response = await productService.GetAllPhoneSpecAsync();
            return StatusCode(200, response);
        }

        [Route("GetAllNotebookSpecification")]
        [HttpGet]
        public async Task<IActionResult> GetAllNotebookSpecification()
        {
            var response = await productService.GetAllNotebookSpecAsync();
            return StatusCode(200, response);
        }
        //Delete

        [Route("DeleteProduct/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await productService.DeleteProductAsync(id);
            return StatusCode(200);
        }

        [Route("DeleteProductColor/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProductColor(int id)
        {
            await productService.DeleteProductColorAsync(id);
            return StatusCode(200);
        }

        [Route("DeleteProductColorImage/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProductColorImage(int id)
        {
            await productService.DeleteProductColorImageAsync(id);
            return StatusCode(200);
        }

        [Route("DeleteSpecification/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSpecification(int id)
        {
            await productService.DeleteSpecificationAsync(id);
            return StatusCode(200);
        }

        [Route("DeletePhoneSpecification/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePhoneSpecifcation(int id)
        {
            await productService.DeletePhoneSpecAsync(id);
            return StatusCode(200);
        }
        [Route("DeleteNotebookSpecification/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteNotebookSpecifcation(int id)
        {
            await productService.DeletePhoneSpecAsync(id);
            return StatusCode(200);
        }
    }
}
