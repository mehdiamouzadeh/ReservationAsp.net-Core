using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Reservation.Profiles
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, Dto.UserDto>();
        }
    }
}
