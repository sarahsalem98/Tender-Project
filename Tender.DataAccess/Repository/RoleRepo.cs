using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tender.DataAccess.Repository.IRepository;
using TenderProject.Data;
using TenderProject.Models;
using TenderProject.Repository;

namespace Tender.DataAccess.Repository
{
    public class RoleRepo : Repo<Role>, IRoleRepo
    {
        private readonly ApplicationDbContext _db;
        public RoleRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Role role)
        {
            role.UpdatedAt = DateTime.Now;
            _db.Roles.Update(role);
        }
    }
}
