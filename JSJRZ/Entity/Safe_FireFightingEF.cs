using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;

namespace MXKJ.Entity
{
    [TableAttrib("edu_safe_firefighting", "ID")]
    public struct Safe_FireFightingEF
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("Location")]
        public String Location { get; set; }
        [ColumnAttrib("InputTime")]
        public DateTime? InputTime { get; set; }
        [ColumnAttrib("BuyTime")]
        public DateTime? BuyTime { get; set; }
        [ColumnAttrib("ExtinguisherNum")]
        public int? ExtinguisherNum { get; set; }
        [ColumnAttrib("FireplugNum")]
        public int? FireplugNum { get; set; }
        [ColumnAttrib("Manager")]
        public String Manager { get; set; }
        [ColumnAttrib("MaintainState")]
        public String MaintainState { get; set; }
        [ColumnAttrib("Memo")]
        public String Memo { get; set; }
    }

}
