using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Interfaces;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _SliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService SliderService, IMapper mapper)
        {
            _SliderService = SliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var value = _mapper.Map<List<ResultSliderDto>>(_SliderService.TGetAllList());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            Slider Slider = _mapper.Map<Slider>(createSliderDto);
            _SliderService.TAdd(Slider);
            return Ok("Slider eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var values = _SliderService.TGetByID(id);
            _SliderService.TDelete(values);
            return Ok("Slider silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var values = _SliderService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            Slider Slider = _mapper.Map<Slider>(updateSliderDto);
            _SliderService.TUpdate(Slider);
            return Ok("Slider güncellendi");
        }
    }
}
