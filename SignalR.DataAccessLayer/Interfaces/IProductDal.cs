using SignalR.DtoLayer.ProductDto;
using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Interfaces
{
    public interface IProductDal:IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        int ProductCount();
		int ProductCountByCategoryNameHamburger();
		int ProductCountByCategoryNameDrink();
        decimal ProductPriceAvg();

        string ProductNameMaxPrice();
        string ProductNameMinPrice();

        decimal ProductPriceAvgByHamburger();
	}
}
