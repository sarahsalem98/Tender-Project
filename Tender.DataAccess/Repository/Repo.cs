using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TenderProject.Data;
using TenderProject.Repository.IRepository;

namespace TenderProject.Repository
{
    public class Repo<T> : IRepo<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repo(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet=_db.Set<T>();    
        }
    
        public void Add(T entity)
        {
           dbSet.Add(entity);   
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includePrperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
            query.Where(filter);    
            }
            if (includePrperties != null)
            {
                foreach (var includeProperty in includePrperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries) ){
                    query.Include(includeProperty);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includePrperties = null)
        {
            IQueryable<T> query = dbSet;
         
            if (includePrperties != null)
            {
                foreach (var includeProperty in includePrperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
                    query.Include(includeProperty);
                }
            }
            query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
