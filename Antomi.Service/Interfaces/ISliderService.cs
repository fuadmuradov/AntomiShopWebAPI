using Antomi.Service.DTOs.SliderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.Interfaces
{
    public interface ISliderService
    {
        Task<SliderGetDto> CreateSliderAsync(SliderPostDto postDto);
        Task<SliderGetDto> UpdateSliderAsync(int id, SliderPostDto postDto);
        Task<SliderGetDto> GetSliderAsync(int id);
        Task<List<SliderGetDto>> GetAllSliderAsync();
        Task DeleteSlider(int id);
    }
}
