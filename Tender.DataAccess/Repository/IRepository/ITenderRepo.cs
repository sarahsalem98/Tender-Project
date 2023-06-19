using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderProject.Repository.IRepository;
using TenderModel = Tender.DataAccess.Models.Tender;

namespace Tender.DataAccess.Repository.IRepository
{
    public interface ITenderRepo:IRepo<TenderModel>
    {
        public void update(TenderModel tender);

    }
}
