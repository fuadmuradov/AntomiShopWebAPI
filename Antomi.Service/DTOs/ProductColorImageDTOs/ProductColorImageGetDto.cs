using Antomi.Service.DTOs.ProductColorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.ProductColorImageDTOs
{
    public class ProductColorImageGetDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsMain { get; set; }
        public ProductColorItemGetDto ProductColor { get; set; }
    }
}
