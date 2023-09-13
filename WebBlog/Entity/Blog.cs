using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebBlog.Models.Base;

namespace WebBlog.Models
{
    public class Blog : BaseEntity
    {

        [Required]
        public string Snippet { get; set; }

        [Required]
        public string Blog_Body { get; set; }

        [ForeignKey("Author")]
        [Required]
        public int Author_Id { get; set; }
        public virtual Author Author { get; set; }

        [ForeignKey("Genre")]
        [Required]
        public int Genre_Id { get; set; }
        public virtual Genre Genre { get; set; }

    }
}
