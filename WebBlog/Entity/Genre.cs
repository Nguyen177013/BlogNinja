using System.ComponentModel.DataAnnotations;
using WebBlog.Models.Base;

namespace WebBlog.Models
{
    public class Genre : BaseEntity
    {
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
