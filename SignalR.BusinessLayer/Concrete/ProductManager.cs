using SignalR.BusinessLayer.Interfaces;
using SignalR.DataAccessLayer.EntityFramework;
using SignalR.DataAccessLayer.Interfaces;
using SignalR.DtoLayer.ProductDto;
using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

		public int TProductCount()
		{
           return _productDal.ProductCount();
		}

		public void TAdd(Product entity)
        {
          _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
           _productDal.Delete(entity);
        }

        public List<Product> TGetAllList()
        {
          return  _productDal.GetAllList();
        }

        public Product TGetByID(int id)
        {
         return  _productDal.GetByID(id);
        }

        public List<Product> TGetProductsWithCategories()
        {
          return _productDal.GetProductsWithCategories();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

		public int TProductCountByCategoryNameHamburger()
		{
			return _productDal.ProductCountByCategoryNameHamburger();
		}

		public int TProductCountByCategoryNameDrink()
		{
			return _productDal.ProductCountByCategoryNameDrink();
		}

		public decimal TProductPriceAvg()
		{
			return _productDal.ProductPriceAvg();
		}

		public string TProductNameMaxPrice()
		{
            return _productDal.ProductNameMaxPrice();
		}

		public string TProductNameMinPrice()
		{
			return _productDal.ProductNameMinPrice();
		}

		public decimal TProductPriceAvgByHamburger()
		{
            return _productDal.ProductPriceAvgByHamburger();
		}
	}
}
