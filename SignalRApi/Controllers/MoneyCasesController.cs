using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Interfaces;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyCasesController : ControllerBase
	{
		private readonly IMoneyCaseService _moneyCaseService;

		public MoneyCasesController(IMoneyCaseService moneyCaseService)
		{
			_moneyCaseService = moneyCaseService;
		}

		[HttpGet]
		public IActionResult TotalMoneyCase()
		{
			return Ok(_moneyCaseService.TTotalMoneyCase());
		}
	}
}
