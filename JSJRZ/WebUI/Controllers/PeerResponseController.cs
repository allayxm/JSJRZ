using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MXKJ.BusinessLogic;
using MXKJ.Entity;
using MXKJ.JSJRZ.WebUI.Models.PeerResponse;

namespace MXKJ.JSJRZ.WebUI.Controllers
{
    public class PeerResponseController : Controller
    {
        // GET: PeerResponse
        public ActionResult StudentScoring(int ID )
        {
            PeerResponse vPeerResponse = new PeerResponse();
            Edu_PeerResponseViewEF[] vAllScore =  vPeerResponse.GetAllScoreByStudent(ID);
            StudentScoringViewModel vViewModel = new StudentScoringViewModel(); 
            for ( int i=0;i<vAllScore.Length;i++)
            {
                vViewModel.StudentID = vAllScore[i].StudentID ?? 0;
                vViewModel.StudentName = vAllScore[i].StudentName;
                if (i <= 2)
                {
                    switch( i)
                    {
                        case 0:
                            vViewModel.EvaluateStudentID1 = vAllScore[i].EvaluateStudentID??0;
                            vViewModel.EvaluateStudentName1 = vAllScore[i].EvaluateStudentName;
                            break;
                        case 1:
                            vViewModel.EvaluateStudentID2 = vAllScore[i].EvaluateStudentID ?? 0;
                            vViewModel.EvaluateStudentName2 = vAllScore[i].EvaluateStudentName;
                            break;
                        case 2:
                            vViewModel.EvaluateStudentID3 = vAllScore[i].EvaluateStudentID ?? 0;
                            vViewModel.EvaluateStudentName3 = vAllScore[i].EvaluateStudentName;
                            break;
                    }
                }
                else
                    break;
            }
            return View(vViewModel);
        }

        [HttpPost]
        public ActionResult StudentScoring(StudentScoringViewModel ViewModel)
        {
            bool vResult = false;
            PeerResponse vPeerResponse = new PeerResponse();
            vResult =  vPeerResponse.EvaluateStudent(ViewModel.StudentID, ViewModel.EvaluateStudentID1, ViewModel.Score1);
            vResult =  vPeerResponse.EvaluateStudent(ViewModel.StudentID, ViewModel.EvaluateStudentID1, ViewModel.Score2);
            vResult =  vPeerResponse.EvaluateStudent(ViewModel.StudentID, ViewModel.EvaluateStudentID1, ViewModel.Score3);
            if (!vResult)
                ModelState.AddModelError("", "学生互评失败");
            return View(ViewModel);
        }

        
    }
}