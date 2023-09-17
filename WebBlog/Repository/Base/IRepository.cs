using System.Linq.Expressions;

namespace WebBlog.Repository.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        IEnumerable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity Find(params Expression<Func<TEntity, bool>>[] filter);
    }
}
