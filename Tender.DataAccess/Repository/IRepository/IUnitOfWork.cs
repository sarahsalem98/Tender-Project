using Tender.DataAccess.Models;
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
        public ITenderRepo tender { get; }
        public ITechnicalSideRepo technicalSide{ get; }
        public IOpeningEnvelopsCommiteeRepo openingEnvelopsCommitee { get; }
        public IOffersExaminationCommitteRepo offersExaminationCommitte{ get; }
        public void save();
    }
}
