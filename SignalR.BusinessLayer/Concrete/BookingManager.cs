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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TAdd(Booking entity)
        {
           _bookingDal.Add(entity);
        }

        public void TBookingStatusApproved(int id)
        {
            _bookingDal.BookingStatusApproved(id);
        }

        public void TBookingStatusCancelled(int id)
        {
            _bookingDal.BookingStatusCancelled(id);
        }

        public void TDelete(Booking entity)
        {
           _bookingDal.Delete(entity);
        }

        public List<Booking> TGetAllList()
        {
           return _bookingDal.GetAllList();
        }

        public Booking TGetByID(int id)
        {
           return _bookingDal.GetByID(id);
        }

        public void TUpdate(Booking entity)
        {
           _bookingDal.Update(entity);
        }
    }
}
