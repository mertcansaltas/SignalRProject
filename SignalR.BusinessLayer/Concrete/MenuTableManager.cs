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
	public class MenuTableManager : IMenuTableService
	{
		private readonly IMenuTableDal menuTableDal;

		public MenuTableManager(IMenuTableDal menuTableDal)
		{
			this.menuTableDal = menuTableDal;
		}

		public void TAdd(MenuTable entity)
		{
			menuTableDal.Add(entity);	
		}

		public void TDelete(MenuTable entity)
		{
		 menuTableDal.Delete(entity);
		}

		public List<MenuTable> TGetAllList()
		{
		 return menuTableDal.GetAllList();
		}

		public MenuTable TGetByID(int id)
		{
			return menuTableDal.GetByID(id);
		}

		public int TMenuTableCount()
		{
			return menuTableDal.MenuTableCount();	
		}

		public void TUpdate(MenuTable entity)
		{
			menuTableDal.Update(entity);	
		}
	}
}
