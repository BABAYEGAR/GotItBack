using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotItBack.Data.Objects.Entities
{
    public class Category
    {
        [DisplayName("Category")]
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set; }
    }
}
