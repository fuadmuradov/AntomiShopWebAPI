using Antomi.Service.DTOs.CommentDTOs;
using Antomi.Service.DTOs.MarkaDTOs;
using Antomi.Service.DTOs.NotebookSpecDTOs;
using Antomi.Service.DTOs.PhoneSpecDTOs;
using Antomi.Service.DTOs.ProductColorDTOs;
using Antomi.Service.DTOs.SpecificationDTOs;
using Antomi.Service.DTOs.SubCategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.ProductDTOs
{
    public class ProductGetDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public MarkaGetDto Marka { get; set; }
        public SubCategoryGetDto SubCategory { get; set; }

        public List<SpecificationGetDto> Specifications { get; set; }
        public List<CommentGetDto> Comments { get; set; }
        public List<ProductColorGetDto> ProductColors { get; set; }
        public List<PhoneSpecGetDto> PhoneSpecifications { get; set; }
        public List<NotebookSpecGetDto> NotebookSpecifications { get; set; }
    }
}
