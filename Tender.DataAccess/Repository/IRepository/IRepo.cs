using System.Linq.Expressions;

namespace TenderProject.Repository.IRepository
{
    public interface IRepo <T> where T : class
    {
        void Add( T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);  

        IEnumerable<T> GetAll(Expression<Func<T,bool>>?filter=null,string? includePrperties=null);
        T GetFirstOrDefault(Expression<Func<T,bool>>filter, string? includePrperties = null);
    }
}
