using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Entities

{

    public class ReservationPlace : BaseEntity
    {
        [Required]
        public  string UserId { get; set; }
        [Required]
        public Guid placeId { get; set; }

        [Required]
        
        public DateTime ReservationDate { get; set; }
        [Required]
        public DateTime SubmitDate { get; set; }

        [Required]
        public int Cost { get; set; }

        [ForeignKey(nameof(UserId))]
        public User Customer { get; set; }
        [ForeignKey(nameof(placeId))]
        public Place Place { get; set; }
    }
}
