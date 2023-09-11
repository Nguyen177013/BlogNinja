using WebBlog.Models;
using WebBlog.Repository.Base;

namespace WebBlog.Services.IMP
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<Blog> _blogRepository;

        public BlogService(IRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public void Add(Blog item)
        {
            _blogRepository.Add(item);
        }

        public void Delete(Blog item)
        {
            _blogRepository.Delete(item);
        }

        public void Update(Blog item)
        {
            _blogRepository.Update(item);
        }

        public IEnumerable<Blog> GetAll()
        {
            return _blogRepository.GetAll();
        }
    }
}
