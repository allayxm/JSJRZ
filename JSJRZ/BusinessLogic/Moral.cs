using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.Entity;

namespace MXKJ.BusinessLogic
{
    /// <summary>
    /// 操行管理
    /// </summary>
    public class Moral: BusinessLogicBase
    {
        public Moral_RecordViewEF[] GetDataByMonth( int Year,int Month )
        {
            string vSql = string.Format("Select *From edu_moral_recordview where year(date)={0} and MONTH(date)={1}",Year,Month);
            return m_BasicDBClass.SelectCustomEx<Moral_RecordViewEF>(vSql);
        }
        public Moral_RecordViewEF[] GetDataByRange(DateTime StartDate, DateTime EndDate)
        {
            string vSql = string.Format("Select *From edu_moral_recordview where (date between '{0:yyyy-MM-dd} 00:00:00' and '{1:yyyy-MM-dd} 23:59:59') ", StartDate,EndDate);
            return m_BasicDBClass.SelectCustomEx<Moral_RecordViewEF>(vSql);
        }

        public Moral_RecordViewEF GetDataByID(int ID)
        {
            return m_BasicDBClass.SelectRecordByPrimaryKeyEx<Moral_RecordViewEF>(ID);
        }

        public int Add( int ClassID,DateTime Date,string StudentsID,string StudentsName,
            string TypeName,int Point,string Memo)
        {
            Moral_Record vData = new Moral_Record()
            {
                ClassID = ClassID,
                Date = Date,
                StudentsID = StudentsID,
                Point = Point,
                StudentsName = StudentsName,
                TypeName = TypeName,
                Memo = Memo
            };
            return m_BasicDBClass.InsertRecord(vData);
        }

        public bool Edit(int ID,int ClassID, DateTime Date, string StudentsID, string StudentsName,
            string TypeName, int Point,string Memo)
        {
            Moral_Record vData = new Moral_Record()
            {
                ID = ID,
                ClassID = ClassID,
                Date = Date,
                StudentsID = StudentsID,
                Point = Point,
                StudentsName = StudentsName,
                TypeName = TypeName,
                Memo = Memo
            };
            return m_BasicDBClass.UpdateRecord<Moral_Record>(vData);
        }

        public bool Delete(int ID )
        {
            return m_BasicDBClass.DeleteRecordByPrimaryKey<Moral_Record>(ID);
        }
    }
}
