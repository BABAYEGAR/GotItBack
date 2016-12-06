using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotItBack.Data.Objects.Entities
{
   public class SubCategory
    {
        [DisplayName("Sub-Category")]
        public long SubCategoryId { get; set; }
        public string Name { get; set; }
        public long CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public IEnumerable<FoundItem> FoundItems { get; set; }

    }
}
