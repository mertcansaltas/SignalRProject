using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Interfaces;
using SignalR.DtoLayer.AboutDto;
using SignalRApi.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService aboutService;
        private readonly IMapper mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            this.aboutService = aboutService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = aboutService.TGetAllList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = mapper.Map<About>(createAboutDto);
            aboutService.TAdd(about);
            return Ok("Hakkımda kısmı başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = aboutService.TGetByID(id);
            aboutService.TDelete(value);
            return Ok("Hakkımda kısmı silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = mapper.Map<About>(updateAboutDto);
            aboutService.TUpdate(about);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value=aboutService.TGetByID(id);
            return Ok(value);
        }

    }
}
