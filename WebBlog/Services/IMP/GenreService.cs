using WebBlog.Models;
using WebBlog.Repository.Base;

namespace WebBlog.Services.IMP
{
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> _genreRepository;

        public GenreService(IRepository<Genre> genreRepository)
        {
            this._genreRepository = genreRepository;
        }
        public void Add(Genre item)
        {
            this._genreRepository.Add(item);
        }

        public void Delete(Genre item)
        {
            this._genreRepository.Delete(item);
        }

        public IEnumerable<Genre> GetAll()
        {
            return this._genreRepository.GetAll();
        }

        public void Update(Genre item)
        {
            this._genreRepository.Update(item);
        }
    }
}
