using Antomi.Core;
using Antomi.Core.Entities;
using Antomi.Service.DTOs.SliderDTOs;
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
    public class SliderService : ISliderService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SliderService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<SliderGetDto> CreateSliderAsync(SliderPostDto postDto)
        {
            Slider slider = mapper.Map<Slider>(postDto);
            await unitOfWork.SliderRepository.AddAsync(slider);
            await unitOfWork.SliderRepository.SaveDbAsync();
            SliderGetDto sliderGet = mapper.Map<SliderGetDto>(slider);
            return sliderGet;
        }

        public async Task DeleteSlider(int id)
        {
            Slider slider = await unitOfWork.SliderRepository.GetAsync(x => x.Id == id);
            if (slider == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            unitOfWork.SliderRepository.Remove(slider);
            await unitOfWork.SliderRepository.SaveDbAsync();
        }

        public async Task<List<SliderGetDto>> GetAllSliderAsync()
        {
            List<Slider> sliders = unitOfWork.SliderRepository.GetAll(x => x.Id > 0).ToList();
            List<SliderGetDto> sliderGetDtos = mapper.Map<List<Slider>, List<SliderGetDto>>(sliders);
            return sliderGetDtos;
        }

        public async Task<SliderGetDto> GetSliderAsync(int id)
        {
            Slider slider = await unitOfWork.SliderRepository.GetAsync(x => x.Id == id);
            if (slider == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            SliderGetDto sliderGet = mapper.Map<SliderGetDto>(slider);
            return sliderGet;
        }

        public async Task<SliderGetDto> UpdateSliderAsync(int id, SliderPostDto postDto)
        {
            Slider slider = await unitOfWork.SliderRepository.GetAsync(x => x.Id == id);
            if (slider == null)
                throw new ItemNotFoundException("Item Not Found by Id(" + id + ")");
            slider.Image = postDto.Image;
            slider.Title = postDto.Title;
            slider.Discount = postDto.Discount;
            await unitOfWork.SliderRepository.SaveDbAsync();                
            SliderGetDto sliderGet = mapper.Map<SliderGetDto>(slider);
            return sliderGet;
        }
    }
}
