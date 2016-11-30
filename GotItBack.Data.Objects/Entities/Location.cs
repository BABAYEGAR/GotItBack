using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotItBack.Data.Objects.Entities
{
    public class Location
    {
        public long LocationId { get; set; }
        public string Address { get; set; }
        [DisplayName("Specific Location")]
        public string SpecificLocation { get; set; }
        [DisplayName("Location Venue Type")]
        public string LocationVenueType { get; set; }
        public long FoundItemId { get; set; }
        [ForeignKey("FoundItemId")]
        public virtual FoundItem FoundItem { get; set; }
    }
}
