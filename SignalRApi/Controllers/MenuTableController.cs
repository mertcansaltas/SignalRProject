using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Interfaces;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTableController : ControllerBase
	{
		private readonly IMenuTableService menuTableService;
        private readonly IMapper mapper;

        public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
        {
            this.menuTableService = menuTableService;
            this.mapper = mapper;
        }

        [HttpGet("MenuTableCount")]	
		public IActionResult MenuTableCount()
		{
			return Ok(menuTableService.TMenuTableCount());
		}
        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = menuTableService.TGetAllList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createmenutableDto)
        {
            MenuTable menutable = mapper.Map<MenuTable>(createmenutableDto);
            menutable.Status = false;
            menuTableService.TAdd(menutable);
            return Ok("Hakkımda kısmı başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = menuTableService.TGetByID(id);
            menuTableService.TDelete(value);
            return Ok("Hakkımda kısmı silindi");
        }
        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updatemenutableDto)
        {
            MenuTable menutable = mapper.Map<MenuTable>(updatemenutableDto);
            menutable.Status = false;   
            menuTableService.TUpdate(menutable);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = menuTableService.TGetByID(id);
            return Ok(value);
        }

    }
}
