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
        }

        private static void QueryAuthorArticleCountView()
        {
            var results = _context.AuthorArticleCounts.ToList();
        }
        private static void QueryAuthorWithArticleCountView()
        {
            //both of these fail at runtime via internal code when trying to work out the include
            var results = _context.Authors.Include("AuthorArticleCounts").ToList();
            //var results2=_context.AuthorArticleCounts.Include("Author").ToList();
        }
    }
}
