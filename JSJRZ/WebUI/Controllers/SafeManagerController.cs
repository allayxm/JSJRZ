using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MXKJ.BusinessLogic;
using MXKJ.Entity;
using MXKJ.JSJRZ.WebUI.Models.SafeManager;

namespace MXKJ.JSJRZ.WebUI.Controllers
{
    public class SafeManagerController : Controller
    {

        #region 隐患整改
        public ActionResult HiddenDangerInfo()
        {
            HiddenDangerInfoViewModel vModel = new HiddenDangerInfoViewModel();
            Safe vSafe = new Safe();
            HiddenDangerEF[] vData = vSafe.GetAllHiddenDangerData();
            foreach (HiddenDangerEF vTempData in vData)
            {
                HiddenDangerInfoItemViewModel vNewItem = new HiddenDangerInfoItemViewModel()
                {
                    ID = vTempData.ID.Value,
                    Address = vTempData.Address,
                    CheckTime = vTempData.CheckTime.Value,
                    Organizer = vTempData.Organizer,
                    Participant = vTempData.Participant,
                    RectificationMeasures = vTempData.RectificationMeasures
                };
            }
            return View();
        }

        public ActionResult AddHiddenDanger()
        {
            AddHiddenDangerViewModel vModel = new AddHiddenDangerViewModel();
            return View(vModel);
        }

        [HttpPost]
        public ActionResult AddHiddenDanger(AddHiddenDangerViewModel Model)
        {
            Safe vSafe = new Safe();
            bool vResult = vSafe.AddHiddenDangerData(Model.Organizer, Model.CheckTime,
                Model.Participant, Model.RectificationMeasures, Model.Address);
            if (vResult)
                return RedirectToAction("HiddenDangerInfo", "SafeManager");
            else
            {
                ModelState.AddModelError("", "插入记录失败");
                return View(Model);
            }
        }


        public ActionResult EditHiddenDanger(int ID)
        {
            Safe vSafe = new Safe();
            HiddenDangerEF vData = vSafe.GetHiddenDangerDataByID(ID);
            EditHiddenDangerViewModel vModel = new EditHiddenDangerViewModel()
            {
                ID = vData.ID.Value,
                Address = vData.Address,
                CheckTime = vData.CheckTime.Value,
                Organizer = vData.Organizer,
                Participant = vData.Participant,
                RectificationMeasures = vData.RectificationMeasures
            };
            return View(vModel);
        }

        [HttpPost]
        public ActionResult EditHiddenDanger(EditHiddenDangerViewModel Model)
        {
            Safe vSafe = new Safe();
            bool vResult = vSafe.UpdateHiddenDangerData(Model.ID, Model.Organizer, Model.CheckTime,
                Model.Participant, Model.RectificationMeasures, Model.Address);
            if (vResult)
                return RedirectToAction("HiddenDangerInfo", "SafeManager");
            else
            {
                ModelState.AddModelError("", "更新记录失败");
                return View(Model);
            }
        }
        #endregion

    }
}