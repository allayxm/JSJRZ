using System;
using MXKJ.DBMiddleWareLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXKJ.Entity
{
    [TableAttrib("edu_dormitory_admin", "ID")]
    public struct Dormitory_AdminEF
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("Name")]
        public String Name { get; set; }
        [ColumnAttrib("WorkType")]
        public String WorkType { get; set; }
        [ColumnAttrib("WorkTime")]
        public String WorkTime { get; set; }
        [ColumnAttrib("Dormitory")]
        public int? Dormitory { get; set; }
        [ColumnAttrib("Floor")]
        public int? Floor { get; set; }
        [ColumnAttrib("Duty")]
        public String Duty { get; set; }
        [ColumnAttrib("Tel")]
        public String Tel { get; set; }
        [ColumnAttrib("Memo")]
        public String Memo { get; set; }

    }
}
