using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GotItBack.Data.Objects.Entities
{
    public class Contact : Transport
    {
        [Key]
        public long ContactId { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(10,ErrorMessage = "Maximum of 10 characters")]
        public string Password { get; set; }
        public string Role { get; set; }
        [DisplayName("Display Number")]
        public bool DisplayNumber { get; set; }
    }
}
