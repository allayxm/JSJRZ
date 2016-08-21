using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.Entity;
using MXKJ.DBMiddleWareLib;
using System.Data;

namespace MXKJ.BusinessLogic
{
    /// <summary>
    /// 操行管理
    /// </summary>
    public class Moral: BusinessLogicBase
    {
        #region 获取数据
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
        #endregion

        #region 增、删、改
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
        #endregion

        #region 操行统计
        /// <summary>
        /// 数据统计
        /// </summary>
        /// <returns></returns>
        public DataTable Statistics( int GradeID,int ClassID,DateTime StartDate,DateTime EndDate )
        {
            DataTable vMainTable = new DataTable();
            vMainTable.Columns.AddRange(new DataColumn[] {
                //new DataColumn("ID",typeof(Int32)),
                //new DataColumn("年级",typeof(Int32)),
                new DataColumn("班级编号",typeof(Int32)),
                new DataColumn("班级名称",typeof(string))
            });
            vMainTable.AcceptChanges();
            vMainTable.PrimaryKey = new DataColumn[] { vMainTable.Columns["班级编号"] };
            vMainTable.AcceptChanges();
            addTypeColumns(vMainTable,GradeID,ClassID,  StartDate,  EndDate);
            addStatisticsData(vMainTable, GradeID, ClassID, StartDate, EndDate);
            return vMainTable;
        }

        void addStatisticsData(DataTable MainTable,int GradeID, int ClassID, DateTime StartDate, DateTime EndDate)
        {
            string vSql = string.Format("Select ClassID,ClassName, TypeName,sum(point) as Point From edu_moral_recordview where"
               + " ( GradeID={0} or 0={0}) and (ClassID={1} or 0={1} ) and"
               + " Date>='{2:yyyy-MM-dd} 00:00:00' and Date<='{3:yyyy-MM-dd} 23:59:59'"
               + " group by ClassID,ClassName, TypeName", GradeID, ClassID, StartDate, EndDate);
            DataTable vStatisticsTable = m_BasicDBClass.SelectCustom(vSql);
            foreach( DataRow vTempRow in vStatisticsTable.Rows )
            {
                int vClassID = DBConvert.ToInt32( vTempRow["ClassID"]).Value;
                string vClassName = DBConvert.ToString(vTempRow["ClassName"]);
                string vTypeName = DBConvert.ToString(vTempRow["TypeName"]);
                int vPoint = DBConvert.ToInt32(vTempRow["Point"]).Value;
                DataRow vClssRow = MainTable.Rows.Find(vClassID);
                if (vClssRow != null )
                    vClssRow[vTypeName] = vPoint;
                else
                {
                    DataRow vNewRow = MainTable.NewRow();
                    vNewRow["班级编号"] = vClassID;
                    vNewRow["班级名称"] = vClassName;
                    vNewRow[vTypeName] = vPoint;
                    MainTable.Rows.Add(vNewRow);
                }
            }
            MainTable.AcceptChanges();
        }

        void addTypeColumns( DataTable MainTable, int GradeID, int ClassID, DateTime StartDate, DateTime EndDate)
        {
            string vSql = string.Format("Select TypeName From edu_moral_recordview where"
                + " ( GradeID={0} or 0={0}) and (ClassID={1} or 0={1} ) and"
                + " Date>='{2:yyyy-MM-dd} 00:00:00' and Date<='{3:yyyy-MM-dd} 23:59:59'"
                + " group by TypeName",
                GradeID,ClassID, StartDate, EndDate);
            DataTable vTypeTable = m_BasicDBClass.SelectCustom(vSql);
            foreach(DataRow vTempRow in vTypeTable.Rows )
            {
                string vColumnName = vTempRow["TypeName"].ToString();
                MainTable.Columns.AddRange(new DataColumn[] {
                    new DataColumn( vColumnName,typeof(Int32))
                });
            }
            MainTable.AcceptChanges();
        }
        #endregion
    }
}
