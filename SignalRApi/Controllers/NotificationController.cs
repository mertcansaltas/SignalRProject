using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Interfaces;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService natificationService;
        private readonly IMapper mapper;

        public NotificationController(INotificationService natificationService, IMapper mapper)
        {
            this.natificationService = natificationService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllNotification()
        {
            var values=natificationService.TGetAllList();   
            return Ok(values);
        }
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            var values = natificationService.TNotificationCountByStatusFalse();
            return Ok(values);
        }
        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            var values=natificationService.TGetAllNotificationByFalse();
            return Ok(values);  
        }
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            Notification notification = mapper.Map<Notification>(createNotificationDto);
            notification.Status = false;
            notification.Date= Convert.ToDateTime(DateTime.Now.ToShortDateString());
            natificationService.TAdd(notification);
            return Ok("Ekleme işlemi başarıyla oluşturuldu");   
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value=natificationService.TGetByID(id);
            natificationService.TDelete(value);
            return Ok("Başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = natificationService.TGetByID(id);
            return Ok(value);   
        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            Notification notification=mapper.Map<Notification>(updateNotificationDto);
            natificationService.TUpdate(notification);  
            return Ok("Başarıyla güncellendi");
        }
        [HttpGet("NotificationChangeToTrue/{id}")]
        public IActionResult NotificationChangeToTrue(int id)
        {
            natificationService.TNotificationChangeToTrue(id);
            return Ok("Güncelleme yapıldı");
        }

		[HttpGet("NotificationChangeToFalse/{id}")]
		public IActionResult NotificationChangeToFalse(int id)
		{
			natificationService.TNotificationChangeToFalse(id);
			return Ok("Güncelleme yapıldı");
		}

	}
}
