using System.Web.Mvc;
using MXKJ.JSJRZ.WebUI.Models.DormitoryManager;
using MXKJ.BusinessLogic;
using MXKJ.Entity;
using MXKJ.Common;
using System.Collections.Generic;
using System.Web.ModelBinding;


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
        List<SelectListItem> convertToDictListItem(Sys_CodeEF[] SysCodes)
        {
            List<SelectListItem> vList = new List<SelectListItem>();
            foreach (Sys_CodeEF vTempvCode in SysCodes)
            {
                SelectListItem vNewItem = new SelectListItem()
                {
                    Text = vTempvCode.code_name,
                    Value = vTempvCode.code_name
                };
                vList.Add(vNewItem);
            }
            return vList;
        }

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
        public ActionResult HouseAllotInfo()
        {
            HouseAllotInfoViewModel vModel = new HouseAllotInfoViewModel();
            Dormitory vDormitory = new Dormitory();
            vModel.DormitoryList = convertToDormitoryListItem(vDormitory.GetAllDormitory());
            vModel.HouseList = new List<HouseAllotItemViewModel>();
            return View(vModel);
        }

        [HttpPost]
        
        public ActionResult HouseAllotInfo(HouseAllotInfoViewModel Model)
        {
            Dormitory_HouseViewEF[] vHouseData = new Dormitory_HouseViewEF[0];
            Dormitory vDormitory = new Dormitory();
            vHouseData = vDormitory.QueryHouseInfoByDormitory( Model.DormitorySelected, Model.FloorSelected);
            Model.DormitoryList = convertToDormitoryListItem(vDormitory.GetAllDormitory());

            Model.FloorList.Clear();
            Dormitory_ItemsEF vDormitoryInfo = vDormitory.GetDormitoryInfo(Model.DormitorySelected);
            int vFloor = vDormitoryInfo.Storey==null?0:vDormitoryInfo.Storey.Value;
            for( int i=1;i<=vFloor;i++)
            {
                SelectListItem vFloorItem = new SelectListItem()
                {
                    Text = i + "楼",
                    Value = i.ToString()
                };
                Model.FloorList.Add(vFloorItem);
            }

            Model.HouseList.Clear();
            foreach ( Dormitory_HouseViewEF vTempHouse in vHouseData )
            {
                HouseAllotItemViewModel vNewItem = new HouseAllotItemViewModel()
                {
                    ID = vTempHouse.ID,
                    Area = vTempHouse.Area,
                    BedNumber = vTempHouse.BedNumber,
                    DormitoryID = vTempHouse.DormitoryID,
                    DormitoryName = vTempHouse.DormitoryName,
                    Floor = vTempHouse.Floor,
                    IsUse = vTempHouse.IsUse,
                    Number = vTempHouse.Number,
                    ResidueBed = vTempHouse.ResidueBed,
                    StudentName = vTempHouse.StudentName
                };
                Model.HouseList.Add(vNewItem);
            }
            return View(Model);
        }

        public JsonResult QueryFloorByDormitory(int DormitoryID)
        {
            Dormitory vDormitory = new Dormitory();
            Dormitory_ItemsEF vDormitoryInfo = vDormitory.GetDormitoryInfo(DormitoryID);
            int vFloor = vDormitoryInfo.Storey.Value;
            return Json(vFloor, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HouseAllot( int ID)
        {
            Dormitory vDormitory = new Dormitory();
            Dormitory_HouseViewEF vHouseInfo = vDormitory.GetHouseInfoByID(ID);
            HouseAllotViewModel vModel = new HouseAllotViewModel()
            {
                Area = vHouseInfo.Area,
                StudentName = vHouseInfo.StudentName,
                StudentID = vHouseInfo.StudentID,
                BedNumber = vHouseInfo.BedNumber.Value,
                DormitoryName = vHouseInfo.DormitoryName,
                FloorName = vHouseInfo.Floor.Value + "楼",
                HouseID = vHouseInfo.ID.Value,
                HouseNumber = vHouseInfo.Number,
                OldStudentID = vHouseInfo.StudentID
            };

            return View(vModel);
        }

        [HttpPost]
        public ActionResult HouseAllot(HouseAllotViewModel Model)
        {
            Dormitory vDormitory = new Dormitory();
            if (Model.StudentID != "")
                Model.StudentID = Model.StudentID.Remove(Model.StudentID.Length - 1);
            if (Model.StudentName != "")
                Model.StudentName = Model.StudentName.Remove(Model.StudentName.Length - 1);
            bool vResult = vDormitory.HouseAllot(Model.HouseID, Model.BedNumber, Model.OldStudentID, Model.StudentID, Model.StudentName);
            if (vResult)
                return RedirectToAction("HouseAllotInfo", "DormitoryManager");
            else
            {
                ModelState.AddModelError("", "房间分配失败");
                return View(Model);
            }
        }
        #endregion

        #region 住宿查询
        public ActionResult AccommodationQuery( )
        {
            AccommodationQueryViewModel vModel = new AccommodationQueryViewModel();
            Dormitory vDormitory = new Dormitory();
            vModel.DormitoryList = convertToDormitoryListItem(vDormitory.GetAllDormitory());
            return View(vModel);
        }

        [HttpPost]
        public ActionResult AccommodationQuery( AccommodationQueryViewModel Model)
        {
            Dormitory_HouseViewEF[] vHouseData = new Dormitory_HouseViewEF[0];
            Dormitory vDormitory = new Dormitory();
            vHouseData = vDormitory.QueryHouseInfoByDormitory(Model.DormitorySelected, Model.FloorSelected);
            Model.DormitoryList = convertToDormitoryListItem(vDormitory.GetAllDormitory());

            Model.FloorList.Clear();
            Dormitory_ItemsEF vDormitoryInfo = vDormitory.GetDormitoryInfo(Model.DormitorySelected);
            int vFloor = vDormitoryInfo.Storey==null?0: vDormitoryInfo.Storey.Value;
            for (int i = 1; i <= vFloor; i++)
            {
                SelectListItem vFloorItem = new SelectListItem()
                {
                    Text = i + "楼",
                    Value = i.ToString()
                };
                Model.FloorList.Add(vFloorItem);
            }

            Model.HouseList.Clear();
            foreach (Dormitory_HouseViewEF vTempHouse in vHouseData)
            {
                AccommodationQueryItemViewModel vNewItem = new AccommodationQueryItemViewModel()
                {
                    ID = vTempHouse.ID,
                    Area = vTempHouse.Area,
                    BedNumber = vTempHouse.BedNumber,
                    DormitoryID = vTempHouse.DormitoryID,
                    DormitoryName = vTempHouse.DormitoryName,
                    Floor = vTempHouse.Floor,
                    IsUse = vTempHouse.IsUse,
                    Number = vTempHouse.Number,
                    ResidueBed = vTempHouse.ResidueBed,
                    StudentID = vTempHouse.StudentID,
                    StudentName = vTempHouse.StudentName
                };
                Model.HouseList.Add(vNewItem);
            }
            return View(Model);
        }


        public ActionResult StudentInfo( int ID )
        {
            Student vStudent = new Student();
            Edu_StudentsEF vStudentInfo = vStudent.QueryStudentByID(ID);
            StudentInfoViewModel vModel = new StudentInfoViewModel()
            {
                Name = vStudentInfo.name,
                Address = vStudentInfo.add_home,
                Birthday = vStudentInfo.birthday == null ? (System.DateTime?)null : TimeStamp.GetTime(vStudentInfo.birthday.Value.ToString()),
                MobileTel = vStudentInfo.mobile_phone,
                QQ = vStudentInfo.qq.ToString(),
                Sex = vStudentInfo.sex == "0" ? "男" : "女",
                StudentID = vStudentInfo.student_id,
                WeiXi = vStudentInfo.weixin
            };
            return View(vModel);
        }
        #endregion

        #region 管理人员
        public JsonResult DeleteAdmin( string IDS )
        {
            Dormitory vDormitory = new Dormitory();
            bool vResult = vDormitory.DeleteAdmin(IDS);
            return Json(vResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AdminInfo()
        {
            AdminInfoViewModel vModel = new AdminInfoViewModel();
            Dormitory vDormitory = new Dormitory();
            vModel.DormitoryList = convertToDormitoryListItem( vDormitory.GetAllDormitory() );
            Dormitory_AdminViewEF[] vAdminData = vDormitory.GetAllAdminInfo();
            foreach (Dormitory_AdminViewEF vTempHouse in vAdminData)
            {

                AdminInfoItemViewModel vNewItem = new AdminInfoItemViewModel()
                {
                    ID = vTempHouse.ID,
                    Dormitory = vTempHouse.DormitoryName,
                    Duty = vTempHouse.Duty,
                    Floor = vTempHouse.Floor == null ? "" : string.Format("{0}楼", vTempHouse.Floor),
                    Memo = vTempHouse.Memo,
                    Name = vTempHouse.Name,
                    Tel = vTempHouse.Tel,
                    WorkTime = vTempHouse.WorkTime,
                    WorkType = vTempHouse.WorkType
                };
                vModel.AdminList.Add(vNewItem);
            }
            return View(vModel);
        }

        [HttpPost]
        public ActionResult AdminInfo(AdminInfoViewModel Model)
        {
            Dormitory_AdminViewEF[] vAdminData = new Dormitory_AdminViewEF[0];
            Dormitory vDormitory = new Dormitory();
            vAdminData = vDormitory.QueryAdminInfoByDormitory(Model.DormitorySelected, Model.FloorSelected);
            Model.DormitoryList = convertToDormitoryListItem(vDormitory.GetAllDormitory());

            Model.FloorList.Clear();
            if (Model.DormitorySelected != 0)
            {
                Dormitory_ItemsEF vDormitoryInfo = vDormitory.GetDormitoryInfo(Model.DormitorySelected);
                int vFloor = vDormitoryInfo.Storey.Value;
                for (int i = 1; i <= vFloor; i++)
                {
                    SelectListItem vFloorItem = new SelectListItem()
                    {
                        Text = i + "楼",
                        Value = i.ToString()
                    };
                    Model.FloorList.Add(vFloorItem);
                }
            }

            Model.AdminList.Clear();
            foreach (Dormitory_AdminViewEF vTempHouse in vAdminData)
            {

                AdminInfoItemViewModel vNewItem = new AdminInfoItemViewModel()
                {
                    ID = vTempHouse.ID,
                    Dormitory = vTempHouse.DormitoryName,
                    Duty = vTempHouse.Duty,
                    Floor = vTempHouse.Floor==null?"":string.Format("{0}楼", vTempHouse.Floor),
                    Memo = vTempHouse.Memo,
                    Name = vTempHouse.Name,
                    Tel = vTempHouse.Tel,
                    WorkTime = vTempHouse.WorkTime,
                    WorkType = vTempHouse.WorkType
                };
                Model.AdminList.Add(vNewItem);
            }
            return View(Model);
        }


        public ActionResult AddAdmin()
        {
            
            AddAdminViewModel vModel = new AddAdminViewModel(); ;
            Dormitory vDormitory = new Dormitory();
            vModel.DormitoryList = convertToDormitoryListItem(vDormitory.GetAllDormitory());
            Dict vDict = new Dict();
            vModel.DutyList = convertToDictListItem(vDict.DormitoryManagerDuty());
            return View(vModel);
        }

        [HttpPost]
        public ActionResult AddAdmin(AddAdminViewModel Model)
        {
            Dormitory vDormitory = new Dormitory();
            
            bool vResult = vDormitory.AddAdmin( Model.Name, Model.WorkType,
                Model.WorkTime, Model.Dormitory, Model.Floor, Model.Duty, Model.Tel, Model.Memo);
            if (vResult)
                return RedirectToAction("AdminInfo", "DormitoryManager");
            else
            {
               
                Model.DormitoryList = convertToDormitoryListItem(vDormitory.GetAllDormitory());
                Dict vDict = new Dict();
                Model.DutyList = convertToDictListItem(vDict.DormitoryManagerDuty());
                ModelState.AddModelError("", "增加管理人失败");
                return View(Model);
            }
        }

        public ActionResult EditAdmin(int ID)
        {
            Dormitory vDormitory = new Dormitory();
            Dormitory_AdminViewEF vAdminData = vDormitory.GetAdminInfoByID(ID);
            EditAdminViewModel vModel = new EditAdminViewModel()
            {
                ID = ID,
                Dormitory = vAdminData.Dormitory==null?0:vAdminData.Dormitory.Value,
                Duty = vAdminData.Duty,
                Floor = vAdminData.Floor,
                Memo = vAdminData.Memo,
                Name = vAdminData.Name,
                Tel = vAdminData.Tel,
                WorkTime = vAdminData.WorkTime,
                WorkType = vAdminData.WorkType
            };
            vModel.DormitoryList = convertToDormitoryListItem(vDormitory.GetAllDormitory());
            Dict vDict = new Dict();
            vModel.DutyList = convertToDictListItem(vDict.DormitoryManagerDuty());
            return View( vModel);
        }

        [HttpPost]
        public ActionResult EditAdmin(EditAdminViewModel Model)
        {
            Dormitory vDormitory = new Dormitory();

            bool vResult = vDormitory.UpdateAdminInfo(Model.ID,Model.Name, Model.WorkType,
                Model.WorkTime, Model.Dormitory, Model.Floor, Model.Duty, Model.Tel, Model.Memo);
            if (vResult)
                return RedirectToAction("AdminInfo", "DormitoryManager");
            else
            {
                Model.DormitoryList = convertToDormitoryListItem(vDormitory.GetAllDormitory());
                Dict vDict = new Dict();
                Model.DutyList = convertToDictListItem(vDict.DormitoryManagerDuty());
                ModelState.AddModelError("", "编辑管理人失败");
                return View(Model);
            }
        }

        #endregion
    }
}