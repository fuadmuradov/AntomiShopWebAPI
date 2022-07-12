using Antomi.Service.DTOs.BlogCommentDTOs;
using Antomi.Service.DTOs.BlogDTOs;
using Antomi.Service.DTOs.ReplyCommentDTOs;
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
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService blogService;

        public BlogsController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        #region Get

        [HttpGet]
        [Route("GetBlog/{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var response = await blogService.GetBlogAsync(id);
            return Ok(response);
        }
        
        [Route("GetComment/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetComment(int id)
        {
            var response = await blogService.GetBlogCommentAsync(id);
            return Ok(response);
        }

        [Route("GetReplyComment/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetReplyComment(int id)
        {
            var response = await blogService.GetReplyCommentAsync(id);
            return Ok(response);
        }

        #endregion

        #region GetAll

        [HttpGet]
        [Route("GetAllBlog")]
        public async Task<IActionResult> GetAllBlog()
        {
            var response = await blogService.GetAllBlog();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllBlogComment/{BlogId}")]
        public async Task<IActionResult> GetAllBlogComment(int BlogId)
        {
            var response = await blogService.GetAllBlogComment(BlogId);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllReplyComment/{BlogCommentId}")]
        public async Task<IActionResult> GetAllReplyComment(int BlogCommentId)
        {
            var response = await blogService.GetAllReplyComment(BlogCommentId);
            return Ok(response);
        }

        #endregion

        #region Create

        [Route("CreateBlog/{id}")]
        [HttpPost]
        public async Task<IActionResult> CreateBlog(BlogPostDto postDto)
        {
            var response = await blogService.CreateBlogAsync(postDto);
            return StatusCode(201, response);
        }

        [Route("CreateBlogComment/{id}")]
        [HttpPost]
        public async Task<IActionResult> CreateBlogComment(BlogCommentPostDto postDto)
        {
            var response = await blogService.CreateBlogCommentAsync(postDto);
            return StatusCode(201, response);
        }

        [Route("CreateReplyComment/{id}")]
        [HttpPost]
        public async Task<IActionResult> CreateReplyComment(ReplyCommentPostDto postDto)
        {
            var response = await blogService.CreateReplyCommentAsync(postDto);
            return StatusCode(201, response);
        }


        #endregion

        #region Update

        [HttpPut]
        [Route("UpdateBlog/{id}")]
        public async Task<IActionResult> UpdateBlog(int id,BlogPostDto postDto)
        {
            var response = await blogService.UpdateBlogAsync(id, postDto);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateBlogComment/{id}")]
        public async Task<IActionResult> UpdateBlogComment(int id, BlogCommentPostDto postDto)
        {
            var response = await blogService.UpdateBlogCommentAsync(id, postDto);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateReplyComment/{id}")]
        public async Task<IActionResult> UpdateReplyComment(int id, ReplyCommentPostDto postDto)
        {
            var response = await blogService.UpdateReplyCommentAsync(id, postDto);
            return Ok(response);
        }

        #endregion

        #region Delete

        [HttpDelete]
        [Route("DeleteBlog/{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await blogService.DeleteBlogAsync(id);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteBlogComment/{id}")]
        public async Task<IActionResult> DeleteBlogComment(int id)
        {
            await blogService.DeleteBlogCommentAsync(id);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteReplyComment/{id}")]
        public async Task<IActionResult> DeleteReplyComment(int id)
        {
            await blogService.DeleteReplyCommentAsync(id);
            return Ok();
        }
        #endregion

    }
}
