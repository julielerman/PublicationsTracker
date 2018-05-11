using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.Linq;

namespace Publications
{
    public class PublicationsContext : DbContext
    {
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbQuery<AuthorArticleCount> AuthorArticleCounts { get; set; }
       // public DbQuery<MagazineStatsView> MagazineStats{get;set;}
        public static readonly LoggerFactory MyConsoleLoggerFactory
       = new LoggerFactory(new[] {
              new ConsoleLoggerProvider((category, level)
                => category == DbLoggerCategory.Database.Command.Name
               && level == LogLevel.Information, true) });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                  .UseLoggerFactory(MyConsoleLoggerFactory)
           .UseSqlite(@"Filename=Data/PubsTracker.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().Property(p => p.Name).HasColumnName("AuthorName");
            modelBuilder.Query<AuthorArticleCount>().ToView("View_AuthorArticleCounts");
      modelBuilder.Query<AuthorArticleCount>().HasOne<Author>().WithOne(a=>a.ArticleCount); //.HasForeignKey<AuthorArticleCount>(a => a.AuthorId);
            modelBuilder.Query<MagazineStatsView>().ToQuery(
                () => Magazines.Select(  m => new MagazineStatsView(
                               m.Name,
                               m.Articles.Count,
                               m.Articles.Select(a => a.AuthorId).Distinct().Count()
                              )
                          )
            );

            modelBuilder.Entity<Magazine>().HasData(new Magazine { MagazineId = 1, Name = "MSDN Magazine" });
            modelBuilder.Entity<Article>().HasData(
              new Article { ArticleId = 1, MagazineId = 1, Title = "EF Core 2.1 Query Types", AuthorId = 1 },
              new Article { ArticleId = 2, MagazineId = 1, Title = "Creating Azure Functions That Can Read from Cosmos DB with Almost No Code", AuthorId = 1 }
             );
            modelBuilder.Entity<Magazine>().HasData(new Magazine { MagazineId = 2, Name = "New Yorker" });
            modelBuilder.Entity<Article>().HasData(
              new Article { ArticleId = 3, MagazineId = 2, Title = "Reddit and the Struggle to Detoxify the Internet", AuthorId = 2 },
              new Article { ArticleId = 4, MagazineId = 2, Title = "Digital Vigilantes", AuthorId = 3 }
            );
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, Name = "Julie Lerman" },
                new Author { AuthorId = 2, Name = "Andrew Marantz" },
                new Author { AuthorId = 3, Name = "Nicholas Schmidle" }

            );
            //Testing related to include problem:
            // var keys=modelBuilder.Model.FindEntityType(typeof(AuthorArticleCount)).GetForeignKeys();

        }
    }
}