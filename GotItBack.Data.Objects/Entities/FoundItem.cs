using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotItBack.Data.Objects.Entities
{
    public class FoundItem
    {
        public long FoundItemId { get; set; }
        [DisplayName("Date Item Was Found")]
        public DateTime DateItemFound { get; set; }
        [DisplayName("Category")]
        public long CategoryId { get; set; }
        [DisplayName("Sub-Category")]
        public long SubCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayName("Color")]
        public string Color { get; set; }
        [DisplayName("Brand/Breed")]
        public string Brand { get; set; }
        [DisplayName("Serial #/ID #/Baggage Claim #")]
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        [DisplayName("Image")]
        public string ItemImage { get; set; }
    }
}
