using Antomi.Service.DTOs.MarkaDTOs;
using Antomi.Service.DTOs.SubCategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.SubCategoryToMarkaDTOs
{
    public class SubCategoryMarkaGetDto
    {
        public int Id { get; set; }
     
        public MarkaGetDto Marka { get; set; }
        public SubCategoryGetDto SubCategory { get; set; }
    }
}
