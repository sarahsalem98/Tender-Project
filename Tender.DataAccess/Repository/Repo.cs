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

        public List<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
           query= query.Where(filter);    
            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries) ){
                  query= query.Include(includeProperty);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
         
             query=query.Where(filter);
          
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
                    query=query.Include(includeProperty);
                }
            }
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
