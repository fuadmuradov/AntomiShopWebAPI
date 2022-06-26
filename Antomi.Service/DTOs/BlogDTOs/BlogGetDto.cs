using Antomi.Service.DTOs.AppUserDTOs;
using Antomi.Service.DTOs.BlogCommentDTOs;
using Antomi.Service.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.BlogDTOs
{
    public class BlogGetDto
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Emphasis { get; set; }
        public DateTime CreatedAt { get; set; }
        public CategoryGetDto Category { get; set; }
        public AppUserGetDto AppUser { get; set; }
        public List<BlogCommentGetDto> BlogComments { get; set; }
    }
}
