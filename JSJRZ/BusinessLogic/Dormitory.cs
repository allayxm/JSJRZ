using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.Entity;
using MXKJ.DBMiddleWareLib;
using System.Data.OleDb;
using System.Data;
using Excel;
using System.IO;

namespace MXKJ.BusinessLogic
{
    /// <summary>
    /// 宿舍管理
    /// </summary>
    public class Dormitory : BusinessLogicBase
    {
        #region 公寓管理
        public Dormitory_ItemsEF[] GetAllDormitory()
        {
            return m_BasicDBClass.SelectAllRecordsEx<Dormitory_ItemsEF>();
        }

        public bool AddDormitory(Dormitory_ItemsEF Dormitory)
        {
            return m_BasicDBClass.InsertRecord(Dormitory) == -1 ? false : true;
        }

        public Dormitory_ItemsEF GetDormitoryInfo(int ID)
        {
            Dormitory_ItemsEF vDormitory = m_BasicDBClass.SelectRecordByPrimaryKeyEx<Dormitory_ItemsEF>(ID);
            return vDormitory;
        }

        public bool UpdateDormitoryInfo(Dormitory_ItemsEF DormitoryInfo)
        {
            return m_BasicDBClass.UpdateRecord(DormitoryInfo);
        }

        public bool DeleteDormitory(string IDStr)
        {
            bool vResult = false;
            if (IDStr.Length > 0)
                IDStr = IDStr.Remove(IDStr.Length - 1);
            IDStr = IDStr.Replace('|', ',');
            m_BasicDBClass.TransactionBegin();
            vResult = m_BasicDBClass.DeleteRecordCustom<Dormitory_ItemsEF>(string.Format("ID in ({0})", IDStr));
            if (vResult)
            {
                string vUpdateSql = string.Format("update  edu_students set HouseID=null where HouseID in ( Select ID from edu_dormitory_house where edu_dormitory_house.DormitoryID in ({0}))", IDStr);
                m_BasicDBClass.UpdateRecord(vUpdateSql);
                vResult = m_BasicDBClass.DeleteRecordCustom<Dormitory_HouseEF>( string.Format("DormitoryID in ({0})",IDStr));
            }
            if (vResult)
                m_BasicDBClass.TransactionCommit();
            else
                m_BasicDBClass.TransactionRollback();
            return vResult;
        }
        #endregion

        #region 房间管理
        public Dormitory_HouseViewEF[] GetAllHouseInfo()
        {
            return m_BasicDBClass.SelectAllRecordsEx<Dormitory_HouseViewEF>("ID desc", "*");
        }
        public Dormitory_HouseViewEF GetHouseInfoByID(int ID)
        {
            return m_BasicDBClass.SelectRecordByPrimaryKeyEx<Dormitory_HouseViewEF>(ID);
        }

        public Dormitory_HouseViewEF[] GetHouseInfoByDormitory(int DormitoryID)
        {
            Dormitory_HouseViewEF[] vResult = new Dormitory_HouseViewEF[0];
            Dormitory_HouseViewEF vHouseEF = new Dormitory_HouseViewEF();
            vHouseEF.DormitoryID = DormitoryID;
            vResult = m_BasicDBClass.SelectRecordsEx(vHouseEF);
            return vResult;
        }

        public Dormitory_HouseViewEF[] QueryHouseInfoByDormitory(int DormitoryID, int Floor)
        {
            Dormitory_HouseViewEF[] vResult = new Dormitory_HouseViewEF[0];
            Dormitory_HouseViewEF vHouseEF = new Dormitory_HouseViewEF();
            if (DormitoryID == 0)
                vResult = m_BasicDBClass.SelectAllRecordsEx<Dormitory_HouseViewEF>();
            else if (Floor == 0)
            {
                vHouseEF.DormitoryID = DormitoryID;
                vResult = m_BasicDBClass.SelectRecordsEx(vHouseEF);
            }
            else
            {
                vHouseEF.DormitoryID = DormitoryID;
                vHouseEF.Floor = Floor;
                vResult = m_BasicDBClass.SelectRecordsEx(vHouseEF);
            }
            return vResult;
        }

        public bool UpdateHouseInfo(Dormitory_HouseEF House)
        {
            return m_BasicDBClass.UpdateRecord(House);
        }

        public bool AddHouse(Dormitory_HouseEF House)
        {
            return m_BasicDBClass.InsertRecord(House) > 0 ? true : false;
        }

