using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Interfaces;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService orderService;

		public OrdersController(IOrderService orderService)
		{
			this.orderService = orderService;
		}

		[HttpGet("TotalOrderCount")]
		public IActionResult TotalOrderCount()
		{
			return Ok(orderService.TTotalOrderCount());
		}

		[HttpGet("ActiveOrderCount")]
		public IActionResult ActiveOrderCount()
		{
			return Ok(orderService.TActiveOrderCount());
		}

		[HttpGet("LastOrderPrice")]
		public IActionResult LastOrderPrice()
		{
			return Ok(orderService.TLastOrderPrice());
		}

		[HttpGet("TodayTotalPrice")]
		public IActionResult TodayTotalPrice()
		{
			return Ok(orderService.TTodayTotalPrice());
		}
	}
}
