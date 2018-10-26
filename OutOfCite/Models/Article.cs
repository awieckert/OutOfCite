using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OutOfCite.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int AffiliationId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Abstract { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public string Journal { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Impact Factor must be less than 5 and not negative")]
        [Display(Name ="Journal Impact Factor")]
        public double JournalImpact { get; set; }

        [Required]
        public double Citations { get; set; }

        [NotMapped]
        public bool? UserVote { get; set; }

        [NotMapped]
        public int UpVotes { get; set; }

        [NotMapped]
        public int DownVotes { get; set; }

        public Author Author { get; set; }

        public Affiliation Affiliation { get; set; }
    }
}
