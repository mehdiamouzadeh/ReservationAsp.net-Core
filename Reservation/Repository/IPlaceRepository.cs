using Reservation.Entities;
using Reservation.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Repository
{
    public interface IPlaceRepository
    {
        IEnumerable<Place> GetPlaces();
        void AddPlace(Place place);
        Place GetPlace(Guid placeId);
        IEnumerable<Place> GetPlaces(PlacesResourceParameters authorsResourceParameters);
        void DeletePlace(Place place);
        void UpdatePlace(Place place);
        bool PlaceExists(Guid placeId);
        bool Save();
    }
}
