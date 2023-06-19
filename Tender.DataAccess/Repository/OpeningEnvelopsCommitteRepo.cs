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
    public class OpeningEnvelopsCommitteRepo : Repo<OpeningEnvelopeCommittee>, IOpeningEnvelopsCommiteeRepo
    {
        private readonly ApplicationDbContext _db;
        public OpeningEnvelopsCommitteRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(OpeningEnvelopeCommittee openingEnvelopeCommittee)
        {
            _db.OpeningEnvelopeCommittees.Update(openingEnvelopeCommittee);
        }
    }
}
