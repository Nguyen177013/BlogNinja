using System.ComponentModel.DataAnnotations;
using WebBlog.Models.Base;

namespace WebBlog.Models
{
    public class Author : BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }

    }
}
