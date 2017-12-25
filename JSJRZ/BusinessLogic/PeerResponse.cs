using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.Entity;

namespace MXKJ.BusinessLogic
{
    public class PeerResponse: BusinessLogicBase
    {
        public Edu_PeerResponseViewEF[] GetAllScoreByStudent(int StudentID)
        {
            Edu_PeerResponseViewEF vSelectEF = new Edu_PeerResponseViewEF();
            vSelectEF.StudentID = StudentID;
            vSelectEF.Year = DateTime.Now.Year;
            vSelectEF.Range = DateTime.Now.Month <= 9 ? 1 : 0;
            return m_BasicDBClass.SelectRecordsEx(vSelectEF);
        }

        public bool EvaluateStudent(int StudentID, int EvaluateStudentID, int Score)
        {
            bool vResult = false;
            Edu_PeerResponseEF vSelectEF = new Edu_PeerResponseEF();
            vSelectEF.StudentID = StudentID;
            vSelectEF.EvaluateStudentID = EvaluateStudentID;
            Edu_PeerResponseEF[] vSelectResult = m_BasicDBClass.SelectRecordsEx(vSelectEF);

            vSelectEF.Socre = Score;
            if (vSelectResult.Length>0)
            {
                vResult =  m_BasicDBClass.UpdateRecord(vSelectEF, vSelectResult[0].ID);
            }
            else
            {
                vSelectEF.Year = DateTime.Now.Year;
                vSelectEF.Range = DateTime.Now.Month <= 9 ? 1 : 0;
                vResult = m_BasicDBClass.InsertRecord(vSelectEF) > 0 ? true : false;
            }
            return vResult;
        }

        public bool DeleteEvaluateByStudent(int StudentID )
        {
            string vSql = string.Format("StudentID={0}",StudentID);
            return m_BasicDBClass.DeleteRecordCustom< Edu_PeerResponseEF>(vSql);
        }

        public Edu_PeerResponseViewEF[] GetAllScoreByOrg(int OrgID )
        {
            Edu_PeerResponseViewEF vSelectEF = new Edu_PeerResponseViewEF();
            vSelectEF.OrgID = OrgID;
            return m_BasicDBClass.SelectRecordsEx(vSelectEF);
        }

        int[] getClassTeacherInfo(int TeacherID)
        {
            int[] vResult = null;
            Edu_TeacherEF vSelectEF = new Edu_TeacherEF();
            vSelectEF.teacher_type = true;
            vSelectEF.course_id = 0;
            vSelectEF.school_year = string.Format("{0}-{1}",DateTime.Now.Year,DateTime.Now.Year+1);
            Edu_TeacherEF[] vSelectResult = m_BasicDBClass.SelectRecordsEx(vSelectEF);
            if (vSelectResult!=null && vSelectResult.Length>0)
            {
                vResult = new int[vSelectResult.Length];
                for(int i=0;i< vSelectResult.Length;i++)
                {
                    vResult[i] = vSelectResult[i].class_id.Value;
                }
            }
            return vResult;
        }


        public Edu_OrgEF[] GetClassInfoByTeacher( int TeacherID )
        {
            Edu_OrgEF[] vResult = null;
            int[] vClassArray = getClassTeacherInfo(TeacherID);
            if (vClassArray != null)
            {
                Edu_OrgEF[] vAllOrgArray = m_BasicDBClass.SelectAllRecordsEx<Edu_OrgEF>();
                vResult = new Edu_OrgEF[vClassArray.Length];
                for(int i= 0;i < vClassArray.Length;i++)
                {
                    //vAllOrgArray.Where(m => m.id == vClassArray[i]).fi
                    Edu_OrgEF vSelectOrg = vAllOrgArray.Where(m => m.id == vClassArray[i]).FirstOrDefault();
                    vResult[i] = vSelectOrg;
                }
            }
            return vResult;
        }

        public Edu_StudentsEF[] GetNotEvaluateStudent(int OrgID)
        {
            string vSql = "Select * From edu_students where id not in ("
                        +string.Format(" Select EvaluateStudentID From edu_peerresponse GROUP BY  EvaluateStudentID having count(*) >= 3 ) and org_id = {0}",OrgID);
            return m_BasicDBClass.SelectCustomEx<Edu_StudentsEF>(vSql);
        }

        public Edu_StudentsEF[] GetAllStudnets(int OrgID )
        {
            Edu_StudentsEF vSelectEF = new Edu_StudentsEF();
            vSelectEF.org_id = OrgID;
            return m_BasicDBClass.SelectRecordsEx(vSelectEF);
        }

    }
}
