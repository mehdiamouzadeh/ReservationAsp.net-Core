using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using AutoMapper;
//using CourseLibrary.API.Helpers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace Reservation.Profiles
{
    public class PlaceProfile :  Profile
    {

        public PlaceProfile()
        {
            CreateMap<Entities.Place, Dto.PlaceDto>();
            CreateMap<Dto.PlaceDto, Entities.Place>();
        }
    }
}
