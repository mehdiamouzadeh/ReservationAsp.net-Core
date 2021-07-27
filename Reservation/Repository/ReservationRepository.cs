using Microsoft.AspNetCore.Mvc;
using Reservation.DbContexts;
using Reservation.Dto;
using Reservation.Entities;
using Reservation.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationContext _context;
        

        public ReservationRepository(ReservationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            
        }
        
        public void Reserve(string Id,Guid placeId, ReservationPlace reserve)
        {
            if (placeId == Guid.Empty || Id == string.Empty)
            {
                throw new ArgumentNullException(nameof(placeId));
            }

            if (reserve == null)
            {
                throw new ArgumentNullException(nameof(reserve));
            }

            // always set the AuthorId to the passed-in authorId
            reserve.PublicId = Guid.NewGuid();
            reserve.UserId = Id;
            reserve.placeId = placeId;
            _context.Reservation.Add(reserve);
        }

       
        public bool ReservExist(DateTime dateTime,Guid placeId)
        {

            return _context.Reservation.Any(a => a.ReservationDate.Date == dateTime.Date&&a.placeId == placeId);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
        
















    }
}
