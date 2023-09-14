using WebBlog.Models;
using WebBlog.Repository.Base;

namespace WebBlog.Services.IMP
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<Blog> _blogRepository;

        public BlogService(IRepository<Blog> blogRepository)
        {
            this._blogRepository = blogRepository;
        }

        public void Add(Blog item)
        {
            this._blogRepository.Add(item);
        }

        public void Delete(int id)
        {
            this._blogRepository.Delete(id);
        }

        public void Update(Blog item)
        {
            this._blogRepository.Update(item);
        }

        public IEnumerable<Blog> GetAll()
        {
            return this._blogRepository.GetAllIncluding(p=>p.Author);
        }

        public Blog GetById(int id)
        {
            return this._blogRepository.GetById(id);
        }
    }
}
