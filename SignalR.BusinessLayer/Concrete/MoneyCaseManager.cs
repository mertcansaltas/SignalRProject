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
	public class MoneyCaseManager : IMoneyCaseService
	{
		private readonly IMoneyCaseDal moneyCaseDal;

		public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
		{
			this.moneyCaseDal = moneyCaseDal;
		}

		public void TAdd(MoneyCase entity)
		{
			throw new NotImplementedException();
		}

		public void TDelete(MoneyCase entity)
		{
			throw new NotImplementedException();
		}

		public List<MoneyCase> TGetAllList()
		{
			throw new NotImplementedException();
		}

		public MoneyCase TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public decimal TTotalMoneyCase()
		{
		  return moneyCaseDal.TotalMoneyCase();	
		}

		public void TUpdate(MoneyCase entity)
		{
			throw new NotImplementedException();
		}
	}
}
