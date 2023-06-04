using Tender.DataAccess.Repository.IRepository;

namespace TenderProject.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ISupplierRepo supplier { get; }
        public ICityRepo city { get; }  
        public IEmployeeRepo employee { get; }
        public IRoleRepo role { get; }

        public IPermissionRepo permission { get; }


        public void save();
    }
}
