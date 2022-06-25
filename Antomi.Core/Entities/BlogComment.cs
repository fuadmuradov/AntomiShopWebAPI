using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Core.Entities
{
    public class BlogComment
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Text { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<ReplyComment> ReplyComments { get; set; }

    }
}
