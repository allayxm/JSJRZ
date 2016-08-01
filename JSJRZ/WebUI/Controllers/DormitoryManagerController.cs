using System.Web.Mvc;
using MXKJ.JSJRZ.WebUI.Models.DormitoryManager;
using MXKJ.BusinessLogic;
using MXKJ.Entity;
using System.Collections.Generic;

namespace MXKJ.JSJRZ.WebUI.Controllers
{
    public class DormitoryManagerController : Controller
    {
        // GET: DormitoryManager
        public ActionResult Index()
        {
            return View();
        }

        #region 公寓管理
        #region 显示公寓信息
        public ActionResult DormitoryInfo()
        {
            DormitoryInfoViewModel vModel = new DormitoryInfoViewModel();

            Dormitory vDormitoryInfo = new Dormitory();
            var vAllDormitoryData = vDormitoryInfo.GetAllDormitory();
            foreach (var vTempData in vAllDormitoryData)
            {
                DormitoryItemsViewModel vNewItem = new DormitoryItemsViewModel()
                {
                    ID = vTempData.ID,
                    Area = vTempData.Area != null ? vTempData.Area.Value : 0,
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
        #endregion

        #region 添加公寓
        public ActionResult AddDormitory()
        {
            return View(new AddDormitoryViewModel());
        }

        [HttpPost]
        public ActionResult AddDormitory(AddDormitoryViewModel Model)
        {
            Dormitory vDormitory = new Dormitory();
            Dormitory_ItemsEF vNewDormitory = new Dormitory_ItemsEF()
            {
                Area = Model.Area,
                BuildMoney = Model.BuildMoney,
                BuildName = Model.BuildName,
                BuildTime = Model.BuildTime,
                BuildType = Model.BuildType,
                Campus = Model.Campus,
                HouseState = Model.HouseState,
                HouseStructure = Model.HouseStructure,
                ID = Model.ID,
                LyaerHouseNumber = Model.LyaerHouseNumber,
                ManagementTel = Model.ManagementTel,
                Memo = Model.Memo,
                OccupiedArea = Model.OccupiedArea,
                Position = Model.Position,
                Property = Model.Property,
                Purpose = Model.Purpose,
                Storey = Model.Storey,
                Unit = Model.Unit
            };
            bool vResult = vDormitory.AddDormitory(vNewDormitory);
            if (vResult)
                return RedirectToAction("DormitoryInfo", "DormitoryManager");
            else
            {
                ModelState.AddModelError("", "添加公寓信息失败");
                return View(Model);
            }
        }
        #endregion

        #region 编辑公寓
        public ActionResult EditDormitory(int ID)
        {
            Dormitory vDormitory = new Dormitory();
            Dormitory_ItemsEF vDormitoryInfo = vDormitory.GetDormitoryInfo(ID);
            EditDormitoryViewModel vModel = new EditDormitoryViewModel()
            {
                ID = vDormitoryInfo.ID,
                Area = vDormitoryInfo.Area,
                BuildMoney = vDormitoryInfo.BuildMoney,
                BuildName = vDormitoryInfo.BuildName,
                BuildTime = vDormitoryInfo.BuildTime,
                BuildType = vDormitoryInfo.BuildType,
                Campus = vDormitoryInfo.Campus,
                HouseState = vDormitoryInfo.HouseState,
                HouseStructure = vDormitoryInfo.HouseStructure,
                LyaerHouseNumber = vDormitoryInfo.LyaerHouseNumber,
                ManagementTel = vDormitoryInfo.ManagementTel,
                Memo = vDormitoryInfo.Memo,
                OccupiedArea = vDormitoryInfo.OccupiedArea,
                Position = vDormitoryInfo.Position,
                Property = vDormitoryInfo.Property,
                Purpose = vDormitoryInfo.Purpose,
                Storey = vDormitoryInfo.Storey,
                Unit = vDormitoryInfo.Unit
            };
            return View(vModel);
        }

        [HttpPost]
        public ActionResult EditDormitory(EditDormitoryViewModel Model)
        {
            Dormitory vDormitory = new Dormitory();
            Dormitory_ItemsEF vNewDormitory = new Dormitory_ItemsEF()
            {
                Area = Model.Area,
                BuildMoney = Model.BuildMoney,
                BuildName = Model.BuildName,
                BuildTime = Model.BuildTime,
                BuildType = Model.BuildType,
                Campus = Model.Campus,
                HouseState = Model.HouseState,
                HouseStructure = Model.HouseStructure,
                ID = Model.ID,
                LyaerHouseNumber = Model.LyaerHouseNumber,
                ManagementTel = Model.ManagementTel,
                Memo = Model.Memo,
                OccupiedArea = Model.OccupiedArea,
                Position = Model.Position,
                Property = Model.Property,
                Purpose = Model.Purpose,
                Storey = Model.Storey,
                Unit = Model.Unit
            };
            bool vResult = vDormitory.UpdateDormitoryInfo(vNewDormitory);
            if (vResult)
                return RedirectToAction("DormitoryInfo", "DormitoryManager");
            else
            {
                ModelState.AddModelError("", "更新公寓信息失败");
                return View(Model);
            }
        }

        public JsonResult DeleteDormitory(string IDS)
        {
            Dormitory vDormitory = new Dormitory();
            bool vResult = vDormitory.DeleteDormitory(IDS);
            return Json(vResult, JsonRequestBehavior.AllowGet);
        }

        #endregion
        #endregion

        #region 房间管理
        public ActionResult HouseInfo()
        {
            Dormitory vDormitoryInfo = new Dormitory();
            HouseInfoViewModel vModel = new HouseInfoViewModel();
            Dormitory_HouseViewEF[] vHouseInfo = vDormitoryInfo.GetAllHouseInfo();
            foreach (Dormitory_HouseViewEF vTempHouse in vHouseInfo)
            {
                HouseDetailInfoViewModel vNewHouse = new HouseDetailInfoViewModel()
                {
                    ID = vTempHouse.ID,
                    Area = vTempHouse.Area,
                    BedNumber = vTempHouse.BedNumber,
                    DormitoryID = vTempHouse.DormitoryID,
                    DormitoryName = vTempHouse.DormitoryName,
                    Floor = vTempHouse.Floor,
                    IsUse = vTempHouse.IsUse,
                    Number = vTempHouse.Number
                };
                vModel.HouseList.Add(vNewHouse);
            }
            return View(vModel);
        }

        #region 创建宿舍
        public ActionResult CreateHouse()
        {
            CreateHouseViewModel vModel = new CreateHouseViewModel();
            Dormitory vDormitory = new Dormitory();
            Dormitory_ItemsEF[] vDormitoryData = vDormitory.GetAllDormitory();
            vModel.DormitoryList.AddRange(convertToDormitoryListItem(vDormitoryData));
            return View(vModel);
        }

        [HttpPost]
        public ActionResult CreateHouse(CreateHouseViewModel Model)
        {
            Dormitory vDormitory = new Dormitory();
            bool vResult = vDormitory.CreateHouseByDormitory(Model.DormitoryID.Value, Model.Unit,
                Model.Floor.Value, Model.Number.Value, Model.BedNumber.Value, Model.Area);
            if (vResult)
                return RedirectToAction("HouseInfo", "DormitoryManager");
            else
            {
                ModelState.AddModelError("", "创建宿舍失败");
                return View(Model);
            }
        }

        public ActionResult EditHouse(int ID)
        {
            Dormitory vDormitory = new Dormitory();
            Dormitory_HouseViewEF vHouseInfo = vDormitory.GetHouseInfoByID(ID);
            EditHouseViewModel vModel = new EditHouseViewModel()
            {
                ID = vHouseInfo.ID.Value,
                Area = vHouseInfo.Area,
                BedNumber = vHouseInfo.BedNumber,
                DormitoryID = vHouseInfo.DormitoryID,
                DormitoryName = vHouseInfo.DormitoryName,
                Floor = vHouseInfo.Floor,
                HouseNumber = vHouseInfo.Number,
                IsUse = vHouseInfo.IsUse.Value
            };
            vModel.DormitoryList.AddRange(convertToDormitoryListItem(vDormitory.GetAllDormitory()));
            return View(vModel);
        }

        [HttpPost]
        public ActionResult EditHouse(EditHouseViewModel Model)
        {
            Dormitory vDormitory = new Dormitory();
            Dormitory_HouseEF vHouseData = new Dormitory_HouseEF()
            {
                ID = Model.ID,
                Area = Model.Area,
                BedNumber = Model.BedNumber,
                DormitoryID = Model.DormitoryID,
                Floor = Model.Floor,
                IsUse = Model.IsUse,
                Number = Model.HouseNumber
            };
            bool vResult = vDormitory.UpdateHouseInfo(vHouseData);
            if (vResult)
                return RedirectToAction("HouseInfo", "DormitoryManager");
            else
            {
                ModelState.AddModelError("", "宿舍信息编辑失败");
                return View(Model);
            }
        }

        public JsonResult DeleteHouse( string IDS)
        {
            Dormitory vDormitory = new Dormitory();
            bool vResult = vDormitory.DeleteDormitory(IDS);
            return Json(vResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddHouse()
        {
            AddHouseViewModel vModel = new AddHouseViewModel();
            Dormitory vDormitory = new Dormitory();
            vModel.DormitoryList = convertToDormitoryListItem(vDormitory.GetAllDormitory());
            return View(vModel);
        }

        [HttpPost]
        public ActionResult AddHouse(AddHouseViewModel Model)
        {
            Dormitory vDormitory = new Dormitory();
            Dormitory_HouseEF vHouseData = new Dormitory_HouseEF()
            {
                Area = Model.Area,
                BedNumber = Model.BedNumber,
                DormitoryID = Model.DormitoryID,
                Floor = Model.Floor,
                IsUse = Model.IsUse,
                Number = Model.HouseNumber
            };
            bool vResult = vDormitory.AddHouse(vHouseData);
            if (vResult)
                return RedirectToAction("HouseInfo", "DormitoryManager");
            else
            {
                ModelState.AddModelError("", "宿舍信息增加失败");
                return View(Model);
            }
        }

        #endregion

        #region 公用
        List<SelectListItem> convertToDormitoryListItem(Dormitory_ItemsEF[] DormitoryItmes)
        {
            List<SelectListItem> vList = new List<SelectListItem>();
            foreach (Dormitory_ItemsEF vTempvDormitory in DormitoryItmes)
            {
                SelectListItem vNewItem = new SelectListItem()
                {
                    Text = vTempvDormitory.BuildName,
                    Value = vTempvDormitory.ID.ToString()
                };
                vList.Add(vNewItem);
            }
            return vList;
        }
        #endregion

        #endregion

        #region 房间分配
        public ActionResult HouseAllot()
        {
            HouseAllotViewModel vModel = new HouseAllotViewModel();
            Dormitory vDormitory = new Dormitory();
            vModel.DormitoryList = convertToDormitoryListItem(vDormitory.GetAllDormitory());
            return View(vModel);
        }

        #endregion
    }
}