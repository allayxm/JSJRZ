using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXKJ.Entity
{
    [TableAttrib("edu_peerresponse", "ID")]
    public struct Edu_PeerResponseEF
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
    }

}
