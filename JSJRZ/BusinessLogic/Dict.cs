using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.Entity;

namespace MXKJ.BusinessLogic
{
    public class Dict: BusinessLogicBase
    {
        /// <summary>
        /// 管理员职务
        /// </summary>
        /// <returns></returns>
        public Sys_CodeEF[] DormitoryManagerDuty()
        {
            Sys_CodeEF vQueryData = new Sys_CodeEF()
            {
                type_id = "DormitoryManager_Duty"
            };
            return m_BasicDBClass.SelectRecordsEx(vQueryData);
        }

        #region 操行评定字典
        public Sys_CodeEF[] MoralCode()
        {
            Sys_CodeEF vQueryData = new Sys_CodeEF()
            {
                type_id = "EDU_Moral"
            };
            return m_BasicDBClass.SelectRecordsEx(vQueryData);
        }

        public bool AddMoralCode( string Name,int Point )
        {
            Moral_CodeEF vData = new Moral_CodeEF()
            {
                Name = Name,
                Point = Point
            };
            return m_BasicDBClass.InsertRecord(vData) >= 0 ? true : false;
        }

        public bool EditMoralCode ( int ID, string Name, int Point)
        {
            Moral_CodeEF vData = new Moral_CodeEF()
            {
                ID = ID,
                Name = Name,
                Point = Point
            };
            return m_BasicDBClass.UpdateRecord(vData);
        }

        #endregion
    }
}
