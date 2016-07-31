using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.Entity;

namespace MXKJ.BusinessLogic
{
    /// <summary>
    /// 宿舍管理
    /// </summary>
    public class Dormitory:BusinessLogicBase
    {
        #region 公寓管理
        public Dormitory_ItemsEF[] GetAllDormitory()
        {
            return m_BasicDBClass.SelectAllRecordsEx<Dormitory_ItemsEF>();
        }
        
        public bool AddDormitory( Dormitory_ItemsEF Dormitory)
        {
            return m_BasicDBClass.InsertRecord(Dormitory) == -1 ? false : true;
        }

        public Dormitory_ItemsEF GetDormitoryInfo(int ID)
        {
            Dormitory_ItemsEF vDormitory =  m_BasicDBClass.SelectRecordByPrimaryKeyEx< Dormitory_ItemsEF>(ID);
            return vDormitory;
        }

        public bool UpdateDormitoryInfo(Dormitory_ItemsEF DormitoryInfo)
        {
            return m_BasicDBClass.UpdateRecord(DormitoryInfo);
        }

        public bool DeleteDormitory(string IDStr)
        {
            if (IDStr.Length > 0)
                IDStr = IDStr.Remove(IDStr.Length - 1);
            IDStr = IDStr.Replace('|',',');
            return m_BasicDBClass.DeleteRecordCustom<Dormitory_ItemsEF>(string.Format("ID in ({0})", IDStr));
        }
        #endregion

        #region 宿舍管理
        public Dormitory_HouseViewEF[] GetAllHouseInfo()
        {
            return m_BasicDBClass.SelectAllRecordsEx<Dormitory_HouseViewEF>();
        }

        public bool CreateHouseByDormitory( int DormitoryID,string Unit, int Storey,int LyaerHouseNumber,int BedNumber)
        {
            bool vResult = false;
            Dormitory_ItemsEF vDormitoryInfo = m_BasicDBClass.SelectRecordByPrimaryKeyEx<Dormitory_ItemsEF>(DormitoryID);
            for( int i=1;i<= Storey;i++)
            {
                for( int j=1;j<= LyaerHouseNumber; j++)
                {
                    Dormitory_HouseEF vHouseData = new Dormitory_HouseEF()
                    {
                        DormitoryID = DormitoryID,
                        Area = "",
                        BedNumber = BedNumber,
                        Floor = i,
                        IsUse = true,
                        Number = string.Format("{0}{1}-{2}", Unit, i, j)
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

    }
}
