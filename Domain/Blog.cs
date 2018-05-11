using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Publications
{
    public class Blog
    {
        private ICollection<Post> _posts;

        public Blog()
        {
        }

        // private Blog(ILazyLoader lazyLoader)
        private Blog(Action<object, string> lazyLoader)

        {
            LazyLoader = lazyLoader;
        }
        private Action<object, string> LazyLoader { get; set; }
        // private ILazyLoader LazyLoader { get; set; }

        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public ICollection<Post> Posts
        {
            get => LazyLoader?.Load(this, ref _posts);
            set => _posts = value;
        }
    }
    public static class PocoLoadingExtensions
    {
        public static TRelated Load<TRelated>(
            this Action<object, string> loader,
            object entity,
            ref TRelated navigationField,
            [CallerMemberName] string navigationName = null)
            where TRelated : class
        {
            loader?.Invoke(entity, navigationName);

            return navigationField;
        }
    }
}
