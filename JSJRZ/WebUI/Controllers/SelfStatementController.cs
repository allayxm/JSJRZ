using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MXKJ.JSJRZ.WebUI.Models.SelfStatement;
using MXKJ.BusinessLogic;
using MXKJ.Entity;

namespace MXKJ.JSJRZ.WebUI.Controllers
{
    public class SelfStatementController : Controller
    {
        // GET: SelfStatement
        public ActionResult Index()
        {
            return View();
        }


        #region 自我陈述输入
        public ActionResult InputStatement(int ID )
        {
            InputStatementViewModel vModel = new InputStatementViewModel();
            SelfStatement vSelfStatement = new SelfStatement();
            Edu_SelfStatementEF vSelfStatementEF =  vSelfStatement.GetSelfStatementByNow(ID);
            vModel.Statement = vSelfStatementEF.Memo;
            return View(vModel);
        }

        [HttpPost]
        public ActionResult InputStatement(InputStatementViewModel ViewModel )
        {
            SelfStatement vSelfStatement = new SelfStatement();
            bool vResult = vSelfStatement.SaveSelfStatement(ViewModel.StudentID, ViewModel.Statement);
            if (!vResult)
                ModelState.AddModelError("","保存失败");
            return View(ViewModel);
        }
        #endregion


        public ActionResult ViewStatement(int ID)
        {
            SelfStatement vSelfStatement = new SelfStatement();
            Edu_SelfStatementEF[] vAllRecords = vSelfStatement.GetAllSelfStatement(ID);
            ViewStatementViewModel vViewModel = new ViewStatementViewModel();
            foreach(Edu_SelfStatementEF vTempItem in vAllRecords)
            {
                vViewModel.ItemList.Add(new ViewStatementItemViewModel()
                {
                    Year = vTempItem.Year ?? 0,
                    Rang = vTempItem.Range == 0 ? "上学期" : "下学期",
                    Memo = vTempItem.Memo
                });
            }
            return View(vViewModel);
        }
    }
}