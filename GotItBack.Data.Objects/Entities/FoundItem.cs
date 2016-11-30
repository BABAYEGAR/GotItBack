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
        [DisplayName("Primary Color")]
        public string Color { get; set; }
    }
}
