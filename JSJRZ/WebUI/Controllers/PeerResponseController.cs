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
            Edu_PeerResponseViewEF[] vAllScore = vPeerResponse.GetAllScoreByStudent(ID);
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

            Edu_StudentsEF[] vStudentsArray = vPeerResponse.GetNotEvaluateStudent(42);
            foreach(Edu_StudentsEF vTempStudent in vStudentsArray)
            {
                vViewModel.StudentList.Add(new SelectListItem() { Text=vTempStudent.name, Value=vTempStudent.id.ToString() });
            }
            return View(vViewModel);
        }

        [HttpPost]
        public ActionResult StudentScoring(StudentScoringViewModel ViewModel)
        {
            bool vResult = false;
            PeerResponse vPeerResponse = new PeerResponse();
            if (ViewModel.EvaluateStudentID1!=null && ViewModel.Score1!=null)
                vResult =  vPeerResponse.EvaluateStudent(ViewModel.StudentID, ViewModel.EvaluateStudentID1.Value, ViewModel.Score1.Value);
            if (ViewModel.EvaluateStudentID2 != null && ViewModel.Score2 != null)
                vResult =  vPeerResponse.EvaluateStudent(ViewModel.StudentID, ViewModel.EvaluateStudentID1.Value, ViewModel.Score2.Value);
            if (ViewModel.EvaluateStudentID3 != null && ViewModel.Score3 != null)
                vResult =  vPeerResponse.EvaluateStudent(ViewModel.StudentID, ViewModel.EvaluateStudentID1.Value, ViewModel.Score3.Value);
            if (!vResult)
                ModelState.AddModelError("", "学生互评失败");
            return View(ViewModel);
        }

        
    }
}