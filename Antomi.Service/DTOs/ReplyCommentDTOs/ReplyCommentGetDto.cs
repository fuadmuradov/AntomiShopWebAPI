using Antomi.Service.DTOs.AppUserDTOs;
using Antomi.Service.DTOs.BlogCommentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.ReplyCommentDTOs
{
    public class ReplyCommentGetDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public BlogCommentGetDto BlogComment { get; set; }
        public AppUserGetDto AppUser { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
