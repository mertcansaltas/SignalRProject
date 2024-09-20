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
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void TChangeStatusToFalse(int id)
        {
           _discountDal.ChangeStatusToFalse(id);
        }

        public void TChangeStatusToTrue(int id)
        {
            _discountDal.ChangeStatusToTrue(id);
        }

        public void TAdd(Discount entity)
        {
            _discountDal.Add(entity);
        }

        public void TDelete(Discount entity)
        {
            _discountDal.Delete(entity);    
        }

        public List<Discount> TGetAllList()
        {
            return _discountDal.GetAllList();
        }

        public Discount TGetByID(int id)
        {
           return _discountDal.GetByID(id);
        }

        public void TUpdate(Discount entity)
        {
           _discountDal.Update(entity);
        }

        public List<Discount> TGetListByStatusTrue()
        {
           return _discountDal.GetListByStatusTrue();   
        }
    }
}
