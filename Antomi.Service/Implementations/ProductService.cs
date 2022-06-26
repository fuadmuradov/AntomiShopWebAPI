using Antomi.Core;
using Antomi.Core.Entities;
using Antomi.Service.DTOs.CommentDTOs;
using Antomi.Service.DTOs.NotebookSpecDTOs;
using Antomi.Service.DTOs.PhoneSpecDTOs;
using Antomi.Service.DTOs.ProductColorDTOs;
using Antomi.Service.DTOs.ProductColorImageDTOs;
using Antomi.Service.DTOs.ProductDTOs;
using Antomi.Service.DTOs.SpecificationDTOs;
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

        public async Task<NotebookSpecGetDto> CreateNotebookSpecAsync(NotebookSpecPostDto postDto)
        {
            NotebookSpecification notebook = mapper.Map<NotebookSpecification>(postDto);
            await unitOfWork.NotebookSpecRepository.AddAsync(notebook);
            await unitOfWork.NotebookSpecRepository.SaveDbAsync();
            NotebookSpecGetDto notebookSpecGet = mapper.Map<NotebookSpecGetDto>(notebook);
            return notebookSpecGet;
        }

        public async Task<PhoneSpecGetDto> CreatePhoneSpecAsync(PhoneSpecPostDto postDto)
        {
            PhoneSpecification phone = mapper.Map<PhoneSpecification>(postDto);
            await unitOfWork.PhoneSpecRepository.AddAsync(phone);
            await unitOfWork.PhoneSpecRepository.SaveDbAsync();
            PhoneSpecGetDto phoneSpecGet = mapper.Map<PhoneSpecGetDto>(phone);
            return phoneSpecGet;
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

        public async Task<SpecificationGetDto> CreateSpecificationAsync(SpecificationPostDto postDto)
        {
            Specification spec = mapper.Map<Specification>(postDto);
            await unitOfWork.SpecificationRepository.AddAsync(spec);
            await unitOfWork.SpecificationRepository.SaveDbAsync();
            SpecificationGetDto specGet = mapper.Map<SpecificationGetDto>(spec);
            return specGet;
        }

        public async Task DeleteNotebookSpecAsync(int id)
        {
            NotebookSpecification specification = await unitOfWork.NotebookSpecRepository.GetAsync(x => x.Id == id);
            if (specification == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            unitOfWork.NotebookSpecRepository.Remove(specification);
            await unitOfWork.NotebookSpecRepository.SaveDbAsync();
        }

        public async Task DeletePhoneSpecAsync(int id)
        {
            PhoneSpecification phoneSpecification = await unitOfWork.PhoneSpecRepository.GetAsync(x => x.Id == id);
            if (phoneSpecification == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            unitOfWork.PhoneSpecRepository.Remove(phoneSpecification);
            await unitOfWork.PhoneSpecRepository.SaveDbAsync();
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

        public async Task DeleteSpecificationAsync(int id)
        {
            Specification specification = await unitOfWork.SpecificationRepository.GetAsync(x => x.Id == id);
            if (specification == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            unitOfWork.SpecificationRepository.Remove(specification);
            await unitOfWork.SpecificationRepository.SaveDbAsync();
        }

        public async Task<List<NotebookSpecGetDto>> GetAllNotebookSpecAsync()
        {
            List<NotebookSpecification> notebookSpecifications = unitOfWork.NotebookSpecRepository.GetAll(x => x.Id > 0, "Product").ToList();
            List<NotebookSpecGetDto> notebookSpecGets = mapper.Map<List<NotebookSpecification>, List<NotebookSpecGetDto>>(notebookSpecifications);
            return notebookSpecGets;
        }

        public async Task<List<PhoneSpecGetDto>> GetAllPhoneSpecAsync()
        {
            List<PhoneSpecification> phoneSpecifications = unitOfWork.PhoneSpecRepository.GetAll(x => x.Id > 0, "Product").ToList();
            List<PhoneSpecGetDto> phoneSpecGets = mapper.Map<List<PhoneSpecification>, List<PhoneSpecGetDto>>(phoneSpecifications);
            return phoneSpecGets;
        }

        public async Task<List<ProductGetDto>> GetAllProductAsync()
        {
            List<Product> product = unitOfWork.ProductRepository.GetAll(x => x.isDeleted == false, "Marka", "SubCategory","ProductColors",
              "Specifications", "Comments", "NotebookSpecifications", "PhoneSpecifications").ToList();
            List<ProductGetDto> productGets = mapper.Map<List<Product>, List<ProductGetDto>>(product);
           
            return productGets;
        }

        public async Task<List<ProductColorGetDto>> GetAllProductColorAsync()
        {
            List<ProductColor> productColor = unitOfWork.ProductColorRepository.GetAll(x => x.Id > 0, "Product", "ProductColorImages", "Discounts").ToList();
            List<ProductColorGetDto> productColorGets = mapper.Map<List<ProductColor>, List<ProductColorGetDto>>(productColor);
            return productColorGets;
        }

        public async Task<List<ProductColorImageGetDto>> GetAllProductColorImageAsync()
        {
            List<ProductColorImage> productColorImages = unitOfWork.ProductColorImageRepository.GetAll(x => x.isDeleted == false, "ProductColor").ToList();
            List<ProductColorImageGetDto> productColorImageGetDtos = mapper.Map<List<ProductColorImage>, List<ProductColorImageGetDto>>(productColorImages);
            return productColorImageGetDtos;
        }

        public async Task<List<SpecificationGetDto>> GetAllSpecificationAsync(int id)
        {
            List<Specification> specifications = unitOfWork.SpecificationRepository.GetAll(x => x.Id == id, "Product").ToList();
            List<SpecificationGetDto> specificationGetDtos = mapper.Map<List<Specification>, List<SpecificationGetDto>>(specifications);
            return specificationGetDtos;
        }

        public async Task<NotebookSpecGetDto> GetNotebookSpecAsync(int id)
        {
            NotebookSpecification notebookSpecification = await unitOfWork.NotebookSpecRepository.GetAsync(x => x.Id == id);
            if (notebookSpecification == null)
                throw new ItemNotFoundException("Item Not Found ny Id (" + id + ")");
            NotebookSpecGetDto notebookSpecGetDto = mapper.Map<NotebookSpecGetDto>(notebookSpecification);
            return notebookSpecGetDto;
        }

        public async Task<PhoneSpecGetDto> GetPhoneSpecAsync(int id)
        {
            PhoneSpecification phoneSpecification = await unitOfWork.PhoneSpecRepository.GetAsync(x => x.Id == id);
            if (phoneSpecification == null)
                throw new ItemNotFoundException("Item Not Found ny Id (" + id + ")");
            PhoneSpecGetDto phoneSpecGetDto = mapper.Map<PhoneSpecGetDto>(phoneSpecification);
            return phoneSpecGetDto;
        }

        public async Task<ProductGetDto> GetProductAsync(int id)
        {
            Product product = await unitOfWork.ProductRepository.GetAsync(x => x.Id == id && x.isDeleted == false, "Marka", "SubCategory", "ProductColors"
              , "Specifications", "Comments", "NotebookSpecifications", "PhoneSpecifications");
            if (product == null)
                throw new ItemNotFoundException("Item Not Found ny Id (" + id + ")");
            ProductGetDto productColorGet = mapper.Map<ProductGetDto>(product);
            return productColorGet;
        }

        public async Task<ProductColorGetDto> GetProductColorAsync(int id)
        {
            ProductColor productColor = await unitOfWork.ProductColorRepository.GetAsync(x => x.Id == id, "Product", "ProductColorImages", "Discounts");
            if (productColor == null)
                throw new ItemNotFoundException("Item Not Found ny Id (" + id + ")");
            ProductColorGetDto productColorGet = mapper.Map<ProductColorGetDto>(productColor);
            return productColorGet;
        }

        public async Task<ProductColorImageGetDto> GetProductColorImageAsync(int id)
        {
            ProductColorImage productColorImage = await unitOfWork.ProductColorImageRepository.GetAsync(x=>x.Id==id && x.isDeleted==false, "ProductColor");
            if (productColorImage == null)
                throw new ItemNotFoundException("Item Not Found ny Id (" + id + ")");
            ProductColorImageGetDto productColorImageGet = mapper.Map<ProductColorImageGetDto>(productColorImage);
            return productColorImageGet;
        }

        public async Task<SpecificationGetDto> GetSpecificationAsync(int id)
        {
            Specification specification = await unitOfWork.SpecificationRepository.GetAsync(x => x.Id == id);
            if (specification == null)
                throw new ItemNotFoundException("Item Not Found ny Id (" + id + ")");
            SpecificationGetDto specGetDto = mapper.Map<SpecificationGetDto>(specification);
            return specGetDto;
        }


        public async Task<NotebookSpecGetDto> UpdateNotebookSpecAsync(int id, NotebookSpecPostDto postDto)
        {
            NotebookSpecification notebookSpecification = await unitOfWork.NotebookSpecRepository.GetAsync(x => x.Id == id);
            if (notebookSpecification == null)
                throw new ItemNotFoundException("Item Not Found ny Id (" + id + ")");
            notebookSpecification.Graphics = postDto.Graphics;
            notebookSpecification.OS = postDto.OS;
            notebookSpecification.Processor = postDto.Processor;
            notebookSpecification.ProductId = postDto.ProductId;
            notebookSpecification.RAM = postDto.RAM;
            notebookSpecification.Storage = postDto.Storage;

            NotebookSpecGetDto notebookSpecGetDto = mapper.Map<NotebookSpecGetDto>(notebookSpecification);
            return notebookSpecGetDto;
        
        }

        public async Task<PhoneSpecGetDto> UpdatePhoneSpecAsync(int id, PhoneSpecPostDto postDto)
        {
            PhoneSpecification phoneSpecification = await unitOfWork.PhoneSpecRepository.GetAsync(x => x.Id == id);
            if (phoneSpecification == null)
                throw new ItemNotFoundException("Item Not Found ny Id (" + id + ")");
            phoneSpecification.DisplayType = postDto.DisplayType;
            phoneSpecification.MainCamera = postDto.MainCamera;
            phoneSpecification.SelfieCamera = postDto.SelfieCamera;
            phoneSpecification.OS = postDto.OS;
            phoneSpecification.Processor = postDto.Processor;
            phoneSpecification.ProductId = postDto.ProductId;
            phoneSpecification.RAM = postDto.RAM;
            phoneSpecification.Storage = postDto.Storage;

            PhoneSpecGetDto phoneSpecGetDto = mapper.Map<PhoneSpecGetDto>(phoneSpecification);
            return phoneSpecGetDto;
        }

        public async Task<ProductGetDto> UpdateProductAsync(int id, ProductPostDto postDto)
        {
            Product existProduct = await unitOfWork.ProductRepository.GetAsync(x => x.Id == id && x.isDeleted == false);
            if (existProduct == null)
                throw new ItemNotFoundException("Item Not Found By Id (" + id + ")");
            existProduct.Model = postDto.Model;
            existProduct.Description = postDto.Description;
            existProduct.MarkaId = postDto.MarkaId;
            existProduct.SubCategoryId = postDto.SubCategoryId;
            await unitOfWork.ProductRepository.SaveDbAsync();
            ProductGetDto productGet = mapper.Map<ProductGetDto>(existProduct);
            return productGet;
        }

        public async Task<ProductColorGetDto> UpdateProductColorAsync(int id, ProductColorPostDto postDto)
        {
            ProductColor existProductColor = await unitOfWork.ProductColorRepository.GetAsync(x => x.Id == id);
            if (existProductColor == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            existProductColor.Name = postDto.Name;
            existProductColor.Price = postDto.Price;
            existProductColor.Count = postDto.Count;
            existProductColor.ProductId = postDto.ProductId;
            await unitOfWork.ProductColorRepository.SaveDbAsync();
            ProductColorGetDto productColorGet = mapper.Map<ProductColorGetDto>(existProductColor);
            return productColorGet;
        }

        public async Task<ProductColorImageGetDto> UpdateProductColorImageAsync(int id, ProductColorImagePostDto postDto)
        {
            ProductColorImage existProductColorImage = await unitOfWork.ProductColorImageRepository.GetAsync(x => x.Id == id && x.isDeleted == false);
            if (existProductColorImage == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            existProductColorImage.IsMain = postDto.IsMain;
            existProductColorImage.Image = postDto.Image;
            existProductColorImage.ProductColorId = postDto.ProductColorId;

            ProductColorImageGetDto productColorImageGet = mapper.Map<ProductColorImageGetDto>(existProductColorImage);
            return productColorImageGet;

        }

        public async Task<SpecificationGetDto> UpdateSpecificationAsync(int id, SpecificationPostDto postDto)
        {
            Specification existSpecification = await unitOfWork.SpecificationRepository.GetAsync(x => x.Id == id);
            if (existSpecification == null)
                throw new ItemNotFoundException("Item Not Found by Id (" + id + ")");
            existSpecification.Name = postDto.Name;
            existSpecification.Description = postDto.Description;
            existSpecification.ProductId = postDto.ProductId;

            SpecificationGetDto specificationGet = mapper.Map<SpecificationGetDto>(existSpecification);
            return specificationGet;

        }
    }
}
