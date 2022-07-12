using Antomi.Core;
using Antomi.Core.Entities;
using Antomi.Core.IRepositories;
using Antomi.Service.DTOs;
using Antomi.Service.DTOs.CategoryDTOs;
using Antomi.Service.DTOs.MarkaDTOs;
using Antomi.Service.DTOs.SubCategoryDTOs;
using Antomi.Service.DTOs.SubCategoryToMarkaDTOs;
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

        public async Task<MarkaGetDto> CreateMarkaAsync(MarkaPostDto postDto)
        {
            Marka marka = mapper.Map<Marka>(postDto);
            await unitOfWork.MarkaRepository.AddAsync(marka);
            await unitOfWork.MarkaRepository.SaveDbAsync();
            MarkaGetDto markaGet = mapper.Map<MarkaGetDto>(marka);
            return markaGet;
        }

        public async Task<SubCategoryGetDto> CreateSubCategoryAsync(SubCategoryPostDto postDto)
        {
            SubCategory subCategory = mapper.Map<SubCategory>(postDto);
             unitOfWork.SubCategoryRepository.AddAsync(subCategory).Wait();
             unitOfWork.SubCategoryRepository.SaveDbAsync().Wait();
            SubCategoryGetDto subCategoryGetDto = mapper.Map<SubCategoryGetDto>(subCategory);
            return subCategoryGetDto;
        }

        public async Task<SubCategoryMarkaGetDto> CreateSubCategoryMarkaAsync(SubCategoryMarkaPostDto postDto)
        {
            SubcategoryToMarka subcategoryToMarka = mapper.Map<SubcategoryToMarka>(postDto);
             await unitOfWork.SubCategoryMarkaRepository.AddAsync(subcategoryToMarka);
             unitOfWork.SubCategoryMarkaRepository.SaveDbAsync().Wait();
            SubCategoryMarkaGetDto subCategoryMarkaGet = mapper.Map<SubCategoryMarkaGetDto>(subcategoryToMarka);
            return subCategoryMarkaGet;
        }

        public async Task Delete(int id)
        {
            if (!await unitOfWork.CategoryRepository.IsExistAsync(x => x.Id == id && x.isDeleted == false))
                throw new ItemNotFoundException("Item Not Found by Id(" +id+ ")");
            Category category = await unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && x.isDeleted == false);

            unitOfWork.CategoryRepository.Remove(category);
            await unitOfWork.CategoryRepository.SaveDbAsync();
        }

        public async Task DeleteMarka(int id)
        {
            Marka marka = await unitOfWork.MarkaRepository.GetAsync(x => x.Id == id && x.isDeleted == false);
            if (marka == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            unitOfWork.MarkaRepository.Remove(marka);
            await unitOfWork.MarkaRepository.SaveDbAsync();

        }

        public async Task DeleteSubCategory(int id)
        {
            SubCategory subCategory = await unitOfWork.SubCategoryRepository.GetAsync(x => x.Id == id && x.isDeleted == false);
            if (subCategory == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            unitOfWork.SubCategoryRepository.Remove(subCategory);
            await unitOfWork.SubCategoryRepository.SaveDbAsync();
        }

        public async Task DeleteSubCategoryMarkaAsync(int id)
        {
            SubcategoryToMarka subcategoryToMarka = await unitOfWork.SubCategoryMarkaRepository.GetAsync(x => x.Id == id);
            if (subcategoryToMarka == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            unitOfWork.SubCategoryMarkaRepository.Remove(subcategoryToMarka);
            await unitOfWork.SubCategoryMarkaRepository.SaveDbAsync();
        }

        public async Task<PaginatedListDto<CategoryListItemDto>> GetAll(int PageIndex)
        {
            if (PageIndex < 0)
                throw new PageIndexIncorrectException("Page Index Not correct");
            string PageSizeStr =await unitOfWork.SettingRepository.GetValue("PageSize");
            int PageSize = Convert.ToInt32(PageSizeStr);
            var query = unitOfWork.CategoryRepository.GetAll(x => !x.isDeleted);
            var items = query.Skip((PageIndex - 1) * PageSize).Take(PageSize).Select(x=> new CategoryListItemDto {Id = x.Id, Name=x.Name }).ToList();
            var listItem = new PaginatedListDto<CategoryListItemDto>(items, query.Count(), PageSize, PageIndex);
            return listItem;
        }

        public async Task<List<MarkaGetDto>> GetAllMarka()
        {
            List<MarkaGetDto> markas =  unitOfWork.MarkaRepository.GetAll(x => x.Id > 0)
                .Select(x=> new MarkaGetDto
                { Id = x.Id,
                Name = x.Name
                }).ToList();
            return markas;
        }

        public async Task<List<SubCategoryGetDto>> GetAllSubCategory()
        {
            List<SubCategory> subCategories = unitOfWork.SubCategoryRepository.GetAll(x => x.Id > 0, "Category").ToList();
            List<SubCategoryGetDto> subCategoryGets = mapper.Map<List<SubCategory>, List<SubCategoryGetDto>>(subCategories);

            //List<SubCategoryGetDto> subCategoryGets = unitOfWork.SubCategoryRepository.GetAll(x => x.Id > 0, "Category")
            //      .Select(x => new SubCategoryGetDto { Id = x.Id, Name = x.Name, CategoryName = x.Category.Name }).ToList();

            return subCategoryGets;
        }

        public async Task<List<SubCategoryMarkaGetDto>> GetAllSubCategoryMarka()
        {
            List<SubcategoryToMarka> subcategoryToMarkas = unitOfWork.SubCategoryMarkaRepository.GetAll(x => x.Id > 0, "Marka", "SubCategory").ToList();
            List<SubCategoryMarkaGetDto> subCategoryMarkaGets = mapper.Map<List<SubcategoryToMarka>, List<SubCategoryMarkaGetDto>>(subcategoryToMarkas);
            return subCategoryMarkaGets;
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

        public async Task<MarkaGetDto> GetMarkaAsync(int id)
        {
            Marka marka = await unitOfWork.MarkaRepository.GetAsync(x => x.Id == id && x.isDeleted == false);
            if (marka == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            MarkaGetDto markaGet = mapper.Map<MarkaGetDto>(marka);
            return markaGet;
        }

        public async Task<SubCategoryGetDto> GetSubCategoryAsync(int id)
        {
            SubCategory subCategory = await unitOfWork.SubCategoryRepository.GetAsync(x => x.Id == id && x.isDeleted == false, "Category");
            if (subCategory == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            SubCategoryGetDto subCategoryGet = mapper.Map<SubCategoryGetDto>(subCategory);
            return subCategoryGet;

        }

        public async Task<SubCategoryMarkaGetDto> GetSubCategoryMarkaAsync(int id)
        {
            SubcategoryToMarka subcategoryToMarka = await unitOfWork.SubCategoryMarkaRepository.GetAsync(x => x.Id == id, "Marka", "SubCategory");
            if (subcategoryToMarka == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            SubCategoryMarkaGetDto subCategoryMarkaGet = mapper.Map<SubCategoryMarkaGetDto>(subcategoryToMarka);
            return subCategoryMarkaGet;
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

        public async Task<MarkaGetDto> UpdateMarkaAsync(int id, MarkaPostDto postDto)
        {
            if (await unitOfWork.MarkaRepository.IsExistAsync(x => x.Name.ToUpper() == postDto.Name.ToUpper() && x.isDeleted == false))
                throw new RecordDublicateException("("+postDto.Name+")  Name Already Exist");
            Marka existMarka = await unitOfWork.MarkaRepository.GetAsync(x => x.Id == id && x.isDeleted == false);
            if (existMarka == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            existMarka.Name = postDto.Name;
            existMarka.ModifiedAt = DateTime.UtcNow.AddHours(+4);
            await unitOfWork.MarkaRepository.SaveDbAsync();
            MarkaGetDto markaGet = mapper.Map<MarkaGetDto>(existMarka);
            return markaGet;
        }

        public async Task<SubCategoryGetDto> UpdateSubCategoryAsync(int id, SubCategoryPostDto postDto)
        {
            if (await unitOfWork.SubCategoryRepository.IsExistAsync(x => x.Name.ToUpper() == postDto.Name.ToUpper() && x.isDeleted == false))
                throw new RecordDublicateException("(" + postDto.Name + ")  Name Already Exist");
            SubCategory existSubCategory = await unitOfWork.SubCategoryRepository.GetAsync(x => x.Id == id && x.isDeleted == false);
            if (existSubCategory == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            existSubCategory.Name = postDto.Name;
            existSubCategory.ModifiedAt = DateTime.UtcNow.AddHours(+4);
            existSubCategory.CategoryId = postDto.CategoryId;
            await unitOfWork.SubCategoryRepository.SaveDbAsync();
            SubCategoryGetDto markaGet = mapper.Map<SubCategoryGetDto>(existSubCategory);
            return markaGet;
        }

        public async Task<SubCategoryMarkaGetDto> UpdateSubCategoryMarkaAsync(int id, SubCategoryMarkaPostDto postDto)
        {
            SubcategoryToMarka subcategoryToMarka = await unitOfWork.SubCategoryMarkaRepository.GetAsync(x => x.Id == id);
            if (subcategoryToMarka == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            subcategoryToMarka.MarkaId = postDto.MarkaId;
            subcategoryToMarka.SubCategoryId = postDto.SubCategoryId;
            await unitOfWork.SubCategoryMarkaRepository.SaveDbAsync();
            SubCategoryMarkaGetDto subCategoryMarkaGet = mapper.Map<SubCategoryMarkaGetDto>(subcategoryToMarka);
            return subCategoryMarkaGet;

        }
    }
}
