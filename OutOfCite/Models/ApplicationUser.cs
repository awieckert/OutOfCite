using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OutOfCite.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        public string LinkedIn { get; set; }

        public virtual ICollection<SubmittedArticle> SubmittedArticles { get; set; }

        public virtual ICollection<FavoriteArticle> FavoriteArticles { get; set; }

        public virtual ICollection<UserAffiliation> UserAffiliations { get; set; }

        public virtual ICollection<UserArticleVote> UserArticleVotes { get; set; }
    }
}
