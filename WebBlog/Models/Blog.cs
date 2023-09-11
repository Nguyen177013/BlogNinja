using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebBlog.Models.Base;

namespace WebBlog.Models
{
    public class Blog : BaseEntity
    {

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
