using Antomi.Service.DTOs.BlogCommentDTOs;
using Antomi.Service.DTOs.BlogDTOs;
using Antomi.Service.DTOs.ReplyCommentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.Interfaces
{
    public interface IBlogService
    {
        //Blog Entity
        Task<BlogGetDto> CreateBlogAsync(BlogPostDto postDto);
        Task<BlogGetDto> UpdateBlogAsync(int id, BlogPostDto postDto);
        Task<BlogGetDto> GetBlogAsync(int id);
        Task<List<BlogGetDto>> GetAllBlog();
        Task DeleteBlogAsync(int id);
        //BlogComment Entity
        Task<BlogCommentGetDto> CreateBlogCommentAsync(BlogCommentPostDto postDto);
        Task<BlogCommentGetDto> UpdateBlogCommentAsync(int id, BlogCommentPostDto postDto);
        Task<BlogCommentGetDto> GetBlogCommentAsync(int id);
        Task<List<BlogCommentGetDto>> GetAllBlogComment(int id);
        Task DeleteBlogCommentAsync(int id);
        //ReplyComment Entity
        Task<ReplyCommentGetDto> CreateReplyCommentAsync(ReplyCommentPostDto postDto);
        Task<ReplyCommentGetDto> UpdateReplyCommentAsync(int id, ReplyCommentPostDto postDto);
        Task<ReplyCommentGetDto> GetReplyCommentAsync(int id);
        Task<List<ReplyCommentGetDto>> GetAllReplyComment(int id);
        Task DeleteReplyCommentAsync(int id);

    }
}
