using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using Reservation.DbContexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Reservation.Entities
{
    public class Place : BaseEntity
    {

        
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string City { get; set; }
        [Required]
        [MaxLength(150)]
        public string Address { get; set; }
        public DateTime submiteDate { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PlaceType placeType { get; set; }
        
    }
    public enum PlaceType
    {
        Farhangi,
        Tafrihi,
        Mazhabi
    }
}
