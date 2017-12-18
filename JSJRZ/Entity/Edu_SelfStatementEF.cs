using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;

namespace MXKJ.Entity
{
    [TableAttrib("edu_selfstatement", "ID")]
    public struct Edu_SelfStatementEF
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("StudentID")]
        public int? StudentID { get; set; }
        [ColumnAttrib("StudentName")]
        public String StudentName { get; set; }
        [ColumnAttrib("Memo")]
        public String Memo { get; set; }
        [ColumnAttrib("Year")]
        public int? Year { get; set; }
        [ColumnAttrib("Range")]
        public int? Range { get; set; }
    }

}
