using WebBlog.Models;
using WebBlog.Services.Base;

namespace WebBlog.Services
{
    public interface IAuthorService : IBaseService<Author>
    {
        public Author FindAuthor(Author author);
    }
}
