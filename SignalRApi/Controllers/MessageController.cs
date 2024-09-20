using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.MessageDto;
using SignalR.BusinessLayer.Interfaces;
using SignalRApi.EntityLayer.Entities;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService MessageService;
        private readonly IMapper mapper;

        public MessageController(IMessageService MessageService, IMapper mapper)
        {
            this.MessageService = MessageService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var values = MessageService.TGetAllList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.MessageSendDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            Message message = mapper.Map<Message>(createMessageDto);
            MessageService.TAdd(message);
            return Ok("Mesaj kısmı başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = MessageService.TGetByID(id);
            MessageService.TDelete(value);
            return Ok("Mesaj kısmı silindi");
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message Message = mapper.Map<Message>(updateMessageDto);
            MessageService.TUpdate(Message);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = MessageService.TGetByID(id);
            return Ok(value);
        }
    }
}
