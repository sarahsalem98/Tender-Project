using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tender.DataAccess.Models;
using TenderProject.Areas.Admin.Models;
using TenderProject.Dtos;
using TenderProject.Repository.IRepository;
using TenderProject.Types;
using TenderModel = Tender.DataAccess.Models.Tender;

namespace TenderProject.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(AuthenticationSchemes = "Admin_Schema")]
    public class TenderController : Controller
    {
        private readonly IUnitOfWork _IUniteOfWork;
        public TenderController(IUnitOfWork unitOfWork)
        {
            _IUniteOfWork=unitOfWork;   

        }

        public ResultVM<List<TenderModel>> allTenders(SearchTender search)
        {
            List<TenderModel> tenders = new List<TenderModel>();
            if (search.TenderFilter == 1 || search.TenderFilter==0)
            {
                tenders = _IUniteOfWork.tender.GetAll();
            }else if (search.TenderFilter == 2)
            {
                tenders = _IUniteOfWork.tender.GetAll(t => t.PublishingDate > DateTime.Now.Date);
            }else if(search.TenderFilter == 3)
            {
                tenders = _IUniteOfWork.tender.GetAll(t => t.State == (int)TenderStatusEnum.Finished);
            }
            if (search.IsSearch)
            {
                if (search.Type != 0)
                {
                    tenders = tenders.FindAll(t => t.Type == search.Type).ToList();
                }
                if (search.Status != 0)
                {
                    tenders=tenders.FindAll(t=>t.State==search.Status).ToList();    
                }
                if (!String.IsNullOrEmpty(search.Name))
                 {
                    tenders = tenders.FindAll(t => t.Name.Contains( search.Name)).ToList();
                }
                if (!String.IsNullOrEmpty(search.CreatedBy))
                    {
                    tenders = tenders.FindAll(t => t.CreatedBY.Contains(search.CreatedBy)).ToList();
                }
                if (!String.IsNullOrEmpty(search.ApprovedBy))
                    {
                    tenders = tenders.FindAll(t => t.ApprovedBy.Contains( search.ApprovedBy)).ToList();
                }
            }

            var result = new ResultVM<List<TenderModel>>
            {
                Data = tenders,
                ServerInfo = new ServerInfo
                {
                    CustomStatusCode = CustomStatusCodes.Success,
                    Message="success"
                },
                Status=Status.Success

            };
            return result;

        }

        // GET: TenderController
        public ActionResult Index()
        {
            List<(int, string)> tenderTypes = Enum.GetValues(typeof(TenderTypeEnum))
                                                    .Cast<TenderTypeEnum>()
                                                    .Select(e => ((int)e, e.ToString()))
                                                    .ToList();
            List<(int, string)> tenderStatuses = Enum.GetValues(typeof(TenderStatusEnum))
                                                      .Cast<TenderStatusEnum>()
                                                      .Select(e => ((int)e, e.ToString()))
                                                      .ToList();
            ViewBag.TenderTypes = tenderTypes;
            ViewBag.TenderStatuses = tenderStatuses;
            return View();
        }

        // GET: TenderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TenderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TenderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TenderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TenderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TenderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TenderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public void GetTenderEnumData()
        //{


        //}
    [NonAction]
    public void setViewBags()
    {
       // ViewBag.TenderTypes=_IUniteOfWork

    }
    }
}