        public bool DeleteHouse(string IDStr)
        {
            if (IDStr.Length>0 && IDStr[IDStr.Length-1] == '|')
                IDStr = IDStr.Remove(IDStr.Length - 1);
            IDStr = IDStr.Replace('|', ',');
            m_BasicDBClass.TransactionBegin();
            bool vResult = m_BasicDBClass.DeleteRecordCustom<Dormitory_HouseEF>(string.Format("ID in ({0})", IDStr));
            if (vResult)
            {
                string vUpdateSql = string.Format("Update edu_students set HouseID = NULL where HouseID in ({0})", IDStr);
                m_BasicDBClass.UpdateRecord(vUpdateSql);
                vResult = true;
            }
            if (vResult)
                m_BasicDBClass.TransactionCommit();
            else
                m_BasicDBClass.TransactionRollback();
            return vResult;
        }

        public bool CreateHouseByDormitory(int DormitoryID, string Unit, int Storey, int LyaerHouseNumber, int BedNumber, string Area)
        {
            bool vResult = false;
            Dormitory_ItemsEF vDormitoryInfo = m_BasicDBClass.SelectRecordByPrimaryKeyEx<Dormitory_ItemsEF>(DormitoryID);
            for (int i = 1; i <= Storey; i++)
            {
                for (int j = 1; j <= LyaerHouseNumber; j++)
                {
                    Dormitory_HouseEF vHouseData = new Dormitory_HouseEF()
                    {
                        DormitoryID = DormitoryID,
                        Area = Area,
                        BedNumber = BedNumber,
                        ResidueBed = BedNumber,
                        Floor = i,
                        IsUse = true,
                        Number = string.Format("{0}{1:D2}", i, j)
                    };
                    if (m_BasicDBClass.InsertRecord(vHouseData) > 0)
                        vResult = true;
                    else
                    {
                        vResult = false;
                        break;
                    }
                }
                if (!vResult)
                    break;
            }
            return vResult;
        }
        #endregion

        #region 房间分配

