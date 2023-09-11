using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebBlog.Models.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "date")]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
