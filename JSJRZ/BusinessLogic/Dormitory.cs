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
    }
}
