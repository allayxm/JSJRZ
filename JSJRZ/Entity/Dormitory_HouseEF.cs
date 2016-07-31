using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;

namespace MXKJ.Entity
{
    [TableAttrib("Dormitory_House", "ID")]
    public struct Dormitory_HouseEF
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
    }
}
