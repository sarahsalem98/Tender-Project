using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tender.DataAccess.Models;
using Tender.DataAccess.Repository.IRepository;
using TenderProject.Data;
using TenderProject.Repository;
using TenderProject.Repository.IRepository;

namespace Tender.DataAccess.Repository
{
    public class PermissionRepo : Repo<Permission>, IPermissionRepo
    {
        private readonly ApplicationDbContext _db;
        public PermissionRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Permission permission)
        {
            _db.Permissions.Update(permission);
        }
    }
}
