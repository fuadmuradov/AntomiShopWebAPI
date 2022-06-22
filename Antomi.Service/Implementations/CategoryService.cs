using Antomi.Core;
using Antomi.Core.Entities;
using Antomi.Core.IRepositories;
using Antomi.Service.DTOs;
using Antomi.Service.DTOs.CategoryDTOs;
using Antomi.Service.Exceptions;
using Antomi.Service.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
     
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<CategoryGetDto> CreateAsync(CategoryPostDto postDto)
        {
            if (await unitOfWork.CategoryRepository.IsExistAsync(x => x.Name.ToUpper() == postDto.Name.ToUpper() && x.isDeleted == false))
                throw new RecordDublicateException("This Category Already Exist(" + postDto.Name + ")");

            Category category = mapper.Map<Category>(postDto);

           await unitOfWork.CategoryRepository.AddAsync(category);
           await unitOfWork.CategoryRepository.SaveDbAsync();
            CategoryGetDto categoryGetDto = mapper.Map<CategoryGetDto>(category);
            return categoryGetDto;


        }

        public async Task Delete(int id)
        {
            if (!await unitOfWork.CategoryRepository.IsExistAsync(x => x.Id == id && x.isDeleted == false))
                throw new ItemNotFoundException("Item Not Found by Id(" +id+ ")");
            Category category = await unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && x.isDeleted == false);

            unitOfWork.CategoryRepository.Remove(category);
            await unitOfWork.CategoryRepository.SaveDbAsync();
        }

        public async Task<PaginatedListDto<CategoryListItemDto>> GetAll(int PageIndex)
        {
            if (PageIndex < 0)
                throw new PageIndexIncorrectException("Page Index Not correct");
            string PageSizeStr =await unitOfWork.SettingRepository.GetValue("PageSize");
            int PageSize = Convert.ToInt32(PageSizeStr);
            var query = unitOfWork.CategoryRepository.GetAll(x => !x.isDeleted);
            var items = query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            var listItem = new PaginatedListDto<CategoryListItemDto>(mapper.Map<List<CategoryListItemDto>>(items), query.Count(), PageSize, PageIndex);
            return listItem;
        }

        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            Category category = await unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && x.isDeleted == false);
            if(category==null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id.ToString() + ")");
            if (!await unitOfWork.CategoryRepository.IsExistAsync(x => x.Id == id && x.isDeleted == false))
                throw new ItemNotFoundException("Item Not Found by Id(" + id.ToString() + ")");
            CategoryGetDto categoryGetDto = new CategoryGetDto()
            {
                Id = category.Id,
                Name = category.Name
            };
            return categoryGetDto;

        }

        public async Task<CategoryGetDto> UpdateAsync(int id, CategoryPostDto postDto)
        {
            if (!await unitOfWork.CategoryRepository.IsExistAsync(x => x.Id == id && x.isDeleted == false))
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            if (await unitOfWork.CategoryRepository.IsExistAsync(x => x.Name.ToUpper() == postDto.Name.ToUpper() && x.isDeleted == false))
                throw new RecordDublicateException("This Category Already Exist(" + postDto.Name + ")");
            Category category = await unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && x.isDeleted == false);
            category.Name = postDto.Name;
            await unitOfWork.CategoryRepository.SaveDbAsync();
            CategoryGetDto categoryGetDto = new CategoryGetDto()
            {
                Id = category.Id,
                Name = category.Name
            };
            return categoryGetDto;


        }
    }
}
