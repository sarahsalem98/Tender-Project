using Tender.DataAccess.Models;
using TenderProject.Areas.Admin.Models;
using TenderProject.Models;
using TenderProject.Repository.IRepository;

namespace TenderProject.Areas.Admin.Business
{
    public class AccountBusiness
    {
        private readonly IUnitOfWork _IUnitOfWork;
        public AccountBusiness(IUnitOfWork unitOfWork  )
        {
            _IUnitOfWork=unitOfWork;

        }

        public UserVM SetUserInfInSessionForm(Employee employee)
        {
            List<Permission> permissions = _IUnitOfWork.permission.GetAll(p => p.RoleId == employee.RoleId);
            List<PermitedPageVM> permitedPages = new List<PermitedPageVM>();
            foreach(var permission in permissions) { 
               var permitedPage= new PermitedPageVM();  
                permitedPage.RoleId = permission.RoleId;
                permitedPage.Controller = permission.Controller;
                permitedPage.Action=permission.Action;
                permitedPage.Id = permission.Id;
                permitedPages.Add(permitedPage);

            }
            var user = new UserVM
            {
                Id = employee.Id,
                Email = employee.Email,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                EmailConfirmed = employee.EmailConfirmed,
                RoleId = employee.RoleId,
                PermitedPages=permitedPages

            };

            return user;


        }
    }
}
