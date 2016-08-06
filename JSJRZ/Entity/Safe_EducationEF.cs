using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;

namespace MXKJ.Entity
{
    [TableAttrib("edu_safe_education", "ID")]
    public struct Edu_Safe_Education
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("Theme")]
        public String Theme { get; set; }
        [ColumnAttrib("Time")]
        public DateTime? Time { get; set; }
        [ColumnAttrib("Organizer")]
        public String Organizer { get; set; }
        [ColumnAttrib("Student")]
        public String Student { get; set; }
        [ColumnAttrib("Describe")]
        public String Describe { get; set; }
    }

}
