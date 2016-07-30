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
    }
}
