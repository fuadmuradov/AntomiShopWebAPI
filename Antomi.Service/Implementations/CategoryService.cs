﻿using Antomi.Core.Entities;
using Antomi.Core.IRepositories;
using Antomi.Service.DTOs.CategoryDTOs;
using Antomi.Service.Exceptions;
using Antomi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<CategoryGetDto> CreateAsync(CategoryPostDto postDto)
        {
            if (await categoryRepository.IsExistAsync(x => x.Name.ToUpper() == postDto.Name.ToUpper() && x.isDeleted == false))
                throw new RecordDublicateException("This Category Already Exist(" + postDto.Name + ")");

            Category category = new Category()
            {
                Name = postDto.Name
            };

           await categoryRepository.AddAsync(category);
           await categoryRepository.SaveDbAsync();
            CategoryGetDto categoryGetDto = new CategoryGetDto()
            {
                Id = category.Id,
                Name = category.Name
            };
            return categoryGetDto;


        }

        public async Task Delete(int id)
        {
            if (!await categoryRepository.IsExistAsync(x => x.Id == id && x.isDeleted == false))
                throw new ItemNotFoundException("Item Not Found by Id(" +id+ ")");
            Category category = await categoryRepository.GetAsync(x => x.Id == id && x.isDeleted == false);

            categoryRepository.Remove(category);
            await categoryRepository.SaveDbAsync();
        }

        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            Category category = await categoryRepository.GetAsync(x => x.Id == id && x.isDeleted == false);
            if(category==null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id.ToString() + ")");
            if (!await categoryRepository.IsExistAsync(x => x.Id == id && x.isDeleted == false))
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
            if (!await categoryRepository.IsExistAsync(x => x.Id == id && x.isDeleted == false))
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            if (await categoryRepository.IsExistAsync(x => x.Name.ToUpper() == postDto.Name.ToUpper() && x.isDeleted == false))
                throw new RecordDublicateException("This Category Already Exist(" + postDto.Name + ")");
            Category category = await categoryRepository.GetAsync(x => x.Id == id && x.isDeleted == false);
            category.Name = postDto.Name;
            await categoryRepository.SaveDbAsync();
            CategoryGetDto categoryGetDto = new CategoryGetDto()
            {
                Id = category.Id,
                Name = category.Name
            };
            return categoryGetDto;


        }
    }
}
