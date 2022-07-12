using Antomi.Service.DTOs;
using Antomi.Service.DTOs.CategoryDTOs;
using Antomi.Service.DTOs.MarkaDTOs;
using Antomi.Service.DTOs.SubCategoryDTOs;
using Antomi.Service.DTOs.SubCategoryToMarkaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.Interfaces
{
    public interface ICategoryService
    {
        // Category Entity
        Task<CategoryGetDto> CreateAsync(CategoryPostDto postDto);
        Task<CategoryGetDto> UpdateAsync(int id, CategoryPostDto postDto);
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task<PaginatedListDto<CategoryListItemDto>> GetAll(int PageIndex);
        Task Delete(int id);
        //Marka Entity
        Task<MarkaGetDto> CreateMarkaAsync(MarkaPostDto postDto);
        Task<MarkaGetDto> UpdateMarkaAsync(int id, MarkaPostDto postDto);
        Task<MarkaGetDto> GetMarkaAsync(int id);
        Task<List<MarkaGetDto>> GetAllMarka();
        Task DeleteMarka(int id);
        //SubCategory Entity
        Task<SubCategoryGetDto> CreateSubCategoryAsync(SubCategoryPostDto postDto);
        Task<SubCategoryGetDto> UpdateSubCategoryAsync(int id, SubCategoryPostDto postDto);
        Task<SubCategoryGetDto> GetSubCategoryAsync(int id);
        Task<List<SubCategoryGetDto>> GetAllSubCategory();
        Task DeleteSubCategory(int id);
        //SubCategoryToMarka Entity
        Task<SubCategoryMarkaGetDto> CreateSubCategoryMarkaAsync(SubCategoryMarkaPostDto postDto);
        Task<SubCategoryMarkaGetDto> UpdateSubCategoryMarkaAsync(int id, SubCategoryMarkaPostDto postDto);
        Task<SubCategoryMarkaGetDto> GetSubCategoryMarkaAsync(int id);
        Task<List<SubCategoryMarkaGetDto>> GetAllSubCategoryMarka();
        Task DeleteSubCategoryMarkaAsync(int id);


    }
}
