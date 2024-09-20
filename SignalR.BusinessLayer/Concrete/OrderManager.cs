using SignalR.BusinessLayer.Interfaces;
using SignalR.DataAccessLayer.Interfaces;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class OrderManager : IOrderService
	{
		private readonly IOrderDal orderDal;

		public OrderManager(IOrderDal orderDal)
		{
			this.orderDal = orderDal;
		}

		public int TActiveOrderCount()
		{
			return orderDal.ActiveOrderCount();
		}

		public void TAdd(Order entity)
		{
			throw new NotImplementedException();
		}

		public void TDelete(Order entity)
		{
			throw new NotImplementedException();
		}

		public List<Order> TGetAllList()
		{
			throw new NotImplementedException();
		}

		public Order TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public decimal TLastOrderPrice()
		{
		return orderDal.LastOrderPrice();
		}

		public decimal TTodayTotalPrice()
		{
			return orderDal.TodayTotalPrice();
		}

		public int TTotalOrderCount()
		{
			return orderDal.TotalOrderCount();
		}

		public void TUpdate(Order entity)
		{
			throw new NotImplementedException();
		}
	}
}
