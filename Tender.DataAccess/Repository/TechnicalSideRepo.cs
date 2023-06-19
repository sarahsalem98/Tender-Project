using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tender.DataAccess.Models;
using Tender.DataAccess.Repository.IRepository;
using TenderProject.Data;
using TenderProject.Repository;

namespace Tender.DataAccess.Repository
{
    public class TechnicalSideRepo : Repo<TechnicalSide>, ITechnicalSideRepo
    {
        private readonly ApplicationDbContext _db;
        public TechnicalSideRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(TechnicalSide technicalSide)
        {
            _db.TechnicalSides.Update(technicalSide);
        }
    }
}
