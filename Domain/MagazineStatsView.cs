public class MagazineStatsView
{
    public MagazineStatsView(string name, int articleCount, int authorCount)
    {
        Name=name;
        ArticleCount=articleCount;
        AuthorCount=authorCount;
    }
    public string Name { get; private set; }
    public int ArticleCount { get; private set; }
    public int AuthorCount{get; private set;}
}