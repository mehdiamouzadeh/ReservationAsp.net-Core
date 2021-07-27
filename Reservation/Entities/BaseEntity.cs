using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid PublicId { get; set; }
        public bool IsActive { get; set; }
    }
}
