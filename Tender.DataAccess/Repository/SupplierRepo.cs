using TenderProject.Data;
using TenderProject.Models;
using TenderProject.Repository.IRepository;

namespace TenderProject.Repository
{
    public class SupplierRepo : Repo<Supplier>, ISupplierRepo
    {
        private readonly ApplicationDbContext _db;
        public SupplierRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Supplier supplier)
        {
            supplier.UpdatedAt= DateTime.Now;
            _db.Suppliers.Update(supplier);
        }
    }
}
