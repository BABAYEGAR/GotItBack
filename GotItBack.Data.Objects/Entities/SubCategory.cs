using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotItBack.Data.Objects.Entities
{
   public class SubCategory
    {
        public long SubCategoryId { get; set; }
        public string Name { get; set; }
        [ForeignKey("CategoryId")]
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
