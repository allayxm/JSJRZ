using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXKJ.Entity
{
    [TableAttrib("edu_org", "id")]
    public struct Edu_OrgEF
    {
        [ColumnAttrib("id")]
        public int? id { get; set; }
        [ColumnAttrib("name")]
        public String name { get; set; }
        [ColumnAttrib("normal_name")]
        public String normal_name { get; set; }
        [ColumnAttrib("level_type")]
        public bool? level_type { get; set; }
        [ColumnAttrib("section")]
        public bool? section { get; set; }
        [ColumnAttrib("status")]
        public bool? status { get; set; }
        [ColumnAttrib("parent_id")]
        public int? parent_id { get; set; }
        [ColumnAttrib("order_no")]
        public int? order_no { get; set; }
        [ColumnAttrib("main_leader")]
        public String main_leader { get; set; }
        [ColumnAttrib("other_leader")]
        public String other_leader { get; set; }
        [ColumnAttrib("address")]
        public String address { get; set; }
        [ColumnAttrib("long_name")]
        public String long_name { get; set; }
        [ColumnAttrib("wx_student_dept_id")]
        public int? wx_student_dept_id { get; set; }
        [ColumnAttrib("wx_parent_dept_id")]
        public int? wx_parent_dept_id { get; set; }
    }

}
