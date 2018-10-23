using OutOfCite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutOfCite.Models.ViewModels
{
    public class ArticleIndexViewModel
    {
        public List<Article> Articles { get; set; } = new List<Article>();

        public Affiliation Affiliation { get; set; }

        public ArticleIndexViewModel(ApplicationDbContext context, int id)
        {
            List<Article> lowImpactArticles = context.Articles.Where(x => (x.AffiliationId == id) && (x.JournalImpact < 5)).ToList();

            foreach (var item in lowImpactArticles)
            {

            }

            Affiliation = context.Affiliations.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
