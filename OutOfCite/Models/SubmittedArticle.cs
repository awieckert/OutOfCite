using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutOfCite.Models
{
    public class SubmittedArticle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ApplicationUserId { get; set; }

        [Required]
        public int ArticleId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public Article Article { get; set; }
    }
}
