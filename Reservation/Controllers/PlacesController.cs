using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservation.Dto;
using Reservation.Entities;
using Reservation.Repository;
using Reservation.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/places")]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceRepository _PlaceRepository;
        private readonly IMapper _mapper;
        public PlacesController(IPlaceRepository PlaceRepository, IMapper mapper)
        {
            _PlaceRepository = PlaceRepository ??
                throw new ArgumentNullException(nameof(PlaceRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet("Getall/")]
        public ActionResult<PlaceDto> GetPlaces()
        {
            var authorsFromRepo = _PlaceRepository.GetPlaces();
            return Ok(_mapper.Map<IEnumerable<PlaceDto>>(authorsFromRepo));
        }
        [HttpPost("addPlace/")]
        public ActionResult<PlaceDto> CreatePlace(PlaceDto place)
        {
            place.submiteDate = DateTime.Now;
            var placeEntity = _mapper.Map<Entities.Place>(place);
            _PlaceRepository.AddPlace(placeEntity);
            _PlaceRepository.Save();

            var placeToReturn = _mapper.Map<PlaceDto>(placeEntity);
            return Ok(placeToReturn);
            
        }
        [HttpPut(("{PublicId}"))]
        public IActionResult UpdatePlace(PlaceDto place)
        {
            if (!_PlaceRepository.PlaceExists(place.PublicId))
            {
                return NotFound();
            }
            var placeFromRepo = _PlaceRepository.GetPlace(place.PublicId);
            _mapper.Map(place, placeFromRepo);

            _PlaceRepository.UpdatePlace(placeFromRepo);

            _PlaceRepository.Save();
            return NoContent();

        }
        [HttpGet("salam/")]
        public ActionResult<string> SayHi()
        {
            return Ok("salam");
        }
        [HttpGet("Search")]
        public ActionResult<IEnumerable<PlaceDto>> GetPlaces(
            [FromQuery] PlacesResourceParameters placesResourceParameters)
        {
            var placesFromRepo = _PlaceRepository.GetPlaces(placesResourceParameters);
            return Ok(_mapper.Map<IEnumerable<PlaceDto>>(placesFromRepo));
        }

        [HttpGet("oneplace/{placeId}", Name = "GetAuthor")]
        public IActionResult GetAuthor(Guid placeId)
        {
            var authorFromRepo = _PlaceRepository.GetPlace(placeId);

            if (authorFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PlaceDto>(authorFromRepo));
        }

        [HttpDelete("{placeId}")]
        public ActionResult DeleteAuthor(Guid placeId)
        {
            var placeFromRepo = _PlaceRepository.GetPlace(placeId);

            if (placeFromRepo == null)
            {
                return NotFound();
            }

            _PlaceRepository.DeletePlace(placeFromRepo);

            _PlaceRepository.Save();

            return NoContent();
        }

    }
}
