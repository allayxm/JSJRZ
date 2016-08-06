using System;
using MXKJ.DBMiddleWareLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXKJ.Entity
{
    [TableAttrib("edu_safe_hiddendanger", "ID")]
    public struct Safe_HiddenDangerEF
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
       
        [ColumnAttrib("Organizer")]
        public String Organizer { get; set; }
        [ColumnAttrib("CheckTime")]
        public DateTime? CheckTime { get; set; }
        [ColumnAttrib("Participant")]
        public String Participant { get; set; }
        [ColumnAttrib("RectificationMeasures")]
        public String RectificationMeasures { get; set; }
        [ColumnAttrib("Address")]
        public String Address { get; set; }
    }

}
