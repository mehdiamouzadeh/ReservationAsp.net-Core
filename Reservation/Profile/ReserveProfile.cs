using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Profiles
{
    public class ReserveProfile :Profile
    {
        public ReserveProfile()
        {
            CreateMap<Entities.ReservationPlace, Dto.ReservDto>();
            CreateMap<Dto.ReservDto, Entities.ReservationPlace>();
            CreateMap<Dto.ReservDto, Entities.ReservationPlace>();
            CreateMap<Entities.ReservationPlace, Dto.ReservDto>();
        }
    }
}
