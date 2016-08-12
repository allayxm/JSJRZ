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
    }
}
