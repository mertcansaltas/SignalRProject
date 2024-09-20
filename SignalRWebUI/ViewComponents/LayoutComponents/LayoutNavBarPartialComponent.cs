using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
	public class LayoutNavBarPartialComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
