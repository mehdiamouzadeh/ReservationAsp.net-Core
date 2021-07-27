using Reservation.DbContexts;
using Reservation.Entities;
using Reservation.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Repository
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly ReservationContext _context;

        public PlaceRepository(ReservationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<Place> GetPlaces()
        {
            return _context.Place.ToList<Place>();
        }

        public void AddPlace(Place place)
        {
            if (place == null)
            {
                throw new ArgumentNullException(nameof(place));
            }

            // the repository fills the id (instead of using identity columns)
            place.PublicId = Guid.NewGuid();


            _context.Place.Add(place);
        }
        public void UpdatePlace(Place place)
        {
            // no code in this implementation
        }
        public bool PlaceExists(Guid placeId)
        {
            if (placeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(placeId));
            }

            return _context.Place.Any(a => a.PublicId == placeId);
        }
        public void DeletePlace(Place place)
        {
            if (place == null)
            {
                throw new ArgumentNullException(nameof(place));
            }

            _context.Place.Remove(place);
        }
        public IEnumerable<Place> GetPlaces(PlacesResourceParameters placesResourceParameters)
        {
            if (placesResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(placesResourceParameters));
            }



            var collection = _context.Place as IQueryable<Place>;

            if (!string.IsNullOrWhiteSpace(placesResourceParameters.Name))
            {
                var Name = placesResourceParameters.Name.Trim();

                collection = collection.Where(a => a.Name == Name);
            }

            if (!string.IsNullOrWhiteSpace(placesResourceParameters.SearchQuery))
            {

                var searchQuery = placesResourceParameters.SearchQuery.Trim();
                collection = collection.Where(a => a.Name.Contains(searchQuery)
                    || a.City.Contains(searchQuery));

            }

            return collection
                .Skip(placesResourceParameters.PageSize * (placesResourceParameters.PageNumber - 1))
                .Take(placesResourceParameters.PageSize)
                .ToList();
        }
        public Place GetPlace(Guid placeId)
        {
            if (placeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(placeId));
            }

            return _context.Place.FirstOrDefault(a => a.PublicId == placeId);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
