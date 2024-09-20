using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Interfaces;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>,IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByTableNumber(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x=>x.Product).Where(x=>x.MenuTableID==id).ToList();
            return values;
        }
    }
}
