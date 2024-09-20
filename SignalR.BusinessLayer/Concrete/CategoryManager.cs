using SignalR.BusinessLayer.Interfaces;
using SignalR.DataAccessLayer.Interfaces;
using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

		public int TActiveCategoryCount()
		{
			return _categoryDal.ActiveCategoryCount();
		}

		public void TAdd(Category entity)
        {
            _categoryDal.Add(entity);
        }

		public int TCategoryCount()
		{
          return  _categoryDal.CategoryCount();
		}

		public void TDelete(Category entity)
        {
           _categoryDal.Delete(entity);
        }

        public List<Category> TGetAllList()
        {
           return _categoryDal.GetAllList();
        }

        public Category TGetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }

		public int TPasiveCategoryCount()
		{
			return _categoryDal.PasiveCategoryCount(); 
		}

		public void TUpdate(Category entity)
        {
          _categoryDal.Update(entity);
        }
    }
}
