using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Dto
{
    public class ReservDto
    {
        public Guid PublicId { get; set; }

        
        public DateTime  ReservationDate { get; set; }

        public DateTime SubmitDate { get; set; }
        public int Cost { get; set; }


        public string UserId { get; set; }
        
        public Guid placeId { get; set; }


    }
}
