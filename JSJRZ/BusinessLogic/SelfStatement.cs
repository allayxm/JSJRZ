using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.Entity;
using MXKJ.DBMiddleWareLib;

namespace MXKJ.BusinessLogic
{
    public class SelfStatement: BusinessLogicBase
    {
        public Edu_SelfStatementEF GetSelfStatementByNow( int StudentID)
        {
            Edu_SelfStatementEF vResult = new Edu_SelfStatementEF();
            Edu_SelfStatementEF vSelfStatementEF = new Edu_SelfStatementEF();
            vSelfStatementEF.Year = DateTime.Now.Year;
            if (DateTime.Now.Year <= 0)
                vSelfStatementEF.Range = 1; //上学期
            else
                vSelfStatementEF.Range = 0;//下学期
            vSelfStatementEF.StudentID = StudentID;
            Edu_SelfStatementEF[] vSelectResult =  m_BasicDBClass.SelectRecordsEx(vSelfStatementEF);
            if (vSelectResult.Length > 0)
                vResult = vSelectResult[0];
            return vResult;
        }

        public bool SaveSelfStatement(int StudentID,string Memo)
        {
            bool vResult = false;
            Edu_SelfStatementEF vSelfStatementEF = new Edu_SelfStatementEF();
            vSelfStatementEF.Year = DateTime.Now.Year;
            if (DateTime.Now.Year <= 0)
                vSelfStatementEF.Range = 1; //上学期
            else
                vSelfStatementEF.Range = 0;//下学期
            vSelfStatementEF.StudentID = StudentID;
            Edu_SelfStatementEF[] vSelectResult = m_BasicDBClass.SelectRecordsEx(vSelfStatementEF);
            vSelfStatementEF.Memo = Memo;
            if (vSelectResult.Length>0)
            {
                vResult =  m_BasicDBClass.UpdateRecord(vSelfStatementEF, vSelectResult[0].ID);
            }
            else
            {
                vResult = m_BasicDBClass.InsertRecord(vSelfStatementEF)>0?true:false;
            }
            return vResult;
        }

        public Edu_SelfStatementEF[] GetAllSelfStatement(int StudentID)
        {
            Edu_SelfStatementEF vSelfStatementEF = new Edu_SelfStatementEF();
            vSelfStatementEF.StudentID = StudentID;
            Edu_SelfStatementEF[] vSelectResult = m_BasicDBClass.SelectRecordsEx(vSelfStatementEF);
            return vSelectResult.OrderBy(m => m.Year).ThenBy(m=>m.Range).ToArray();
        }

    }
}
