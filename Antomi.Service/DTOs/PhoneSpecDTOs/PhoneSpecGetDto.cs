using Antomi.Service.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.PhoneSpecDTOs
{
    public class PhoneSpecGetDto
    {
        public int Id { get; set; }
        public int RAM { get; set; }
        public string Storage { get; set; }
        public string DisplayType { get; set; }
        public string OS { get; set; }
        public string MainCamera { get; set; }
        public string SelfieCamera { get; set; }
        public string Processor { get; set; }
        public ProductItemGetDto Product { get; set; }
    }
}
