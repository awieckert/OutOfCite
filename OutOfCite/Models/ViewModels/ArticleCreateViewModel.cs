using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutOfCite.Models.ViewModels
{
    public class ArticleCreateViewModel
    {
        [Required]
        public Article Article { get; set; }

        [Required]
        public Author Author { get; set; }

        [Required]
        public Affiliation Affiliation { get; set; }
    }
}
