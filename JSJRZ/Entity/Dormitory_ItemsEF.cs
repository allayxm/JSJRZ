using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;

namespace MXKJ.Entity
{
    [TableAttrib("dormitory_items", "ID")]
    public struct Dormitory_ItemsEF
    {
        [ColumnAttrib("ID")]
        public int ID { get; set; }
        [ColumnAttrib("BuildName")]
        public String BuildName { get; set; }
        [ColumnAttrib("BuildType")]
        public String BuildType { get; set; }
        [ColumnAttrib("HouseState")]
        public String HouseState { get; set; }
        [ColumnAttrib("Storey")]
        public String Storey { get; set; }
        [ColumnAttrib("BuildTime")]
        public String BuildTime { get; set; }
        [ColumnAttrib("OccupiedArea")]
        public double? OccupiedArea { get; set; }
        [ColumnAttrib("Area")]
        public double? Area { get; set; }
        [ColumnAttrib("Campus")]
        public String Campus { get; set; }
        [ColumnAttrib("Unit")]
        public String Unit { get; set; }
        [ColumnAttrib("Purpose")]
        public String Purpose { get; set; }
        [ColumnAttrib("HouseStructure")]
        public String HouseStructure { get; set; }
        [ColumnAttrib("LyaerHouseNumber")]
        public int? LyaerHouseNumber { get; set; }
        [ColumnAttrib("ManagementTel")]
        public String ManagementTel { get; set; }
        [ColumnAttrib("BuildMoney")]
        public String BuildMoney { get; set; }
        [ColumnAttrib("Property")]
        public String Property { get; set; }
        [ColumnAttrib("Position")]
        public String Position { get; set; }
        [ColumnAttrib("Memo")]
        public String Memo { get; set; }
    }

}
