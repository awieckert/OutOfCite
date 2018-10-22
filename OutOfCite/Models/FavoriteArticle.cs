using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutOfCite.Models
{
    public class FavoriteArticle
    {
        [Key]
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public string ApplicationUserId { get; set; }

        public Article Article { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
