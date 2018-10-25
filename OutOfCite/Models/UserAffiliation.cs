using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutOfCite.Models
{
    public class UserAffiliation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        public int AffiliationId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public Affiliation Affiliation { get; set; }
    }
}
