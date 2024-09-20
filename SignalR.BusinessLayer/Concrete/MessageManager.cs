using SignalR.BusinessLayer.Interfaces;
using SignalR.DataAccessLayer.Interfaces;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }

        public void TAdd(Message entity)
        {
         messageDal.Add(entity);
        }

        public void TDelete(Message entity)
        {
            messageDal.Delete(entity);  
        }

        public List<Message> TGetAllList()
        {
          return  messageDal.GetAllList();
        }

        public Message TGetByID(int id)
        {
            return (messageDal.GetByID(id));    
        }

        public void TUpdate(Message entity)
        {
            messageDal.Update(entity);  
        }
    }
}
