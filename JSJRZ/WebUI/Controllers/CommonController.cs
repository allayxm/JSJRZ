using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MXKJ.BusinessLogic;
using MXKJ.JSJRZ.WebUI.Models.Common;

namespace MXKJ.JSJRZ.WebUI.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult StudentSelect()
        {
            StudentSelectViewModel vModel = new StudentSelectViewModel();
            Student vStudent = new Student();
            vModel.GradeList.Add(new SelectListItem { Text = "全部年级", Value = "0" });
            OrgStruct[] vGradeData  = vStudent.GetAllGrade();
            foreach(OrgStruct vTempGrade in vGradeData )
            {
                SelectListItem vNewItem = new SelectListItem()
                {
                    Text = vTempGrade.Name,
                    Value = vTempGrade.ID.ToString()
                };
                vModel.GradeList.Add(vNewItem);
            }
            return View(vModel);
        }

        [HttpPost]
        public ActionResult StudentSelect( StudentSelectViewModel Model )
        {
            return View(Model);
        }

        public JsonResult QueryStudent( int GradeID,int ClassID,string StudentName )
        {
            Student vStudent = new Student();
            StudentStruct[] vStudentData = vStudent.QueryStudent(GradeID, ClassID, HttpUtility.UrlDecode( StudentName));
            return Json(vStudentData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult QueryClassByGrade(int GradeID)
        {
            Student vStudent = new Student();
            OrgStruct[] vData = vStudent.QueryClassByGrade(GradeID);
            return Json(vData, JsonRequestBehavior.AllowGet);
        }
    }
}