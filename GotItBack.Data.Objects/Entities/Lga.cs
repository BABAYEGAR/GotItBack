using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotItBack.Data.Objects.Entities
{
    public class Lga
    {
        public int LgaId { get; set; }
        public string Name { get; set; }
        public long StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual State State { get; set; }
    }
}
