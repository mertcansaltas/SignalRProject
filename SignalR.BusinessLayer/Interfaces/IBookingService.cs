using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Interfaces
{
    public interface IBookingService:IGenericService<Booking>
    {
        void TBookingStatusApproved(int id);
        void TBookingStatusCancelled(int id);
    }
}
