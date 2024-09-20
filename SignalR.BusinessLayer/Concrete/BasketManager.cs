using SignalR.BusinessLayer.Interfaces;
using SignalR.DataAccessLayer.Interfaces;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            this.basketDal = basketDal;
        }

        public void TAdd(Basket entity)
        {
            basketDal.Add(entity);  
        }

        public void TDelete(Basket entity)
        {
           basketDal.Delete(entity);
        }

        public List<Basket> TGetAllList()
        {
            throw new NotImplementedException();
        }

        public List<Basket> TGetBasketByTableNumber(int id)
        {
            return basketDal.GetBasketByTableNumber(id);
        }

        public Basket TGetByID(int id)
        {
           return basketDal.GetByID(id);
        }

        public void TUpdate(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}