        /// <summary>
        /// 读取宿舍分配数据
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public string ReadHouseAllotData( Stream FileStream)
        {
            string vResult = "";
            //FileStream stream = File.Open(vOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);

            //1. Reading from a binary Excel file ('97-2003 format; *.xls)
            //IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(FileStream);
            //...
            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(FileStream);
            //...
            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            //DataSet result = excelReader.AsDataSet();
            //...
            //4. DataSet - Create column names from first row
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();
            excelReader.Close();

            if ( result.Tables.Count>0 )
            {
                DataTable vInputTable = result.Tables[0];
                //vInputTable.Columns.Add(new DataColumn("StudentID", typeof(int)));
                //vInputTable.AcceptChanges();

                
                //学生表
                DataTable vStudentsTable = m_BasicDBClass.SelectCustom("Select id,name,student_id From edu_students");
                //宿舍表
                Dormitory_HouseViewEF[] vHouseInfoArray = m_BasicDBClass.SelectAllRecordsEx<Dormitory_HouseViewEF>();
                
                foreach ( DataRow vTempRow in vInputTable.Rows)
                {
                    string vStudentID = DBConvert.ToString(vTempRow["学号"]);
                    DataRow[] vSelectedRows =  vStudentsTable.Select(string.Format("student_id='{0}'", vStudentID));
                    if (vSelectedRows!=null && vSelectedRows.Length>0)
                    {
                        int vID = (int)vSelectedRows[0]["ID"];
                        string vStudentName = DBConvert.ToString( vSelectedRows[0]["name"] );
                        int vSID = DBConvert.ToInt32(vSelectedRows[0]["ID"]).Value;
                        string vDormitoryName = DBConvert.ToString(vTempRow["公寓楼"]);
                        string vNumber = DBConvert.ToString(vTempRow["房间编号"]);

                        //已入住学生去除住宿信息
                        Dormitory_HouseViewEF[] vInHouseInfoArray = vHouseInfoArray.Where(m => m.StudentName!=null &&  m.StudentName.Contains(vStudentName)).ToArray();
                        if (vInHouseInfoArray != null && vInHouseInfoArray.Length>0)
                        {
                            foreach(Dormitory_HouseViewEF vTempInHouseInfo in vInHouseInfoArray)
                            {
                                int vIndex = getHouseInfoArrayIndex(vHouseInfoArray, vTempInHouseInfo.ID.Value);
                               
                                if (vTempInHouseInfo.StudentName.Split(',').Length== 1)
                                {
                                    Dormitory_HouseEF vDormitory_HouseEF = new Dormitory_HouseEF()
                                    {
                                        ID = vTempInHouseInfo.ID,
                                        ResidueBed = vTempInHouseInfo.BedNumber,
                                        StudentID = "",
                                        StudentName = ""
                                    };
                                    m_BasicDBClass.UpdateRecord<Dormitory_HouseEF>(vDormitory_HouseEF);
                                    vHouseInfoArray[vIndex].ResidueBed = vDormitory_HouseEF.ResidueBed;
                                    vHouseInfoArray[vIndex].StudentID = "";
                                    vHouseInfoArray[vIndex].StudentName = "";
                                }
                                else
                                {
                                    int vStudentNameIndex = vTempInHouseInfo.StudentName.IndexOf(vStudentName);
                                    int vStudentIDIndex = vTempInHouseInfo.StudentID.IndexOf(vSID.ToString());
                                    Dormitory_HouseEF vDormitory_HouseEF = new Dormitory_HouseEF()
                                    {
                                        ID = vTempInHouseInfo.ID,
                                        ResidueBed = vTempInHouseInfo.ResidueBed+1,
                                        StudentID = vStudentIDIndex==-1 || vStudentIDIndex == 0 ? vTempInHouseInfo.StudentID.Remove(0, vSID.ToString().Length+1):vTempInHouseInfo.StudentID.Remove(vStudentIDIndex-1, vSID.ToString().Length+1),
                                        StudentName = vStudentNameIndex==-1 || vStudentNameIndex == 0 ? vTempInHouseInfo.StudentName.Remove(0, vStudentName.Length+1):vTempInHouseInfo.StudentName.Remove(vStudentNameIndex-1, vStudentName.Length+1)
                                    };
                                    m_BasicDBClass.UpdateRecord<Dormitory_HouseEF>(vDormitory_HouseEF);
                                    vHouseInfoArray[vIndex].ResidueBed = vDormitory_HouseEF.ResidueBed;
                                    vHouseInfoArray[vIndex].StudentID = vDormitory_HouseEF.StudentID;
                                    vHouseInfoArray[vIndex].StudentName = vDormitory_HouseEF.StudentName;
                                }
                                //vInHouseInfoArray[vIndex].StudentName.Remove()
                            }
                        }

                        //重新分配住宿信息
                        Dormitory_HouseViewEF vSelectHouseInfo = vHouseInfoArray.Where(m => m.DormitoryName == vDormitoryName && m.Number == vNumber).FirstOrDefault();
                        if (vSelectHouseInfo.ID != null &&  vSelectHouseInfo.IsUse.Value && vSelectHouseInfo.ResidueBed>0)
                        {
                            Dormitory_HouseEF vDormitory_HouseEF = new Dormitory_HouseEF()
                            {
                                 ID= vSelectHouseInfo.ID,
                                 ResidueBed= vSelectHouseInfo.ResidueBed-1,
                                 StudentID = vSelectHouseInfo.StudentID == null || vSelectHouseInfo.StudentID==""? vID.ToString():vSelectHouseInfo.StudentID+","+ vID,
                                 StudentName = vSelectHouseInfo.StudentName==null || vSelectHouseInfo.StudentName==""? vStudentName:vSelectHouseInfo.StudentName+","+vStudentName
                            };
                            m_BasicDBClass.UpdateRecord<Dormitory_HouseEF>(vDormitory_HouseEF);
                            
                            int vIndex = getHouseInfoArrayIndex(vHouseInfoArray,vSelectHouseInfo.ID.Value);
                            vHouseInfoArray[vIndex].ResidueBed = vDormitory_HouseEF.ResidueBed;
                            vHouseInfoArray[vIndex].StudentID = vDormitory_HouseEF.StudentID;
                            vHouseInfoArray[vIndex].StudentName = vDormitory_HouseEF.StudentName;
                        }
                        else
                        {

                            if (vSelectHouseInfo.ID == null)
                            {
                                vResult += string.Format("{0}楼栋{1}号房间不存在\r\n", vDormitoryName, vNumber);
                                break;
                            }
                            if (!vSelectHouseInfo.IsUse.Value)
                            {
                                vResult += string.Format("{0}楼栋{1}号房间未开放\r\n", vDormitoryName, vNumber);
                                break;
                            }
                            if (vSelectHouseInfo.ResidueBed == 0)
                            {
                                vResult += string.Format("{0}楼栋{1}号房间床位已满\r\n", vDormitoryName, vNumber);
                                break;
                            }
                        }
                    }
                    else
                    {
                        vResult += string.Format("学号:{0} 学生不存在\r\n", vStudentID);
                    }
                }
                //vInputTable.AcceptChanges();
            }
            return vResult;
        }

