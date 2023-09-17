using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebBlog.Data;
using WebBlog.Repository.Base;

namespace WebBlog.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDBContext _context;
        private readonly DbSet<TEntity> _entities;

        public Repository(ApplicationDBContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            TEntity entity = GetById(id);
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        /*GPT help
         */
        public IEnumerable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _entities;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }

        public TEntity GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Update(TEntity entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public TEntity Find(params Expression<Func<TEntity, bool>>[] filter)
        {
            IQueryable<TEntity> query = _entities;
            foreach (var filterProperty in filter)
            {
                query = query.Where(filterProperty);
            }
            return query.FirstOrDefault();
        }
    }
}
