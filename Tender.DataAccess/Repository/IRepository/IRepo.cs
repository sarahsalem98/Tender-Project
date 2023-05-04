using System.Linq.Expressions;

namespace TenderProject.Repository.IRepository
{
    public interface IRepo <T> where T : class
    {
        void Add( T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);  

        List<T> GetAll(Expression<Func<T,bool>>?filter=null,string? includeProperties=null);
        T GetFirstOrDefault(Expression<Func<T,bool>>filter, string? includeProperties = null);
    }
}
