﻿using OutOfCite.Data;
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

        public bool CanUserVote { get; set; }

        public ArticleIndexViewModel(ApplicationDbContext context, int id, string currentUserId)
        {
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

            // Grabs all the users affiliations
            List<int> userAffiliations = (from af in context.UserAffiliations
                                                      where af.ApplicationUserId == currentUserId
                                                      select af.AffiliationId).ToList();
            // Determines if the user has an affiliation that is the same as the article id is the
            // id of the articles affiliation
            CanUserVote = userAffiliations.Contains(id);

            if (CanUserVote == true)
            {
                List<UserArticleVote> articleIdsOfUserVotes = (from uv in context.UserArticleVotes
                                                               where uv.ApplicationUserId == currentUserId
                                                               select uv).ToList();

                foreach (var article in Articles)
                {
                    foreach (var vote in articleIdsOfUserVotes)
                    {
                        if (vote.ArticleId == article.Id)
                        {
                            article.UserVote = vote.Vote;
                        }
                    }
                }
            }


            Affiliation = context.Affiliations.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
