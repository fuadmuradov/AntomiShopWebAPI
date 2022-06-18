using Antomi.Service.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryGetDto> CreateAsync(CategoryPostDto postDto);
        Task<CategoryGetDto> UpdateAsync(int id, CategoryPostDto postDto);
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task Delete(int id);
    }
}
