using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;

namespace MXKJ.BusinessLogic
{
    public class BusinessLogicBase
    {
        protected BasicDBClass m_BasicDBClass = null;

        public BusinessLogicBase()
        {
            m_BasicDBClass = new BasicDBClass(DataBaseType.MySql);
        }
    }
}
