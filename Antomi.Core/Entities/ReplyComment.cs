using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Core.Entities
{
    public class ReplyComment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int BlogCommentId { get; set; }
        public BlogComment BlogComment { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
