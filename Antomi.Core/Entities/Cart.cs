using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Core.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductColorId { get; set; }
        public ProductColor ProductColor { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public bool IsDeleted { get; set; }
    }
}
