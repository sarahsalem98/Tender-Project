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
    public class CityRepo : Repo<City>, ICityRepo
    {
        private readonly ApplicationDbContext _db;
        public CityRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

     

        public void update(City city)
        {
         //   _db.Cities.Update(city);
        }
    }
}
