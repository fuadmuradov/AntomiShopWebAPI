using Antomi.Core;
using Antomi.Core.Entities;
using Antomi.Service.DTOs.BlogCommentDTOs;
using Antomi.Service.DTOs.BlogDTOs;
using Antomi.Service.DTOs.ReplyCommentDTOs;
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
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BlogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BlogGetDto> CreateBlogAsync(BlogPostDto postDto)
        {
            Blog blog = mapper.Map<Blog>(postDto);
            await unitOfWork.BlogRepository.AddAsync(blog);
            await unitOfWork.BlogRepository.SaveDbAsync();
            BlogGetDto blogGet = mapper.Map<BlogGetDto>(blog);
            return blogGet;
        }

        public async Task<BlogCommentGetDto> CreateBlogCommentAsync(BlogCommentPostDto postDto)
        {
            BlogComment comment = mapper.Map<BlogComment>(postDto);
            await unitOfWork.BlogCommentRepository.AddAsync(comment);
            await unitOfWork.BlogCommentRepository.SaveDbAsync();
            BlogCommentGetDto commentGet = mapper.Map<BlogCommentGetDto>(comment);
            return commentGet;
        }

        public async Task<ReplyCommentGetDto> CreateReplyCommentAsync(ReplyCommentPostDto postDto)
        {
            ReplyComment comment = mapper.Map<ReplyComment>(postDto);
            await unitOfWork.ReplyCommentRepository.AddAsync(comment);
            await unitOfWork.ReplyCommentRepository.SaveDbAsync();
            ReplyCommentGetDto commentGet = mapper.Map<ReplyCommentGetDto>(comment);
            return commentGet;
        }

        public async Task DeleteBlogAsync(int id)
        {
            Blog existBlog = await unitOfWork.BlogRepository.GetAsync(x => x.Id == id && x.isDeleted==false);
            if (existBlog == null)
                throw new ItemNotFoundException("Item Not Found by Id ("+id+")");
              existBlog.isDeleted = true;
            await unitOfWork.BlogRepository.SaveDbAsync();

        }

        public async Task DeleteBlogCommentAsync(int id)
        {
            BlogComment existComment = await unitOfWork.BlogCommentRepository.GetAsync(x => x.Id == id);
            if (existComment == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            unitOfWork.BlogCommentRepository.Remove(existComment);
            await unitOfWork.BlogCommentRepository.SaveDbAsync();
        }

        public async Task DeleteReplyCommentAsync(int id)
        {
            ReplyComment existComment = await unitOfWork.ReplyCommentRepository.GetAsync(x => x.Id == id);
            if (existComment == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            unitOfWork.ReplyCommentRepository.Remove(existComment);
            await unitOfWork.ReplyCommentRepository.SaveDbAsync();
        }

        public async Task<List<BlogGetDto>> GetAllBlog()
        {
            List<Blog> blogs =  unitOfWork.BlogRepository.GetAll(x => x.isDeleted == false, "BlogComments", "Category", "AppUser").ToList() ;
            if(blogs==null)
                throw new ItemNotFoundException("Item Not Found");
            List<BlogGetDto> blogGets = mapper.Map<List<Blog>, List<BlogGetDto>>(blogs);
            return blogGets;
        
        }

        public async Task<List<BlogCommentGetDto>> GetAllBlogComment(int id)
        {
            List<BlogComment> blogComments = unitOfWork.BlogCommentRepository.GetAll(x => x.BlogId == id, "ReplyComments", "Blog").ToList();
            if(blogComments==null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            List<BlogCommentGetDto> blogCommentGets = mapper.Map<List<BlogComment>, List<BlogCommentGetDto>>(blogComments);
            return blogCommentGets;
        }

        public async Task<List<ReplyCommentGetDto>> GetAllReplyComment(int id)
        {
            List<ReplyComment> replyComments = unitOfWork.ReplyCommentRepository.GetAll(x => x.BlogCommentId == id, "BlogComment").ToList();
            if (replyComments == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            List<ReplyCommentGetDto> replyCommentGets = mapper.Map<List<ReplyComment>, List<ReplyCommentGetDto>>(replyComments);
            return replyCommentGets;
        }

        public async Task<BlogGetDto> GetBlogAsync(int id)
        {
            Blog blog = await unitOfWork.BlogRepository.GetAsync(x => x.Id == id && x.isDeleted == false);
            if (blog == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            BlogGetDto blogGet = mapper.Map<BlogGetDto>(blog);
            return blogGet;
        }

        public async Task<BlogCommentGetDto> GetBlogCommentAsync(int id)
        {
            BlogComment comment = await unitOfWork.BlogCommentRepository.GetAsync(x => x.Id == id);
            if (comment == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            BlogCommentGetDto commentGet = mapper.Map<BlogCommentGetDto>(comment);
            return commentGet;
        }

        public async Task<ReplyCommentGetDto> GetReplyCommentAsync(int id)
        {
            ReplyComment comment = await unitOfWork.ReplyCommentRepository.GetAsync(x => x.Id == id);
            if (comment == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            ReplyCommentGetDto commentGet = mapper.Map<ReplyCommentGetDto>(comment);
            return commentGet;
        }

        public async Task<BlogGetDto> UpdateBlogAsync(int id,BlogPostDto postDto)
        {
            Blog blog = await unitOfWork.BlogRepository.GetAsync(x => x.Id == id && x.isDeleted==false);
            if (blog == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            blog.Image = postDto.Image;
            blog.Description = postDto.Description;
            blog.Title = postDto.Title;
            blog.CategoryId = postDto.CategoryId;
            blog.AppUserId = postDto.AppUserId;
            blog.Emphasis = postDto.Emphasis;
            await unitOfWork.BlogRepository.SaveDbAsync();
            BlogGetDto blogGet = mapper.Map<BlogGetDto>(blog);

            return blogGet;
        }

        public async Task<BlogCommentGetDto> UpdateBlogCommentAsync(int id, BlogCommentPostDto postDto)
        {
            BlogComment comment = await unitOfWork.BlogCommentRepository.GetAsync(x => x.Id == id);
            if (comment == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            comment.BlogId = postDto.BlogId;
            comment.Text = postDto.Text;
            comment.AppUserId = postDto.AppUserId;
            await unitOfWork.BlogCommentRepository.SaveDbAsync();
            BlogCommentGetDto blogCommentGet = mapper.Map<BlogCommentGetDto>(comment);
            return blogCommentGet;
        }

        public async Task<ReplyCommentGetDto> UpdateReplyCommentAsync(int id, ReplyCommentPostDto postDto)
        {
            ReplyComment comment = await unitOfWork.ReplyCommentRepository.GetAsync(x => x.Id == id);
            if (comment == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            comment.BlogCommentId = postDto.BlogCommentId;
            comment.Text = postDto.Text;
            comment.AppUserId = postDto.AppUserId;
            await unitOfWork.ReplyCommentRepository.SaveDbAsync();
            ReplyCommentGetDto replyCommentGet = mapper.Map<ReplyCommentGetDto>(comment);
            return replyCommentGet;
        }
    }
}
