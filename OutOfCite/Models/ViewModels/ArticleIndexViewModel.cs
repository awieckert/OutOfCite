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
            //List<Article> lowImpactArticles = context.Articles.Where(x => (x.AffiliationId == id) && (x.JournalImpact < 5)).ToList();

            var articlesWithAuthors = (from a in context.Articles
                                      where a.AffiliationId == id
                                      select new
                                      {
                                          Article = a,
                                          Author =
                                          (from author in context.Authors
                                           where a.AuthorId == author.Id
                                           select author).SingleOrDefault()
                                      }).ToList();

            foreach (var item in articlesWithAuthors)
            {
                if (item.Article.JournalImpact < 5 && item.Author.HIndex >= 25)
                {
                    item.Article.Author = item.Author;
                    Articles.Add(item.Article);
                }
            }

            Affiliation = context.Affiliations.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
