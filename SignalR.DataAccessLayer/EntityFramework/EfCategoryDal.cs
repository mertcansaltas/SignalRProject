using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Interfaces;
using SignalR.DataAccessLayer.Repositories;
using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

		public int ActiveCategoryCount()
		{
			var context=new SignalRContext();
			return context.Categories.Where(x=>x.CategoryStatus==true).Count();
		}

		public int CategoryCount()
		{
			using var context = new SignalRContext();
			var value=context.Categories.Count();
			return value;
		}

		public int PasiveCategoryCount()
		{
			using var context=new SignalRContext();	
			return context.Categories.Where(x=>x.CategoryStatus==false).Count();
		}
	}
}
