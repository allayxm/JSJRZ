using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MXKJ.JSJRZ.WebUI.Models.Moral;
using MXKJ.BusinessLogic;
using MXKJ.Entity;
using MXKJ.Common.JsonStruct;

namespace MXKJ.JSJRZ.WebUI.Controllers
{
    public class MoralController : Controller
    {
        #region 操行管理
        // GET: Moral
        public ActionResult MoralManage()
        {
            MoralManageViewModel vModel = new MoralManageViewModel();
            Moral vMoral = new Moral();
            Moral_RecordViewEF[] vData = vMoral.GetDataByMonth(DateTime.Today.Year, DateTime.Today.Month);
            foreach(Moral_RecordViewEF vTempData in vData)
            {
                MoralManageItemViewModel vNewItem = new MoralManageItemViewModel()
                {
                    ID = vTempData.ID.Value,
                    ClassName = vTempData.ClassName,
                    Memo = vTempData.Memo,
                    Point = vTempData.Point.Value,
                    TypeName = vTempData.TypeName
                  
            };
                vModel.Items.Add(vNewItem);
            }
            return View(vModel);
        }

        public JsonResult GetMoralData( DateTime start, DateTime end )
        {
            Moral vMoral = new Moral();
            Moral_RecordViewEF[] vData = vMoral.GetDataByRange(start, end);
            List<JsonStruct_FullCalendar> vJsonList = new List<JsonStruct_FullCalendar>();
            foreach(Moral_RecordViewEF vTempData in vData )
            {
                JsonStruct_FullCalendar vJson = new JsonStruct_FullCalendar()
                {
                    id = vTempData.ID.Value,
                    title = string.Format("班级:{0} 分数:{1}", vTempData.ClassName, vTempData.Point),
                    start = vTempData.Date.Value.ToString("yyyy-MM-dd"),
                    allDay = true,
                    borderColor = vTempData.Point >= 0 ? "#00BB00" : "#EA0000",
                    backgroundColor = vTempData.Point >= 0 ? "#00BB00" : "#EA0000",
            };
                vJsonList.Add(vJson);
            };
            return Json(vJsonList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 编辑操行
        
        public ActionResult EditMoral( int ID )
        {
            Student vStudent = new Student();
            Moral vMoral = new Moral();
            Moral_RecordViewEF vMoralData = vMoral.GetDataByID(ID);
            int vGradeID = vStudent.GetGradeIDByClass(vMoralData.ClassID.Value);
            EditMoralViewModel vModel = new EditMoralViewModel()
            {
                ID = ID,
                Memo = vMoralData.Memo,
                Date = vMoralData.Date.Value,
                Point = vMoralData.Point.Value,
                GradeSelected = vGradeID.ToString(),// vMoralData.ClassName.Split('/')[0],
                ClassSelected = vMoralData.ClassID.ToString(),// vMoralData.ClassName.Split('/')[1],
                //StudentName = vMoralData.StudentsName,
                //StudentsID = vMoralData.StudentsID,
                TypeName = vMoralData.TypeName,

            };

           
            OrgStruct[] vGradeData = vStudent.GetAllGrade();
            foreach (OrgStruct vTempGrade in vGradeData)
            {
                SelectListItem vNewItem = new SelectListItem()
                {
                    Text = vTempGrade.Name,
                    Value = vTempGrade.ID.ToString(),
                    Selected = vTempGrade.ID.ToString() == vModel.GradeSelected ? true : false
                };
                vModel.GradeList.Add(vNewItem);
            }

           
            OrgStruct[] vClassData =  vStudent.QueryClassByGrade(vGradeID);
            foreach( OrgStruct vTempClass in vClassData )
            {
                SelectListItem vNewItem = new SelectListItem()
                {
                    Text = vTempClass.Name,
                    Value = vTempClass.ID.ToString(),
                    Selected = vTempClass.ID.ToString() == vModel.ClassSelected ? true : false
                };
                vModel.ClassList.Add(vNewItem);
            }

            string[] vStudentsNameArray = null;
            string[] vStudentsIDArray = null;
            if (vMoralData.StudentsName != "" && vMoralData.StudentsID != "")
            {
                vStudentsNameArray = vMoralData.StudentsName.Split(',');
                vStudentsIDArray = vMoralData.StudentsID.Split(',');
                for (int i = 0; i < vStudentsNameArray.Length; i++)
                {
                    SelectListItem vNewItem = new SelectListItem()
                    {
                        Text = vStudentsNameArray[i],
                        Value = vStudentsIDArray[i]
                    };
                    vModel.StudenSelected_Right_List.Add(vNewItem);
                }
            }

            StudentStruct[] vStudentData = vStudent.QueryStudent(vGradeID, vMoralData.ClassID.Value, "");
            foreach (StudentStruct vTempStudent in vStudentData)
            {
                
                if (vStudentsIDArray != null && vStudentsIDArray.Where(m => m == vTempStudent.ID.ToString()).FirstOrDefault()==null )
                {
                    SelectListItem vNewItem = new SelectListItem()
                    {
                        Text = vTempStudent.Name,
                        Value = vTempStudent.ID.ToString()
                    };
                    vModel.StudenSelected_Left_List.Add(vNewItem);
                }
            }

            Dict vDict = new Dict();
            Sys_CodeEF[] vMoralDict = vDict.MoralCode();
            foreach(Sys_CodeEF vTempMoral in vMoralDict)
            {
                string vText = "";
                string vValue = "";
                if ( vTempMoral.code_name.Split('|').Length>=0 )
                {
                    vText = vTempMoral.code_name.Split('|')[0];
                    vValue = vTempMoral.code_name.Split('|')[1];
                }

                SelectListItem vNewItem = new SelectListItem()
                {
                    Text = vText,
                    Value = vValue
                };
                vModel.TypeList.Add(vNewItem);
            }
         
            return View(vModel);
        }

        [HttpPost]
        public JsonResult EditMoral(int ID, int ClassID,string ClassName ,string Date, string StudentsID, string StudentsName,
          string TypeName, int Point, string Memo)
        {
            StudentsID = StudentsID  ?? StudentsID.Remove(StudentsID.Length-0);
            StudentsName = StudentsName ?? StudentsID.Remove(StudentsID.Length - 0);
            JsonStruct_FullCalendar vJsonData = new JsonStruct_FullCalendar();
            Moral vMoral = new Moral();
            bool vResult = vMoral.Edit(ID, ClassID, DateTime.Parse(Date), StudentsID, StudentsName, TypeName, Point, Memo);
            if (vResult )
            {
                //Moral_RecordViewEF vMoralData = vMoral.GetDataByID(ID);
                vJsonData.id = ID;
                vJsonData.title = string.Format("班级:{0} 分数:{1}", ClassName, Point);
                vJsonData.start = Date;
                vJsonData.allDay = true;
                vJsonData.borderColor = Point >= 0 ? "#00BB00" : "#EA0000";
                vJsonData.backgroundColor = Point >= 0 ? "#00BB00" : "#EA0000";
            }
            return Json(vJsonData, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 增加操行
        public ActionResult AddMoral(string ID)
        {
            Student vStudent = new Student();
            Moral vMoral = new Moral();
            //int vGradeID = vStudent.GetGradeIDByClass(vMoralData.ClassID.Value);
            AddMoralViewModel vModel = new AddMoralViewModel()
            {
                Date = DateTime.Parse(ID),
            };


            OrgStruct[] vGradeData = vStudent.GetAllGrade();
            foreach (OrgStruct vTempGrade in vGradeData)
            {
                SelectListItem vNewItem = new SelectListItem()
                {
                    Text = vTempGrade.Name,
                    Value = vTempGrade.ID.ToString(),
                    Selected = vTempGrade.ID.ToString() == vModel.GradeSelected ? true : false
                };
                vModel.GradeList.Add(vNewItem);
            }


            //OrgStruct[] vClassData = vStudent.QueryClassByGrade(vGradeID);
            //foreach (OrgStruct vTempClass in vClassData)
            //{
            //    SelectListItem vNewItem = new SelectListItem()
            //    {
            //        Text = vTempClass.Name,
            //        Value = vTempClass.ID.ToString(),
            //        Selected = vTempClass.ID.ToString() == vModel.ClassSelected ? true : false
            //    };
            //    vModel.ClassList.Add(vNewItem);
            //}

            //string[] vStudentsNameArray = null;
            //string[] vStudentsIDArray = null;
            //if (vMoralData.StudentsName != "" && vMoralData.StudentsID != "")
            //{
            //    vStudentsNameArray = vMoralData.StudentsName.Split(',');
            //    vStudentsIDArray = vMoralData.StudentsID.Split(',');
            //    for (int i = 0; i < vStudentsNameArray.Length; i++)
            //    {
            //        SelectListItem vNewItem = new SelectListItem()
            //        {
            //            Text = vStudentsNameArray[i],
            //            Value = vStudentsIDArray[i]
            //        };
            //        vModel.StudenSelected_Right_List.Add(vNewItem);
            //    }
            //}

            //StudentStruct[] vStudentData = vStudent.QueryStudent(vGradeID, vMoralData.ClassID.Value, "");
            //foreach (StudentStruct vTempStudent in vStudentData)
            //{

            //    if (vStudentsIDArray != null && vStudentsIDArray.Where(m => m == vTempStudent.ID.ToString()).FirstOrDefault() == null)
            //    {
            //        SelectListItem vNewItem = new SelectListItem()
            //        {
            //            Text = vTempStudent.Name,
            //            Value = vTempStudent.ID.ToString()
            //        };
            //        vModel.StudenSelected_Left_List.Add(vNewItem);
            //    }
            //}

            Dict vDict = new Dict();
            Sys_CodeEF[] vMoralDict = vDict.MoralCode();
            foreach (Sys_CodeEF vTempMoral in vMoralDict)
            {
                string vText = "";
                string vValue = "";
                if (vTempMoral.code_name.Split('|').Length >= 0)
                {
                    vText = vTempMoral.code_name.Split('|')[0];
                    vValue = vTempMoral.code_name.Split('|')[1];
                }

                SelectListItem vNewItem = new SelectListItem()
                {
                    Text = vText,
                    Value = vValue
                };
                vModel.TypeList.Add(vNewItem);
            }

            return View(vModel);
        }

        [HttpPost]
        public JsonResult AddMoral(int ClassID,string ClassName, string Date, string StudentsID, string StudentsName,
            string TypeName, int Point,string Memo )
        {
            Moral vMoral = new Moral();
            JsonStruct_FullCalendar vJsonData = new JsonStruct_FullCalendar();
            int vResult = vMoral.Add(ClassID, DateTime.Parse(Date), StudentsID, StudentsName, TypeName, Point,Memo);
            if (vResult>=0)
            {
                vJsonData.id = vResult;
                vJsonData.title = string.Format("班级:{0} 分数:{1}", ClassName, Point);
                vJsonData.start = Date;
                vJsonData.allDay = true;
                vJsonData.borderColor = Point >= 0 ? "#00BB00" : "#EA0000";
                vJsonData.backgroundColor = Point >= 0 ? "#00BB00" : "#EA0000";
            }
            return Json(vJsonData, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除操行
        public JsonResult DeleteMoral(int ID)
        {
            Moral vMoral = new Moral();
            bool vResult = vMoral.Delete(ID);
            return Json(vResult, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region 操行看板
        public ActionResult ViewMoral()
        {
            return View();
        }

        public ActionResult ViewDetailMoral( int ID )
        {
            Moral vMoral = new Moral();
            Moral_RecordViewEF vMoralData = vMoral.GetDataByID(ID);
            ViewDetailMoralViewModel vModel = new ViewDetailMoralViewModel()
            {
                ID = ID,
                Title = string.Format("班级:{0}<br>日期:{1:yyyy年MM月dd日}", vMoralData.ClassName, vMoralData.Date),
                Moral = vMoralData.TypeName,
                StudentsName = vMoralData.StudentsName,
                Memo = vMoralData.Memo,
                Point = vMoralData.Point.Value
            };

            return View(vModel);
        }
        #endregion

        #region 操行统计
        public ActionResult StatisticsMoral()
        {
            Moral vMoral = new Moral();
            StatisticsMoralViewModel vModel = new StatisticsMoralViewModel();
            Student vStudent = new Student();
            OrgStruct[] vGradeData = vStudent.GetAllGrade();
            foreach (OrgStruct vTempGrade in vGradeData)
            {
                SelectListItem vNewItem = new SelectListItem()
                {
                    Text = vTempGrade.Name,
                    Value = vTempGrade.ID.ToString(),
                };
                vModel.GradeList.Add(vNewItem);
            }

            vModel.StartDate = DateTime.Today.AddDays(-7);
            vModel.EndDate = DateTime.Today;
            vModel.StatisticsTable = vMoral.Statistics(0, 0, vModel.StartDate, vModel.EndDate);
            vModel.StatisticsTable.PrimaryKey = new System.Data.DataColumn[] { };
            vModel.StatisticsTable.Columns.Remove("班级编号");
            vModel.StatisticsTable.AcceptChanges();
            return View(vModel);
        }

        [HttpPost]
        public ActionResult StatisticsMoral(StatisticsMoralViewModel Model)
        {
            Moral vMoral = new Moral();
            Student vStudent = new Student();
            OrgStruct[] vGradeData = vStudent.GetAllGrade();
            foreach (OrgStruct vTempGrade in vGradeData)
            {
                SelectListItem vNewItem = new SelectListItem()
                {
                    Text = vTempGrade.Name,
                    Value = vTempGrade.ID.ToString(),
                };
                Model.GradeList.Add(vNewItem);
            }

            OrgStruct[] vClassData = vStudent.QueryClassByGrade(Model.GradeSelected);
            foreach (OrgStruct vTempClass in vClassData)
            {
                SelectListItem vNewItem = new SelectListItem()
                {
                    Text = vTempClass.Name,
                    Value = vTempClass.ID.ToString(),
                };
                Model.ClassList.Add(vNewItem);
            }

            Model.StatisticsTable = vMoral.Statistics(Model.GradeSelected,Model.ClassSelected, Model.StartDate, Model.EndDate);
            Model.StatisticsTable.PrimaryKey = new System.Data.DataColumn[] { };
            Model.StatisticsTable.Columns.Remove("班级编号");
            Model.StatisticsTable.AcceptChanges();
            return View(Model);
        }
        #endregion



    }
}