using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Interfaces
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        public int CategoryCount();
        int ActiveCategoryCount();
        int PasiveCategoryCount();
    
    }
}
