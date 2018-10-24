using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutOfCite.Models.ViewModels
{
    public class FavoriteArticleViewModel
    {
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
