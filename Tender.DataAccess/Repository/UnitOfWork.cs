using Tender.DataAccess.Repository;
using Tender.DataAccess.Repository.IRepository;
using TenderProject.Data;
using TenderProject.Repository.IRepository;

namespace TenderProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ISupplierRepo supplier { get; private set; }
        public ICityRepo city { get; private set; } 
        public IEmployeeRepo employee { get; private set; } 
        public IRoleRepo role { get; private set; } 
        public IPermissionRepo permission { get;private set; }
        public ITenderRepo tender { get; private set; }
        public ITechnicalSideRepo technicalSide{ get; private set; }
        public IOpeningEnvelopsCommiteeRepo openingEnvelopsCommitee { get; private set; }
        public IOffersExaminationCommitteRepo offersExaminationCommitte { get; private set; }
        
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)

        {
            _db = db;
            supplier = new  SupplierRepo(_db);
            city = new CityRepo(_db);  
            employee = new EmployeeRepo(_db);   
            role = new RoleRepo(_db);
            permission = new PermissionRepo(_db);
            tender = new TenderRepo(_db);
            technicalSide = new TechnicalSideRepo(_db);
            openingEnvelopsCommitee = new OpeningEnvelopsCommitteRepo(_db);
            offersExaminationCommitte = new OffersExaminationCommitteRepo(_db);

        }

        public void save()
        {
            _db.SaveChanges();
        }
    }
}
