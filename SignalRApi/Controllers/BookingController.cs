using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Interfaces;
using SignalR.DtoLayer.BookingDto;
using SignalRApi.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;
        private readonly IMapper mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            this.bookingService = bookingService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values= bookingService.TGetAllList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking=mapper.Map<Booking>(createBookingDto);
            bookingService.TAdd(booking);
            return Ok("Rezervasyon yapıldı");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = mapper.Map<Booking>(updateBookingDto);
            bookingService.TUpdate(booking);
            return Ok("Rezervasyon güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
           Booking booking=bookingService.TGetByID(id);
           bookingService.TDelete(booking);
            return Ok("Rezervasyon silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = bookingService.TGetByID(id);
            return Ok(value);
        }
        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Onaylandı");
        }
        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            bookingService.TBookingStatusCancelled(id);
            return Ok("Rezervasyon İptal Edildi");
        }
    }
}
