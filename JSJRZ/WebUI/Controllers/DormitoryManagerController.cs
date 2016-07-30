using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MXKJ.JSJRZ.Models.DormitoryManager;
using MXKJ.DBMiddleWareLib;
using MXKJ.BusinessLogic;

namespace MXKJ.JSJRZ.WebUI.Controllers
{
    public class DormitoryManagerController : Controller
    {
        // GET: DormitoryManager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DormitoryInfo()
        {
            DormitoryInfoViewModel vModel = new DormitoryInfoViewModel();

            Dormitory vDormitoryInfo = new Dormitory();
            var vAllDormitoryData = vDormitoryInfo.GetAllDormitory();
            foreach( var vTempData in vAllDormitoryData)
            {
                DormitoryItemsViewModel vNewItem = new DormitoryItemsViewModel()
                {
                    ID = vTempData.ID,
                    Area = vTempData.Area != null ? vTempData.Area.Value:0,
                    BuildName = vTempData.BuildName,
                    Campus = vTempData.Campus,
                    LyaerHouseNumber = vTempData.LyaerHouseNumber,
                    ManagementTel = vTempData.ManagementTel,
                    Position = vTempData.Position,
                    Storey = vTempData.Storey,
                    Unit = vTempData.Unit
                };
                vModel.Items.Add(vNewItem);
            }
            return View(vModel);
        }
    }
}