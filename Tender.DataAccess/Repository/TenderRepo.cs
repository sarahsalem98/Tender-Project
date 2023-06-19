using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tender.DataAccess.Repository.IRepository;
using TenderProject.Data;
using TenderProject.Repository;
using TenderModel = Tender.DataAccess.Models.Tender;
namespace Tender.DataAccess.Repository
{
    public class TenderRepo : Repo<TenderModel>, ITenderRepo
    {
        private readonly ApplicationDbContext _db;
        public TenderRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;   
        }

        public void update(TenderModel tender)
        {
            tender.UpdatedAt= DateTime.Now; 
            _db.Tenders.Update(tender);
        }
    }
}
