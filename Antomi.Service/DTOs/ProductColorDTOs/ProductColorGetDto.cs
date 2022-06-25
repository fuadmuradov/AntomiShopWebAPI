using Antomi.Service.DTOs.DiscountDTOs;
using Antomi.Service.DTOs.ProductColorImageDTOs;
using Antomi.Service.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.ProductColorDTOs
{
    public class ProductColorGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public ProductGetDto Product { get; set; }
        public List<ProductColorImageGetDto> ProductColorImages { get; set; }
        public List<DiscountGetDto> Discounts { get; set; }
    }
}
