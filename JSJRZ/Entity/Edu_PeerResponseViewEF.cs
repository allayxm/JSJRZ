using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXKJ.Entity
{
    [TableAttrib("edu_peerresponseview", true, "ID")]
    public struct Edu_PeerResponseViewEF
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("Year")]
        public int? Year { get; set; }
        [ColumnAttrib("Range")]
        public int? Range { get; set; }
        [ColumnAttrib("StudentID")]
        public int? StudentID { get; set; }
        [ColumnAttrib("EvaluateStudentID")]
        public int? EvaluateStudentID { get; set; }
        [ColumnAttrib("Socre")]
        public int? Socre { get; set; }
        [ColumnAttrib("StudentName")]
        public String StudentName { get; set; }
        [ColumnAttrib("OrgID")]
        public int? OrgID { get; set; }
        [ColumnAttrib("EvaluateStudentName")]
        public String EvaluateStudentName { get; set; }
    }

}
