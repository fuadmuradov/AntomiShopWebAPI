using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.ProductDTOs
{
    public class ProductItemGetDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
    }
}
