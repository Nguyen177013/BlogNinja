namespace WebBlog.Models
{
    public class BlogCreateModel
    {
        public Blog Blog { get; set; }

        public IEnumerable<Genre> Genres { get; set; }  
    }
}
