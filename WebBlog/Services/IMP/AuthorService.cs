using WebBlog.Models;
using WebBlog.Repository.Base;

namespace WebBlog.Services.IMP
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorService(IRepository<Author> authorRepository)
        {
            this._authorRepository = authorRepository;
        }
        public void Add(Author item)
        {
            this._authorRepository.Add(item);
        }

        public void Delete(int id)
        {
            this._authorRepository.Delete(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return this._authorRepository.GetAll();
        }

        public void Update(Author item)
        {
            this._authorRepository.Update(item);
        }
    }
}
