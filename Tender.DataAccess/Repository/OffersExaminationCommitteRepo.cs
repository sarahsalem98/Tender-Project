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
    public class OffersExaminationCommitteRepo : Repo<OffersExaminationCommitte>, IOffersExaminationCommitteRepo
    {
        private readonly ApplicationDbContext _db;
        public OffersExaminationCommitteRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(OffersExaminationCommitte offersExaminationCommitte)
        {
            _db.OffersExaminationCommittes.Update(offersExaminationCommitte);
        }
    }
}
