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
                vResult = m_BasicDBClass.InsertRecord(vSelectEF) > 0 ? true : false;
            }
            return vResult;
        }

        public Edu_PeerResponseViewEF[] GetAllScoreByOrg(int OrgID )
        {
            Edu_PeerResponseViewEF vSelectEF = new Edu_PeerResponseViewEF();
            vSelectEF.OrgID = OrgID;
            return m_BasicDBClass.SelectRecordsEx(vSelectEF);
        }



    }
}
