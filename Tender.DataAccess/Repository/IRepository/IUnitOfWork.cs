namespace TenderProject.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ISupplierRepo supplier { get; }


        public void save();
    }
}
