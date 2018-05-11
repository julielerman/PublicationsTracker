using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Publications
{
    class Program
    {
        static PublicationsContext _context = new PublicationsContext();
        static void Main(string[] args)
        {
            //QueryAuthorArticleCountView();
            QueryAuthorWithArticleCountView();
            //MagazineStats();
            //QueryTypeFromSql();
            //PublisherQuery();
        }

        private static void PublisherQuery()
        {
            var publishers=_context.Query<Publisher>().FromSql("select name, yearincorporated from publishers");

        }

        private static void QueryTypeFromSql()
        {
           
            var anonymous=_context.Authors.FromSql("select authorid,authorname from authors").ToList();
}

        private static void MagazineStats()
        {
            // var results=_context.Magazines
            // .Select(m=>new{m.Name,
            //                TheCount=m.Articles.Count,
            //                uniqueauthors=m.Articles.Select(a=>a.AuthorId).Distinct().Count()
            //                }
            // ).ToList();
            var results=_context.Query<MagazineStatsView>().ToList();
        }

        private static void QueryAuthorArticleCountView()
        {
            //var results = _context.AuthorArticleCounts.ToList();
            var results=_context.Query<AuthorArticleCount>().ToList();
        }
        private static void QueryAuthorWithArticleCountView()
        {
           var results = _context.Authors.Include("ArticleCount").ToList();
        }
    }
}
