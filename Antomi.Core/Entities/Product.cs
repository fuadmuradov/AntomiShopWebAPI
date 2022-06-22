using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Core.Entities
{
    public class Product:BaseEntity
    {
        public string Model { get; set; }
        public string Description { get; set; }
        public int MarkaId { get; set; }
        public Marka Marka { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
