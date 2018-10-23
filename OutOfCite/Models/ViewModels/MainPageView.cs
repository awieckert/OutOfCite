using OutOfCite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutOfCite.Models.ViewModels
{
    public class MainPageView
    {
        public List<Article> TopArticles { get; set; }

        public List<Article> DownArticles { get; set; }

        public MainPageView(ApplicationDbContext context)
        {

            //Select top 3 art.Title
            //From  (
            //      Select u.ArticleId, count(u.vote) as 'Votes'
            //      From UserArticleVotes u
            //      where u.Vote != 0
            //      group by u.ArticleId
            //      ) a join Articles art on a.ArticleId = art.Id
            //      order by a.Votes desc;

            //var queryGroupMax =
            //from student in students
            //group student by student.Year into studentGroup
            //select new
            //{
            //    Level = studentGroup.Key,
            //    HighestScore =
            //    (from student2 in studentGroup
            //     select student2.ExamScores.Average()).Max()
            //};

            var theshizz = from article in context.Articles

            var shitnStuff = from u in context.UserArticleVotes
                             where u.Vote != false
                             group u by u.ArticleId into g
                             select new
                             {
                                 ArticleId = g.Key,
                                 Votes = g.Count(),
                                 ArticleStuff =
                                 (from article in context.Articles
                                  where g.Key == article.Id
                                  select article)
                             };

            var moreShit = from user in context.UserArticleVotes
                           join article in context.Articles on user.ArticleId equals article.Id
                           where user.Vote != false
                           group article by user.ArticleId into g
                           select new
                           {
                               ArticleId = g.Key,
                               Votes = g.Count(),
                               ArticleTitle = g.Where(x => x.Title != "")
                           }

            TopArticles = context.UserArticleVotes
                .Select(x => new { Article = x.ArticleId, Votes = x.Vote })
        }
    }
}
