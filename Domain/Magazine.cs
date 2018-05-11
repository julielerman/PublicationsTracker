using System.Collections.Generic;

namespace Publications
{
    public class Magazine
    {
        public int MagazineId { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public virtual List<Article> Articles { get; set; }
    }
}
