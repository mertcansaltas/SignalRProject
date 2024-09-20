using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Interfaces;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EfOrderDal(SignalRContext context) : base(context)
		{
		}

		public int ActiveOrderCount()
		{
			var context=new SignalRContext();
			return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
		}

		public decimal LastOrderPrice()
		{
			var context=new SignalRContext();
			return context.Orders.OrderByDescending(x => x.OrderID).FirstOrDefault().TotalPrice;
		}

		public decimal TodayTotalPrice()
		{
			var today = DateTime.Today;
			var context=new SignalRContext();
			return context.Orders.Where(x => x.Date.Date == today && x.Description=="Hesap Kapatıldı").Sum(y => y.TotalPrice);
		}

		public int TotalOrderCount()
		{
			var context=new SignalRContext();
			return context.Orders.Count();
		}
	}
}
