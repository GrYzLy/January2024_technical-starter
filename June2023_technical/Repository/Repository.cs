using January2024_technical.DataAccess;
using January2024_technical.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace January2024_technical.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly BookContext _bookContext;
        private DbSet<T> _dbSet;


        public Repository(BookContext bookContext)
        {
            _bookContext = bookContext;
            _dbSet = bookContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T? Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }

        public T? GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _dbSet?.Remove(entity);
        }
    }
}
