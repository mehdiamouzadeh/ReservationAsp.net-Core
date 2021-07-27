using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Entities
{
    public class User:IdentityUser
    { 
        
        public ICollection<ReservationPlace> Reservations { get; set; }
        public ICollection<Place> Places { get; set; }

    }
}
