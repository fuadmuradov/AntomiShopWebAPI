using Antomi.Service.DTOs.NotebookSpecDTOs;
using Antomi.Service.DTOs.PhoneSpecDTOs;
using Antomi.Service.DTOs.ProductColorDTOs;
using Antomi.Service.DTOs.ProductColorImageDTOs;
using Antomi.Service.DTOs.ProductDTOs;
using Antomi.Service.DTOs.SpecificationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.Interfaces
{
    public interface IProductService
    {
        //Product Entity
         Task<ProductGetDto> CreateProductAsync(ProductPostDto postDto);
         Task<ProductGetDto> UpdateProductAsync(int id, ProductPostDto postDto);
         Task<ProductGetDto> GetProductAsync(int id);
         Task<List<ProductGetDto>> GetAllProductAsync();
         Task DeleteProductAsync(int id);

        //ProductColor Entity
         Task<ProductColorGetDto> CreateProductColorAsync(ProductColorPostDto postDto);
         Task<ProductColorGetDto> UpdateProductColorAsync(int id, ProductColorPostDto postDto);
         Task<ProductColorGetDto> GetProductColorAsync(int id);
         Task<List<ProductColorGetDto>> GetAllProductColorAsync();
         Task DeleteProductColorAsync(int id);

        //ProducColorImage Entity
         Task<ProductColorImageGetDto> CreateProductColorImageAsync(ProductColorImagePostDto postDto);
         Task<ProductColorImageGetDto> UpdateProductColorImageAsync(int id, ProductColorImagePostDto postDto);
         Task<ProductColorImageGetDto> GetProductColorImageAsync(int id);
         Task<List<ProductColorImageGetDto>> GetAllProductColorImageAsync();
         Task DeleteProductColorImageAsync(int id);

        //Specification Entity
        public Task<SpecificationGetDto> CreateSpecificationAsync(SpecificationPostDto postDto);
        public Task<SpecificationGetDto> UpdateSpecificationAsync(int id, SpecificationPostDto postDto);
        public Task<SpecificationGetDto> GetSpecificationAsync(int id);
        public Task<List<SpecificationGetDto>> GetAllSpecificationAsync(int id);
        public Task DeleteSpecificationAsync(int id);

        //PhoneSpecification Entity
        public Task<PhoneSpecGetDto> CreatePhoneSpecAsync(PhoneSpecPostDto postDto);
        public Task<PhoneSpecGetDto> UpdatePhoneSpecAsync(int id, PhoneSpecPostDto postDto);
        public Task<PhoneSpecGetDto> GetPhoneSpecAsync(int id);
        public Task<List<PhoneSpecGetDto>> GetAllPhoneSpecAsync();
        public Task DeletePhoneSpecAsync(int id);

        //PhoneSpecification Entity
        public Task<NotebookSpecGetDto> CreateNotebookSpecAsync(NotebookSpecPostDto postDto);
        public Task<NotebookSpecGetDto> UpdateNotebookSpecAsync(int id, NotebookSpecPostDto postDto);
        public Task<NotebookSpecGetDto> GetNotebookSpecAsync(int id);
        public Task<List<NotebookSpecGetDto>> GetAllNotebookSpecAsync();
        public Task DeleteNotebookSpecAsync(int id);
    }

}
