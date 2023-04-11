using TenderProject.Data;
using TenderProject.Repository.IRepository;

namespace TenderProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ISupplierRepo supplier { get; private set; }

        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)

        {
            _db = db;
            supplier = new  SupplierRepo(_db);


        }

        public void save()
        {
            _db.SaveChanges();
        }
    }
}
