using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace Publications
{
    public class Post
    {
        private Blog _blog;
  

        public Post()
        {
        }

        private Post(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader { get; set; }

        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public TimeSpan TimeToWrite { get; private set;}
         public void CalculateTimeToWrite(DateTime start, DateTime end)
        {
            TimeToWrite = end.Subtract(start);
        }

        public int BlogId { get; set; }
        public Blog Blog
        {
            get => LazyLoader?.Load(this, ref _blog);
            set => _blog = value;
        }
    }
}
