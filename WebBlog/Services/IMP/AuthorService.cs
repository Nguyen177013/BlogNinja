using BCrypt.Net;
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
            string hasPassword = BCrypt.Net.BCrypt.HashPassword(item.Password);
            item.Password = hasPassword;
            this._authorRepository.Add(item);
        }

        public Author FindAuthor(Author author)
        {
            Author authorLogin = this._authorRepository.Find(
                filter => filter.UserName == author.UserName
                );
            bool validPassword = BCrypt.Net.BCrypt.Verify(author.Password, authorLogin.Password);
            if(validPassword )
            {
                return authorLogin;
            }
            return null;
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
