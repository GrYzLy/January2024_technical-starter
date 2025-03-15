using System.Linq.Expressions;

namespace January2024_technical.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T? Get(Expression<Func<T, bool>> filter);
        T? GetFirstOrDefault(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
       
    }
}
