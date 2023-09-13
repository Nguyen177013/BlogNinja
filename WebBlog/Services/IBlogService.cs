using WebBlog.Models;
using WebBlog.Repository;
using WebBlog.Services.Base;

namespace WebBlog.Services
{
    public interface IBlogService : IBaseService<Blog>
    {
        Blog GetById(int id);
    }
}
