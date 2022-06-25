using Antomi.Service.DTOs.ProductColorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.DiscountDTOs
{
    public class DiscountGetDto
    {
        public int Id { get; set; }
        public int Percent { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProductColorGetDto ProductColor { get; set; }
        public bool DealofMonth { get; set; }
    }
}
