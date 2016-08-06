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
            Safe_HiddenDangerEF[] vData = vSafe.GetAllHiddenDangerData();
            foreach (Safe_HiddenDangerEF vTempData in vData)
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
                vModel.ItemList.Add(vNewItem);
            }
            return View(vModel);
        }

        public ActionResult AddHiddenDanger()
        {
            AddHiddenDangerViewModel vModel = new AddHiddenDangerViewModel();
            vModel.CheckTime = DateTime.Today;
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
                ModelState.AddModelError("", "插入隐患整改记录失败");
                return View(Model);
            }
        }


        public ActionResult EditHiddenDanger(int ID)
        {
            Safe vSafe = new Safe();
            Safe_HiddenDangerEF vData = vSafe.GetHiddenDangerDataByID(ID);
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
                ModelState.AddModelError("", "更新隐患整改记录失败");
                return View(Model);
            }
        }

        public JsonResult DeleteHiddenDanger(string IDS)
        {
            Safe vSafe = new Safe();
            bool vResult = vSafe.DeleteHiddenDanger(IDS);
            return Json(vResult, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 四防安全检查
        public ActionResult SafetyCheckInfo()
        {
            SafetyCheckInfoViewModel vModel = new SafetyCheckInfoViewModel();
            Safe vSafe = new Safe();
            Safe_SafetyCheckEF[] vData = vSafe.GetAllSafetyCheckData();
            foreach (Safe_SafetyCheckEF vTempData in vData)
            {
                SafetyCheckInfoItemViewModel vNewItem = new SafetyCheckInfoItemViewModel()
                {
                    ID = vTempData.ID.Value,
                    Condition = vTempData.CheckCondition,
                    Crew = vTempData.Crew,
                    Memo = vTempData.Memo,
                    Position = vTempData.CheckPosition,
                    Time = vTempData.Time.Value
                };
                vModel.ItemList.Add(vNewItem);
            }
            return View(vModel);
        }

        public ActionResult AddSafetyCheck()
        {
            AddSafetyCheckViewModel vModel = new AddSafetyCheckViewModel();
            vModel.Time = DateTime.Today;
            return View(vModel);
        }

        [HttpPost]
        public ActionResult AddSafetyCheck(AddSafetyCheckViewModel Model)
        {
            Safe vSafe = new Safe();
            bool vResult = vSafe.AddSafetyCheckData(Model.Time.Value, Model.Position, Model.Condition, Model.Crew, Model.Memo);
            if (vResult)
                return RedirectToAction("SafetyCheckInfo", "SafeManager");
            else
            {
                ModelState.AddModelError("", "插入隐患整改记录失败");
                return View(Model);
            }
        }

        public ActionResult EditSafetyCheck(int ID)
        {
            Safe vSafe = new Safe();
            Safe_SafetyCheckEF vData = vSafe.GetSafetyCheckDataByID(ID);
            EditSafetyCheckViewModel vModel = new EditSafetyCheckViewModel()
            {
                ID = vData.ID.Value,
                Condition = vData.CheckCondition,
                Crew = vData.Crew,
                Memo = vData.Memo,
                Position = vData.CheckPosition,
                Time = vData.Time
            };
            return View(vModel);
        }

        [HttpPost]
        public ActionResult EditSafetyCheck(EditSafetyCheckViewModel Model)
        {
            Safe vSafe = new Safe();
            bool vResult = vSafe.UpdateSafetyCheckData(Model.ID, Model.Time.Value, Model.Position, Model.Condition, Model.Crew, Model.Memo);
            if (vResult)
                return RedirectToAction("SafetyCheckInfo", "SafeManager");
            else
            {
                ModelState.AddModelError("", "更新四防安全检查记录失败");
                return View(Model);
            }
        }

        public JsonResult DeleteSafetyCheck(string IDS)
        {
            Safe vSafe = new Safe();
            bool vResult = vSafe.DeleteSafetyCheck(IDS);
            return Json(vResult, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 消防器材登记
        public ActionResult FireFightingInfo()
        {
            FireFightingInfoViewModel vModel = new FireFightingInfoViewModel();
            Safe vSafe = new Safe();
            Safe_FireFightingEF[] vData = vSafe.GetAllFireFightingData();
            foreach (Safe_FireFightingEF vTempData in vData)
            {
                SafeFireFightingInfoItemViewModel vNewItem = new SafeFireFightingInfoItemViewModel()
                {
                    ID = vTempData.ID,
                    BuyTime = vTempData.BuyTime,
                    ExtinguisherNum = vTempData.ExtinguisherNum,
                    FireplugNum = vTempData.FireplugNum,
                    Location = vTempData.Location,
                    MaintainState = vTempData.MaintainState,
                    Manager = vTempData.Manager,
                    Memo = vTempData.Memo
                };
                vModel.ItemList.Add(vNewItem);
            }
            return View(vModel);
        }

        public ActionResult AddFireFighting()
        {
            AddFireFightingViewModel vModel = new AddFireFightingViewModel();
            vModel.BuyTime = DateTime.Today;
            return View(vModel);
        }

        [HttpPost]
        public ActionResult AddFireFighting(AddFireFightingViewModel Model)
        {
            Safe vSafe = new Safe();
            bool vResult = vSafe.AddFireFightingData(Model.Location,Model.InputTime, Model.BuyTime,
                Model.ExtinguisherNum, Model.FireplugNum, Model.Manager, Model.MaintainState, Model.Memo);
            if (vResult)
                return RedirectToAction("FireFightingInfo", "SafeManager");
            else
            {
                ModelState.AddModelError("", "增加消防器材记录失败");
                return View(Model);
            }
        }
        public ActionResult EditFireFighting( int ID)
        {
            Safe vSafe = new Safe();
            Safe_FireFightingEF vData = vSafe.GetFireFightingDataByID(ID);
            EditFireFightingViewModel vModel = new EditFireFightingViewModel()
            {
                ID = vData.ID.Value,
                BuyTime = vData.BuyTime,
                ExtinguisherNum = vData.ExtinguisherNum,
                FireplugNum = vData.FireplugNum,
                Location = vData.Location,
                MaintainState = vData.MaintainState,
                Manager = vData.Manager,
                Memo = vData.Memo
            };
            return View(vModel);
        }

        [HttpPost]
        public ActionResult EditFireFighting(EditFireFightingViewModel Model)
        {
            Safe vSafe = new Safe();
            bool vResult = vSafe.UpdateFireFightingData(Model.ID, Model.Location, Model.InputTime, Model.BuyTime, 
                Model.ExtinguisherNum, Model.FireplugNum,  Model.Manager, Model.MaintainState, Model.Memo);
            if(vResult)
                return RedirectToAction("FireFightingInfo", "SafeManager");
            else
            {
                ModelState.AddModelError("", "编辑消防器材记录失败");
                return View(Model);
            }
        }

        public JsonResult DeleteFireFighting(string IDS)
        {
            Safe vSafe = new Safe();
            bool vResult = vSafe.DeleteFireFighting(IDS);
            return Json(vResult, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 学生安全教育
        public ActionResult EducationInfo()
        {
            EducationInfoViewModel vModel = new EducationInfoViewModel();
            Safe vSafe = new Safe();
            Edu_Safe_Education[] vData = vSafe.GetAllEducationData();
            foreach (Edu_Safe_Education vTempData in vData)
            {
                EducationInfoItemViewModel vNewItem = new EducationInfoItemViewModel()
                {
                    ID = vTempData.ID.Value,
                    Describe = vTempData.Describe,
                    Organizer = vTempData.Organizer,
                    Student = vTempData.Student,
                    Theme = vTempData.Theme,
                    Time = vTempData.Time.Value
                };
                vModel.ItemList.Add(vNewItem);
            }
            return View(vModel);
        }

        public ActionResult AddEducation()
        {
            AddEducationViewModel vModel = new AddEducationViewModel();
            vModel.Time = DateTime.Today;
            return View(vModel);
        }

        [HttpPost]
        public ActionResult AddEducation(AddEducationViewModel Model)
        {
            Safe vSafe = new Safe();
            bool vResult = vSafe.AddEducationData(Model.Theme, Model.Time, Model.Organizer,
                Model.Student, Model.Describe);
            if (vResult)
                return RedirectToAction("EducationInfo", "SafeManager");
            else
            {
                ModelState.AddModelError("", "增加学生安全教育记录失败");
                return View(Model);
            }
        }

        public ActionResult EditEducation(int ID)
        {
            Safe vSafe = new Safe();
            Edu_Safe_Education vData = vSafe.GetEducationDataByID(ID);
            EditEducationViewModel vModel = new EditEducationViewModel()
            {
                ID = vData.ID.Value,
                Describe = vData.Describe,
                Student = vData.Student,
                Organizer = vData.Organizer,
                Time = vData.Time.Value,
                Theme = vData.Theme
            };
            return View(vModel);
        }

        [HttpPost]
        public ActionResult EditEducation(EditEducationViewModel Model)
        {
            Safe vSafe = new Safe();
            bool vResult = vSafe.UpdateEducationData(Model.ID,Model.Theme,Model.Time,Model.Organizer,Model.Student,Model.Describe);
            if (vResult)
                return RedirectToAction("EducationInfo", "SafeManager");
            else
            {
                ModelState.AddModelError("", "编辑安全教育记录失败");
                return View(Model);
            }
        }

        public JsonResult DeleteEducation(string IDS)
        {
            Safe vSafe = new Safe();
            bool vResult = vSafe.DeletEducation(IDS);
            return Json(vResult, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}