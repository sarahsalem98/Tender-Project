﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tender.DataAccess.Models;
using TenderProject.Repository.IRepository;

namespace Tender.DataAccess.Repository.IRepository
{
    public interface ITechnicalSideRepo:IRepo<TechnicalSide>
    {
        public void update(TechnicalSide technicalSide);
    }
}
