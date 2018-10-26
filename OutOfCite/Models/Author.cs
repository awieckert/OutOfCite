using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutOfCite.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Author First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Author Last Name")]
        public string LastName { get; set; }

        [Required]
        [Range(25, 300, ErrorMessage = "H-Index must be within 25 - 300") ]
        [Display(Name = "Author H-Index")]
        public int HIndex { get; set; }
    }
}
