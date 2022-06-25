using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Core.Entities
{
    public class Blog : BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
  
        public string Emphasis { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<BlogComment> BlogComments { get; set; }

    }
}
