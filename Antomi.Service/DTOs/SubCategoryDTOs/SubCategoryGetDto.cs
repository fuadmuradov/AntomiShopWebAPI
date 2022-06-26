using Antomi.Service.DTOs.CategoryDTOs;
using Antomi.Service.DTOs.SubCategoryToMarkaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.DTOs.SubCategoryDTOs
{
    public class SubCategoryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryGetDto Category { get; set; }
        public List<SubCategoryMarkaGetDto> SubCategoryToMarkas { get; set; }

    }
}
