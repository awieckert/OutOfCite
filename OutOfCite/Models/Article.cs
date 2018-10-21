using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public float JournalImpact { get; set; }

        [Required]
        public float Citations { get; set; }

        public Author Author { get; set; }

        public Affiliation Affiliation { get; set; }
    }
}
