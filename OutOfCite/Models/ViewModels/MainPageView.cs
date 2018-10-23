using OutOfCite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OutOfCite.Models;

namespace OutOfCite.Models.ViewModels
{
    public class MainPageView
    {
        public List<Article> TopArticles { get; set; } = new List<Article>();

        public List<Article> WorstArticles { get; set; } = new List<Article>();

        public MainPageView(ApplicationDbContext context)
        {

            // Select top 3 art.Title
            // From  (
            //      Select u.ArticleId, count(u.vote) as 'Votes'
            //      From UserArticleVotes u
            //      where u.Vote != 0
            //      group by u.ArticleId
            //      ) a join Articles art on a.ArticleId = art.Id
            //      order by a.Votes desc;

            // var queryGroupMax =
            // from student in students
            // group student by student.Year into studentGroup
            // select new
            // {
            //    Level = studentGroup.Key,
            //    HighestScore =
            //    (from student2 in studentGroup
            //     select student2.ExamScores.Average()).Max()
            // };

            var getTopArticles = (from u in context.UserArticleVotes
                              group u by u.ArticleId into g
                              select new
                              {
                                  ArticleId = g.Key,
                                  UpVotes = g.Where(x => x.Vote == true).Count(),
                                  DownVotes = g.Where(x => x.Vote == false).Count(),
                                  Article =
                                  (from article in context.Articles
                                   where g.Key == article.Id
                                   select article).SingleOrDefault()
                              }).OrderByDescending(x => x.UpVotes).Take(3);

            var getWorstArticles = (from u in context.UserArticleVotes
                                     group u by u.ArticleId into g
                                     select new
                                     {
                                         ArticleId = g.Key,
                                         UpVotes = g.Where(x => x.Vote == true).Count(),
                                         DownVotes = g.Where(x => x.Vote == false).Count(),
                                         Article =
                                         (from article in context.Articles
                                          where g.Key == article.Id
                                          select article).SingleOrDefault()
                                     }).OrderByDescending(x => x.DownVotes).Take(3);

            foreach (var item in getTopArticles)
            {
                item.Article.UpVotes = item.UpVotes;
                item.Article.DownVotes = item.DownVotes;
                TopArticles.Add(item.Article);
            };

            foreach (var item in getWorstArticles)
            {
                item.Article.UpVotes = item.UpVotes;
                item.Article.DownVotes = item.DownVotes;
                WorstArticles.Add(item.Article);
            };

            //var moreShit = from user in context.UserArticleVotes
            //               join article in context.Articles on user.ArticleId equals article.Id
            //               where user.Vote != false
            //               group article by user.ArticleId into g
            //               select new
            //               {
            //                   ArticleId = g.Key,
            //                   Votes = g.Count(),
            //                   ArticleTitle = g.Where(x => x.Title != "")
            //               }

            //TopArticles = context.UserArticleVotes
            //    .Select(x => new { Article = x.ArticleId, Votes = x.Vote })
        }
    }
}
