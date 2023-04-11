using TenderProject.Models;

namespace TenderProject.Repository.IRepository
{
    public interface ISupplierRepo:IRepo<Supplier>
    {
        void update( Supplier supplier);            
    }
    
}
