using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Interfaces;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub:Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
		private readonly IBookingService _bookingService;
		private readonly INotificationService _notificationService;
		


        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

		public static int clientCount { get; set; } = 0;


        public async Task SendStatistic()
		{
			var value=_categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", value);

			var value2 = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", value2);

			var value3 = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

			var value4 = _categoryService.TPasiveCategoryCount();
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

			var value5=_productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value5);

			var value6=_productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink",value6);

			var value7= _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ReceiveProductPriceAvg",value7.ToString("0.00")+ " ₺");

			var value8=_productService.TProductNameMaxPrice();
			await Clients.All.SendAsync("ReceiveProductNameMaxPrice", value8);

			var value9= _productService.TProductNameMinPrice();
			await Clients.All.SendAsync("ReceiveProductNameMinPrice",value9);

			var value10 = _productService.TProductPriceAvgByHamburger();
			await Clients.All.SendAsync("ReceiveProductPriceAvgByHamburger", value10.ToString("0.00")+ " ₺");

			var value11=_orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value11);

			var value12=_orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", value12);

			var value13 = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", value13.ToString("0.00")+ " ₺");

			var value14 = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", value13.ToString("0.00") + " ₺");

			var value15 = _moneyCaseService.TTotalMoneyCase();
			await Clients.All.SendAsync("ReceiveTotalMoneyCase", value15.ToString("0.00")+ " ₺");

			var value16=_orderService.TTodayTotalPrice();
			await Clients.All.SendAsync("ReceiveTodayTotalPrice", value16.ToString("0.00") + " ₺");

			var value17 = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value17);
		}

		public async Task SendProgressBar()
		{
			var value=_moneyCaseService.TTotalMoneyCase();
			await Clients.All.SendAsync("ReceiveTotalMoneyCase", value.ToString("0.00")+ " ₺");

			var value2=_orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount",value2);

			var value3=_menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount",value3);
		}
		
		public async Task GetBookingList()
		{
			var values=_bookingService.TGetAllList();
			await Clients.All.SendAsync("ReceiveBookingList", values);
		}

		public async Task SendNotificiaton()
		{
			var values=_notificationService.TNotificationCountByStatusFalse();
			await Clients.All.SendAsync("ReceiveNotificationCountByFalse", values);

			var notificationListByFalse=_notificationService.TGetAllNotificationByFalse();
			await Clients.All.SendAsync("ReceiveNotificationListByFalse", notificationListByFalse);
		}

		public async Task GetMenuTableStatus()
		{
			var values = _menuTableService.TGetAllList();
			await Clients.All.SendAsync("ReceiveMenuTableStatus",values);
		}

		public async Task SendMessage(string user, string message)
		{
			await Clients.All.SendAsync("ReceiveMessage",user,message);
		}

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
