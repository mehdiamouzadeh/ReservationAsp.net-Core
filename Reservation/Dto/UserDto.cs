using Reservation.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Dto
{
    public class UserDto
    {
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int Phone { get; set; }

        public ICollection<ReservationPlace> Reservations { get; set; }
        public ICollection<Place> Places { get; set; }

    }
}
