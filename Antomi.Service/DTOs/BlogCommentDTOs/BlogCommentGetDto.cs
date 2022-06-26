using Antomi.Service.DTOs.AppUserDTOs;
using Antomi.Service.DTOs.BlogDTOs;
using Antomi.Service.DTOs.ReplyCommentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.BlogCommentDTOs
{
    public class BlogCommentGetDto
    {
        public int Id { get; set; }
        public AppUserGetDto AppUser { get; set; }
        public string Text { get; set; }
        public BlogGetDto Blog { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<ReplyCommentGetDto> ReplyComments { get; set; }
    }
}
