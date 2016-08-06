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
        public Safe_HiddenDangerEF[] GetAllHiddenDangerData()
        {
            return m_BasicDBClass.SelectAllRecordsEx<Safe_HiddenDangerEF>();
        }

        public bool AddHiddenDangerData(string Organizer, DateTime CheckTime, string Participant,
            string RectificationMeasures, string Address)
        {
            Safe_HiddenDangerEF vData = new Safe_HiddenDangerEF()
            {
                Address = Address,
                CheckTime = CheckTime,
                Organizer = Organizer,
                Participant = Participant,
                RectificationMeasures = RectificationMeasures
            };
            return m_BasicDBClass.InsertRecord(vData) >= 0 ? true : false;
        }

        public Safe_HiddenDangerEF GetHiddenDangerDataByID(int ID)
        {
            return m_BasicDBClass.SelectRecordByPrimaryKeyEx<Safe_HiddenDangerEF>(ID);
        }

        public bool UpdateHiddenDangerData(int ID, string Organizer, DateTime CheckTime, string Participant,
            string RectificationMeasures, string Address)
        {
            Safe_HiddenDangerEF vData = new Safe_HiddenDangerEF()
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

        public bool DeleteHiddenDanger(string IDStr)
        {
            if (IDStr.Length > 0)
                IDStr = IDStr.Remove(IDStr.Length - 1);
            IDStr = IDStr.Replace('|', ',');
            return m_BasicDBClass.DeleteRecordCustom<Safe_HiddenDangerEF>(string.Format("ID in ({0})", IDStr));
        }
        #endregion

        #region 四防安全检查
        public Safe_SafetyCheckEF[] GetAllSafetyCheckData()
        {
            return m_BasicDBClass.SelectAllRecordsEx<Safe_SafetyCheckEF>();
        }

        public Safe_SafetyCheckEF GetSafetyCheckDataByID(int ID)
        {
            return m_BasicDBClass.SelectRecordByPrimaryKeyEx<Safe_SafetyCheckEF>(ID);
        }

        public bool UpdateSafetyCheckData( int ID,DateTime Time,string Position,
            string Condition,string Crew,string Memo)
        {
            Safe_SafetyCheckEF vData = new Safe_SafetyCheckEF()
            {
                ID = ID,
                CheckCondition = Condition,
                Crew = Crew,
                Memo = Memo,
                CheckPosition = Position,
                Time = Time
            };
            return m_BasicDBClass.UpdateRecord(vData);
        }

        public bool AddSafetyCheckData(DateTime Time, string Position,
            string Condition, string Crew, string Memo)
        {
            Safe_SafetyCheckEF vData = new Safe_SafetyCheckEF()
            {
                CheckCondition = Condition,
                Crew = Crew,
                Memo = Memo,
                CheckPosition = Position,
                Time = Time
            };
            return m_BasicDBClass.InsertRecord(vData) >= 0 ? true : false;
        }

        public bool DeleteSafetyCheck(string IDStr)
        {
            if (IDStr.Length > 0)
                IDStr = IDStr.Remove(IDStr.Length - 1);
            IDStr = IDStr.Replace('|', ',');
            return m_BasicDBClass.DeleteRecordCustom<Safe_SafetyCheckEF>(string.Format("ID in ({0})", IDStr));
        }

        #endregion

        #region 消防器材登记
        public Safe_FireFightingEF[] GetAllFireFightingData()
        {
            return m_BasicDBClass.SelectAllRecordsEx<Safe_FireFightingEF>();
        }

        public Safe_FireFightingEF GetFireFightingDataByID(int ID)
        {
            return m_BasicDBClass.SelectRecordByPrimaryKeyEx<Safe_FireFightingEF>(ID);
        }

        public bool UpdateFireFightingData( int ID,string Location, DateTime? InputTime, DateTime? BuyTime,int? ExtinguisherNum,
            int? FireplugNum,string Manager,string MaintainState,string Memo)
        {
            Safe_FireFightingEF vData = new Safe_FireFightingEF()
            {
                ID = ID,
                Location = Location,
                InputTime = InputTime,
                BuyTime = BuyTime,
                ExtinguisherNum = ExtinguisherNum,
                FireplugNum = FireplugNum,
                Manager = Manager,
                MaintainState = MaintainState,
                Memo = Memo
            };
            return m_BasicDBClass.UpdateRecord(vData);
        }

        public bool AddFireFightingData(string Location, DateTime? InputTime, DateTime? BuyTime, int? ExtinguisherNum,
            int? FireplugNum, string Manager, string MaintainState, string Memo)
        {
            Safe_FireFightingEF vData = new Safe_FireFightingEF()
            {
                Location = Location,
                 InputTime = InputTime,
                BuyTime = BuyTime,
                ExtinguisherNum = ExtinguisherNum,
                FireplugNum = FireplugNum,
                Manager = Manager,
                MaintainState = MaintainState,
                Memo = Memo
            };
            return m_BasicDBClass.InsertRecord(vData)>=0?true:false;
        }

        public bool DeleteFireFighting(string IDStr)
        {
            if (IDStr.Length > 0)
                IDStr = IDStr.Remove(IDStr.Length - 1);
            IDStr = IDStr.Replace('|', ',');
            return m_BasicDBClass.DeleteRecordCustom<Safe_FireFightingEF>(string.Format("ID in ({0})", IDStr));
        }
        #endregion

        #region 学生安全教育
        public Edu_Safe_Education[] GetAllEducationData()
        {
            return m_BasicDBClass.SelectAllRecordsEx<Edu_Safe_Education>();
        }

        public Edu_Safe_Education GetEducationDataByID(int ID)
        {
            return m_BasicDBClass.SelectRecordByPrimaryKeyEx<Edu_Safe_Education>(ID);
        }

        public bool UpdateEducationData(int ID, string Theme, DateTime Time, string Organizer, string Student,
            string Describe)
        {
            Edu_Safe_Education vData = new Edu_Safe_Education()
            {
                ID = ID,
                Theme = Theme,
                Time = Time,
                Organizer = Organizer,
                Student = Student,
                Describe = Describe
            };
            return m_BasicDBClass.UpdateRecord(vData);
        }

        public bool AddEducationData(string Theme, DateTime Time, string Organizer, string Student,
            string Describe)
        {
            Edu_Safe_Education vData = new Edu_Safe_Education()
            {
                Theme = Theme,
                Time = Time,
                Organizer = Organizer,
                Student = Student,
                Describe = Describe
            };
            return m_BasicDBClass.InsertRecord(vData) >= 0 ? true : false;
        }

        public bool DeletEducation(string IDStr)
        {
            if (IDStr.Length > 0)
                IDStr = IDStr.Remove(IDStr.Length - 1);
            IDStr = IDStr.Replace('|', ',');
            return m_BasicDBClass.DeleteRecordCustom<Edu_Safe_Education>(string.Format("ID in ({0})", IDStr));
        }
        #endregion
    }
}
