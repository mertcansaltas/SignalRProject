using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Interfaces;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DtoLayer.ProductDto;
using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context=new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

		public int ProductCount()
		{
			var context= new SignalRContext();  
            var value=context.Products.Count();
            return value;
		}

		public int ProductCountByCategoryNameDrink()
		{
            var context = new SignalRContext();
            return context.Products.Include(x => x.Category).Where(x => x.Category.CategoryName == "İçecek").Count();
		}

		public int ProductCountByCategoryNameHamburger()
		{
            var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z=>z.CategoryID).FirstOrDefault())).Count();
		}

		public string ProductNameMaxPrice()
		{
			using var context = new SignalRContext();
			return context.Products.OrderByDescending(x => x.Price).FirstOrDefault().ProductName;
		}

		public string ProductNameMinPrice()
		{
			using var context = new SignalRContext();
			return context.Products.OrderBy(x => x.Price).Select(x => x.ProductName).FirstOrDefault();
		}

		public decimal ProductPriceAvg()
		{
            var context = new SignalRContext();
           return context.Products.Average(x => x.Price);
		}

		public decimal ProductPriceAvgByHamburger()
		{
			var context=new SignalRContext();
			var value=context.Products.Where(x=>x.CategoryID==(context.Categories.Where(x=>x.CategoryName=="Hamburger").FirstOrDefault().CategoryID)).Average(x=>x.Price);
			return value;
		}
	}
}
