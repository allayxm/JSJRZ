using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.Entity;

namespace MXKJ.BusinessLogic
{
    public class Safe : BusinessLogicBase
    {
        #region 安全隐患
        public HiddenDangerEF[] GetAllHiddenDangerData()
        {
            return m_BasicDBClass.SelectAllRecordsEx<HiddenDangerEF>();
        }

        public bool AddHiddenDangerData(string Organizer,DateTime CheckTime,string Participant,
            string RectificationMeasures,string Address)
        {
            HiddenDangerEF vData = new HiddenDangerEF()
            {
                Address = Address,
                CheckTime = CheckTime,
                Organizer = Organizer,
                Participant = Participant,
                RectificationMeasures = RectificationMeasures
            };
            return m_BasicDBClass.InsertRecord(vData)>=0?true:false;
        }

        public HiddenDangerEF GetHiddenDangerDataByID( int ID)
        {
            return m_BasicDBClass.SelectRecordByPrimaryKeyEx<HiddenDangerEF>(ID);
        }

        public bool UpdateHiddenDangerData(int ID,string Organizer, DateTime CheckTime, string Participant,
            string RectificationMeasures, string Address)
        {
            HiddenDangerEF vData = new HiddenDangerEF()
            {
                ID = ID,
                Address = Address,
                CheckTime = CheckTime,
                Organizer = Organizer,
                Participant = Participant,
                RectificationMeasures = RectificationMeasures
            };
            return m_BasicDBClass.UpdateRecord(vData);
        }
        #endregion
    }
}
