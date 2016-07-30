using System.Web.Mvc;
using MXKJ.JSJRZ.WebUI.Models.DormitoryManager;
using MXKJ.BusinessLogic;
using MXKJ.Entity;

namespace MXKJ.JSJRZ.WebUI.Controllers
{
    public class DormitoryManagerController : Controller
    {
        // GET: DormitoryManager
        public ActionResult Index()
        {
            return View();
        }

        #region 显示公寓信息
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
        #endregion

        #region 添加公寓
        public ActionResult AddDormitory()
        {
            return View( new AddDormitoryViewModel());
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
            Dormitory_ItemsEF vDormitoryInfo =  vDormitory.GetDormitoryInfo(ID);
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

        #endregion
    }
}