using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Interfaces
{
    public interface ICategoryService:IGenericService<Category>
    {
        public int TCategoryCount();
        int TActiveCategoryCount();
        int TPasiveCategoryCount();

	}
}
