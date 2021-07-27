using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Dto
{
    public class PlaceDto
    {
        public Guid PublicId { get; set; }

        public string Name { get; set; }

        public DateTime submiteDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PlaceType placeType { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
       


    }
    public enum PlaceType
    {
        Farhangi,
        Tafrihi,
        Mazhabi
    }
}
