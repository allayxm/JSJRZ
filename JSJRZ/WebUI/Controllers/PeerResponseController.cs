using System.Web.Mvc;
using System.Linq;
using MXKJ.BusinessLogic;
using MXKJ.Entity;
using MXKJ.JSJRZ.WebUI.Models.PeerResponse;

namespace MXKJ.JSJRZ.WebUI.Controllers
{
    public class PeerResponseController : Controller
    {
        // GET: PeerResponse
        public ActionResult StudentScoring(int ID,int OrgID )
        {
            PeerResponse vPeerResponse = new PeerResponse();
            Edu_PeerResponseViewEF[] vAllScore = vPeerResponse.GetAllScoreByStudent(ID);
            StudentScoringViewModel vViewModel = new StudentScoringViewModel();
            vViewModel.StudentID = ID;
            vViewModel.OrgID = OrgID;
            for ( int i=0;i<vAllScore.Length;i++)
            {
                vViewModel.StudentName = vAllScore[i].StudentName;
                if (i <= 2)
                {
                    switch( i)
                    {
                        case 0:
                            vViewModel.EvaluateStudentID1 = vAllScore[i].EvaluateStudentID??0;
                            vViewModel.EvaluateStudentName1 = vAllScore[i].EvaluateStudentName;
                            vViewModel.Score1 = vAllScore[i].Socre;
                            break;
                        case 1:
                            vViewModel.EvaluateStudentID2 = vAllScore[i].EvaluateStudentID ?? 0;
                            vViewModel.EvaluateStudentName2 = vAllScore[i].EvaluateStudentName;
                            vViewModel.Score2 = vAllScore[i].Socre;
                            break;
                        case 2:
                            vViewModel.EvaluateStudentID3 = vAllScore[i].EvaluateStudentID ?? 0;
                            vViewModel.EvaluateStudentName3 = vAllScore[i].EvaluateStudentName;
                            vViewModel.Score3 = vAllScore[i].Socre;
                            break;
                    }
                }
                else
                    break;
            }

            Edu_StudentsEF[] vStudentsArray = vPeerResponse.GetNotEvaluateStudent(OrgID);
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
            vPeerResponse.DeleteEvaluateByStudent(ViewModel.StudentID);
            if (ViewModel.EvaluateStudentID1!=null && ViewModel.Score1!=null)
                vResult =  vPeerResponse.EvaluateStudent(ViewModel.StudentID, ViewModel.EvaluateStudentID1.Value, ViewModel.Score1.Value);
            if (ViewModel.EvaluateStudentID2 != null && ViewModel.Score2 != null)
                vResult =  vPeerResponse.EvaluateStudent(ViewModel.StudentID, ViewModel.EvaluateStudentID2.Value, ViewModel.Score2.Value);
            if (ViewModel.EvaluateStudentID3 != null && ViewModel.Score3 != null)
                vResult =  vPeerResponse.EvaluateStudent(ViewModel.StudentID, ViewModel.EvaluateStudentID3.Value, ViewModel.Score3.Value);
            if (!vResult)
                ModelState.AddModelError("", "学生互评失败");
            Edu_StudentsEF[] vStudentsArray = vPeerResponse.GetNotEvaluateStudent(ViewModel.OrgID);
            foreach (Edu_StudentsEF vTempStudent in vStudentsArray)
            {
                ViewModel.StudentList.Add(new SelectListItem() { Text = vTempStudent.name, Value = vTempStudent.id.ToString() });
            }
            return View(ViewModel);
        }

        public ActionResult StatisticsOrgScore(int ID)
        {
            StatisticsOrgScoreViewModel vVideModel = new StatisticsOrgScoreViewModel();
            PeerResponse vPeerResponse = new PeerResponse();
            Edu_StudentsEF[] vStudnetArray = vPeerResponse.GetAllStudnets(ID);
            Edu_PeerResponseViewEF[] vAllScore = vPeerResponse.GetAllScoreByOrg(ID);
            foreach( Edu_StudentsEF vTempStuent in vStudnetArray)
            {
                StatisticsOrgScoreItemViewModel vNewItem = new StatisticsOrgScoreItemViewModel();
                vNewItem.StudentName = vTempStuent.name;
                Edu_PeerResponseViewEF[] vSelectPeerResponseEF =  vAllScore.Where(m => m.EvaluateStudentID == vTempStuent.id).ToArray();
                for( int i=0;i< vSelectPeerResponseEF.Length;i++)
                {
                    switch( i)
                    {
                        case 0:
                            vNewItem.EvaluateStudentName1 = vSelectPeerResponseEF[i].EvaluateStudentName;
                            vNewItem.EvaluateScore1 = vSelectPeerResponseEF[i].Socre??0;
                            break;
                        case 1:
                            vNewItem.EvaluateStudentName2 = vSelectPeerResponseEF[i].EvaluateStudentName;
                            vNewItem.EvaluateScore2 = vSelectPeerResponseEF[i].Socre ?? 0;
                            break;
                        case 2:
                            vNewItem.EvaluateStudentName3 = vSelectPeerResponseEF[i].EvaluateStudentName;
                            vNewItem.EvaluateScore3 = vSelectPeerResponseEF[i].Socre ?? 0;
                            break;
                    }
                }
                vVideModel.Itmes.Add(vNewItem);
            }
            return View(vVideModel);
        }
    }
}