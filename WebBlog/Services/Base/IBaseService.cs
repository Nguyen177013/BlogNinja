using WebBlog.Models;

namespace WebBlog.Services.Base
{
    public interface IBaseService<TService>
    {
        IEnumerable<TService> GetAll();
        void Add(TService item);
        void Update(TService item);
        void Delete(int id);
    }
}
