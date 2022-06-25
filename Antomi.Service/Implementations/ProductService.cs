using Antomi.Core;
using Antomi.Core.Entities;
using Antomi.Service.DTOs.CommentDTOs;
using Antomi.Service.DTOs.NotebookSpecDTOs;
using Antomi.Service.DTOs.PhoneSpecDTOs;
using Antomi.Service.DTOs.ProductColorDTOs;
using Antomi.Service.DTOs.ProductColorImageDTOs;
using Antomi.Service.DTOs.ProductDTOs;
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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ProductGetDto> CreateProductAsync(ProductPostDto postDto)
        {
            Product product = mapper.Map<Product>(postDto);
            await unitOfWork.ProductRepository.AddAsync(product);
            await unitOfWork.ProductRepository.SaveDbAsync();
            ProductGetDto productGet = mapper.Map<ProductGetDto>(product);
            return productGet;
        }

        public async Task<ProductColorGetDto> CreateProductColorAsync(ProductColorPostDto postDto)
        {
            ProductColor productColor = mapper.Map<ProductColor>(postDto);
            await unitOfWork.ProductColorRepository.AddAsync(productColor);
            await unitOfWork.ProductColorRepository.SaveDbAsync();
            ProductColorGetDto productColorGet = mapper.Map<ProductColorGetDto>(productColor);
            return productColorGet;

        }

        public async Task<ProductColorImageGetDto> CreateProductColorImageAsync(ProductColorImagePostDto postDto)
        {
            ProductColorImage productColorImage = mapper.Map<ProductColorImage>(postDto);
            await unitOfWork.ProductColorImageRepository.AddAsync(productColorImage);
            await unitOfWork.ProductColorImageRepository.SaveDbAsync();
            ProductColorImageGetDto productColorImageGet = mapper.Map<ProductColorImageGetDto>(productColorImage);
            return productColorImageGet;
        }

        public async Task DeleteProductAsync(int id)
        {
            Product product = await unitOfWork.ProductRepository.GetAsync(x => x.Id == id && x.isDeleted == false);
            if (product == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            unitOfWork.ProductRepository.Remove(product);
            await unitOfWork.ProductRepository.SaveDbAsync();

        }

        public async Task DeleteProductColorAsync(int id)
        {
            ProductColor productColor = await unitOfWork.ProductColorRepository.GetAsync(x => x.Id == id);
            if (productColor == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            unitOfWork.ProductColorRepository.Remove(productColor);
            await unitOfWork.ProductColorRepository.SaveDbAsync();
        }

        public async Task DeleteProductColorImageAsync(int id)
        {
            ProductColorImage productColorImage = await unitOfWork.ProductColorImageRepository.GetAsync(x => x.Id == id && x.isDeleted == false);
            if (productColorImage == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            unitOfWork.ProductColorImageRepository.Remove(productColorImage);
            await unitOfWork.ProductColorImageRepository.SaveDbAsync();
        }

        public async Task<List<ProductGetDto>> GetAllProductAsync()
        {
            List<Product> product = unitOfWork.ProductRepository.GetAll(x => x.isDeleted == false, "Marka", "SubCategory",
                "Specification", "Comment", "Comment.AppUser", "NotebookSpecification", "PhoneSpecification").ToList();
            List<ProductGetDto> productGets = mapper.Map<List<Product>, List<ProductGetDto>>(product);
            //.Select(x => new ProductGetDto
            //{
            //    Id = x.Id,
            //    Model = x.Model,
            //    Description = x.Description,
            //    MarkaName = x.Marka.Name,
            //    SubCategoryName = x.SubCategory.Name,
            //    Comments = x.Comments.Select(y => new CommentGetDto
            //    {
            //        Id = y.Id,
            //        AppUserName = y.AppUser.UserName,
            //        CretadAt = y.CretadAt,
            //        Email = y.Email,
            //        isActive = y.isActive,
            //        ProductName = y.Product.Model,
            //        Text = y.Text,
            //        Username = y.Username
            //    }).ToList(),
            //     NotebookSpecifications = mapper.Map<List<NotebookSpecGetDto>>(x.NotebookSpecifications),
            //     PhoneSpecifications = mapper.Map<List<PhoneSpecGetDto>>(x.PhoneSpecifications),
            //}).ToList();

            return productGets;
        }

        public Task<List<ProductColorGetDto>> GetAllProductColorAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductColorImageGetDto>> GetAllProductColorImageAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductGetDto> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductColorGetDto> GetProductColorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductColorImageGetDto> GetProductColorImageAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductGetDto> UpdateProductAsync(int id, ProductPostDto postDto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductColorGetDto> UpdateProductColorAsync(int id, ProductColorPostDto postDto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductColorImageGetDto> UpdateProductColorImageAsync(int id, ProductColorImagePostDto postDto)
        {
            throw new NotImplementedException();
        }
    }
}
