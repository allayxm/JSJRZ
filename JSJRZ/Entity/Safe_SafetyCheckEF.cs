using System;
using MXKJ.DBMiddleWareLib;

namespace MXKJ.Entity
{
    [TableAttrib("edu_safe_safetycheck", "ID")]
    public struct Safe_SafetyCheckEF
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }

        [ColumnAttrib("Time")]
        public DateTime? Time { get; set; }

        [ColumnAttrib("CheckPosition")]
        public string CheckPosition { get; set; }

        [ColumnAttrib("CheckCondition")]
        public String CheckCondition { get; set; }

        [ColumnAttrib("Crew")]
        public String Crew { get; set; }

        [ColumnAttrib("Memo")]
        public String Memo { get; set; }
    }
}
