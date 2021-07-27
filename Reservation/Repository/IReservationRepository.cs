using Reservation.Entities;
using Reservation.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Repository
{
    public interface IReservationRepository
    {
      
        void Reserve(string Id,Guid placeId, ReservationPlace reserve);
       
        bool ReservExist(DateTime dateTime,Guid placeId);

        bool Save();
    }
}
