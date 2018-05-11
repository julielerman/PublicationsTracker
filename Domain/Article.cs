using System;

namespace Publications
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public int MagazineId { get; set; }
        public DateTime PublishDate { get;  set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }

}
