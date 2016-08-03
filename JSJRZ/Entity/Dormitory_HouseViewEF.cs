using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;

namespace MXKJ.Entity
{
    [TableAttrib("edu_dormitory_houseview", true,"ID")]
    public struct Dormitory_HouseViewEF
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("DormitoryID")]
        public int? DormitoryID { get; set; }
        [ColumnAttrib("Floor")]
        public int? Floor { get; set; }
        [ColumnAttrib("Number")]
        public String Number { get; set; }
        [ColumnAttrib("Area")]
        public String Area { get; set; }
        [ColumnAttrib("BedNumber")]
        public int? BedNumber { get; set; }
        [ColumnAttrib("IsUse")]
        public bool? IsUse { get; set; }
        [ColumnAttrib("DormitoryName")]
        public String DormitoryName { get; set; }
        [ColumnAttrib("ResidueBed")]
        public int? ResidueBed { get; set; }
        [ColumnAttrib("StudentName")]
        public String StudentName { get; set; }
        [ColumnAttrib("StudentID")]
        public String StudentID { get; set; }
    }

}