        int getHouseInfoArrayIndex(Dormitory_HouseViewEF[] HouseInfoArray,int ID)
        {
            int vIndex = -1;
            for(int i=0;i< HouseInfoArray.Length;i++)
            {
                if (HouseInfoArray[i].ID == ID )
                {
                    vIndex = i;
                    break;
                }
            }
            return vIndex;
        }
        public bool HouseAllot(int HouseID, int BedNumber, string OldStudentsID, string StudentsID, string StudentsName)
        {
            bool vResult = false;
            string[] vUsersArray = StudentsID.Split(',');
            if (vUsersArray.Length <= BedNumber)
            {
                m_BasicDBClass.TransactionBegin();
                if (OldStudentsID != null && OldStudentsID != "")
                    vResult = m_BasicDBClass.UpdateRecord(string.Format("Update edu_students Set HouseID=null Where ID in ({0})", OldStudentsID));
                else
                    vResult = true;
                if ( vResult )
                    vResult = m_BasicDBClass.UpdateRecord(string.Format("Update edu_students Set HouseID={0} Where ID in ({1})", HouseID, StudentsID));
                if (vResult)
                {
                    Dormitory_HouseEF vHouseEF = new Dormitory_HouseEF();
                    vHouseEF.ID = HouseID;
                    vHouseEF.StudentID = StudentsID;
                    vHouseEF.StudentName = StudentsName;
                    vHouseEF.ResidueBed = BedNumber - vUsersArray.Length;
                    vResult = m_BasicDBClass.UpdateRecord(vHouseEF);
                }
                if (vResult)
                    m_BasicDBClass.TransactionCommit();
                else
                    m_BasicDBClass.TransactionRollback();
            }
            return vResult;
        }
        #endregion

        #region 管理人员
        public bool DeleteAdmin( string IDStr)
        {
            if (IDStr.Length > 0)
                IDStr = IDStr.Remove(IDStr.Length - 1);
            IDStr = IDStr.Replace('|', ',');
            return m_BasicDBClass.DeleteRecordCustom<Dormitory_AdminEF>(string.Format("ID in ({0})", IDStr));
        }

        public Dormitory_AdminViewEF[] GetAllAdminInfo()
        {
            return m_BasicDBClass.SelectAllRecordsEx<Dormitory_AdminViewEF>();
        }

        public Dormitory_AdminViewEF[] QueryAdminInfoByDormitory(int DormitoryID, int Floor)
        {
            Dormitory_AdminViewEF [] vResult = new Dormitory_AdminViewEF[0];
            Dormitory_AdminViewEF vAdminEF = new Dormitory_AdminViewEF();
            if (DormitoryID == 0)
                vResult = m_BasicDBClass.SelectAllRecordsEx<Dormitory_AdminViewEF>();
            else if (Floor == 0)
            {
                vAdminEF.Dormitory = DormitoryID;
                vResult = m_BasicDBClass.SelectRecordsEx(vAdminEF);
            }
            else
            {
                vAdminEF.Dormitory = DormitoryID;
                vAdminEF.Floor = Floor;
                vResult = m_BasicDBClass.SelectRecordsEx(vAdminEF);
            }
            return vResult;
        }

        public Dormitory_AdminViewEF GetAdminInfoByID( int AdminID )
        {
            return m_BasicDBClass.SelectRecordByPrimaryKeyEx<Dormitory_AdminViewEF>(AdminID);
        }

        public bool AddAdmin( string Name, string WorkType, string WorkTime,
            int Dormitory, int? Floor, string Duty, string Tel, string Memo)
        {
            Dormitory_AdminEF vAdminEF = new Dormitory_AdminEF()
            {
                Dormitory = Dormitory,
                Duty = Duty,
                Floor = Floor,
                Memo = Memo,
                Name = Name,
                Tel = Tel,
                WorkTime = WorkTime,
                WorkType = WorkType
            };
            return m_BasicDBClass.InsertRecord(vAdminEF)>=0?true:false ;
        }

        public bool UpdateAdminInfo( int AdminID,string Name,string WorkType,string WorkTime,
            int Dormitory,int? Floor,string Duty,string Tel,string Memo)
        {
            Dormitory_AdminEF vAdminEF = new Dormitory_AdminEF()
            {
                ID = AdminID,
                Dormitory = Dormitory,
                Duty = Duty,
                Floor = Floor,
                Memo = Memo,
                Name = Name,
                Tel = Tel,
                WorkTime = WorkTime,
                WorkType = WorkType
            };
            return m_BasicDBClass.UpdateRecord(vAdminEF);
        }
        #endregion


    }
}
