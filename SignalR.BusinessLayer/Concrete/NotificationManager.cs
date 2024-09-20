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
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            this.notificationDal = notificationDal;
        }

        public void TAdd(Notification entity)
        {
            notificationDal.Add(entity);    
        }

        public void TDelete(Notification entity)
        {
            notificationDal.Delete(entity); 
        }

        public List<Notification> TGetAllList()
        {
          return notificationDal.GetAllList();  
        }

        public List<Notification> TGetAllNotificationByFalse()
        {
           return notificationDal.GetAllNotificationByFalse();
        }

        public Notification TGetByID(int id)
        {
           return notificationDal.GetByID(id);    
        }

		public void TNotificationChangeToFalse(int id)
		{
            notificationDal.NotificationChangeToFalse(id);
		}

		public void TNotificationChangeToTrue(int id)
		{
            notificationDal.NotificationChangeToTrue(id);
		}

		public int TNotificationCountByStatusFalse()
        {
            return notificationDal.NotificationCountByStatusFalse();
        }

        public void TUpdate(Notification entity)
        {
           notificationDal.Update(entity);  
        }
    }
}
