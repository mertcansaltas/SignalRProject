using SignalR.DtoLayer.ProductDto;
using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Interfaces
{
    public interface IProductService:IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        int TProductCount();
		int TProductCountByCategoryNameHamburger();
		int TProductCountByCategoryNameDrink();
		decimal TProductPriceAvg();
		string TProductNameMaxPrice();
		string TProductNameMinPrice();
		decimal TProductPriceAvgByHamburger();
	}
}
