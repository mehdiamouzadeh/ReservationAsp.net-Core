using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservation.Dto;
using Reservation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Reservation.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/Reserv/{Id}/{placeId}")]
    public class ReservController : ControllerBase
    {
        private readonly IReservationRepository _ReservatinRepository;
        private readonly IPlaceRepository _PlaceRepository;

        private readonly IMapper _mapper;
        public ReservController(IReservationRepository reservationRepository,IPlaceRepository PlaceRepository, IMapper mapper)
        {
            _ReservatinRepository = reservationRepository ??
                throw new ArgumentNullException(nameof(reservationRepository));
            _PlaceRepository = PlaceRepository ??
                throw new ArgumentNullException(nameof(PlaceRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpPost]
        public ActionResult<ReservDto> Reservation(
            string Id,Guid placeId, ReservDto reserve)
        {
            reserve.SubmitDate = DateTime.Now;
            var placesFromRepo = _ReservatinRepository.ReservExist(reserve.ReservationDate, placeId);
            if (placesFromRepo)
            {
                return NoContent();
            }
            if (!_PlaceRepository.PlaceExists(placeId))
            {
                 return NotFound();
            }
            

            var reserveEntity = _mapper.Map<Entities.ReservationPlace>(reserve);
            _ReservatinRepository.Reserve(Id,placeId, reserveEntity);
            _ReservatinRepository.Save();

            var reservToReturn = _mapper.Map<ReservDto>(reserveEntity);
            /*return CreatedAtRoute("GetCourseForAuthor",
                new { authorId = authorId, courseId = courseToReturn.Id },
                courseToReturn);*/
            return Ok(reservToReturn);
        }
    }
}
