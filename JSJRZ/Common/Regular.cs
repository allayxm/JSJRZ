using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXKJ.Common
{
    public static class Regular
    {
        /// <summary>
        /// 日期
        /// </summary>
        public const string Regular_Date = @"^[0-9]{4}-(((0[13578]|(10|12))-(0[1-9]|[1-2][0-9]|3[0-1]))|(02-(0[1-9]|[1-2][0-9]))|((0[469]|11)-(0[1-9]|[1-2][0-9]|30)))$";
        /// <summary>
        /// 正整数
        /// </summary>
        public const string Regular_PositiveInteger = @"^\+?[1-9][0-9]*$";
    }
}
