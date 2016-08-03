using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;

namespace MXKJ.Entity
{
    [TableAttrib("edu_students", "id")]
    public struct Edu_StudentsEF
    {
        [ColumnAttrib("id")]
        public int? id { get; set; }
        [ColumnAttrib("name")]
        public String name { get; set; }
        [ColumnAttrib("student_id")]
        public String student_id { get; set; }
        [ColumnAttrib("login_name")]
        public String login_name { get; set; }
        [ColumnAttrib("password")]
        public String password { get; set; }
        [ColumnAttrib("sex")]
        public string sex { get; set; }
        [ColumnAttrib("org_id")]
        public int? org_id { get; set; }
        [ColumnAttrib("mobile_phone")]
        public String mobile_phone { get; set; }
        [ColumnAttrib("is_send_msg")]
        public string is_send_msg { get; set; }
        [ColumnAttrib("name_index")]
        public String name_index { get; set; }
        [ColumnAttrib("birthday")]
        public int? birthday { get; set; }
        [ColumnAttrib("add_home")]
        public String add_home { get; set; }
        [ColumnAttrib("home_post_no")]
        public int? home_post_no { get; set; }
        [ColumnAttrib("qq")]
        public int? qq { get; set; }
        [ColumnAttrib("weixin")]
        public String weixin { get; set; }
        [ColumnAttrib("email")]
        public String email { get; set; }
        [ColumnAttrib("avatar")]
        public String avatar { get; set; }
        [ColumnAttrib("last_visit_time")]
        public int? last_visit_time { get; set; }
        [ColumnAttrib("last_pass_time")]
        public int? last_pass_time { get; set; }
        [ColumnAttrib("last_visit_ip")]
        public String last_visit_ip { get; set; }
        [ColumnAttrib("online")]
        public int? online { get; set; }
        [ColumnAttrib("on_status")]
        public string on_status { get; set; }
        [ColumnAttrib("order_no")]
        public int? order_no { get; set; }
        [ColumnAttrib("not_login")]
        public string not_login { get; set; }
        [ColumnAttrib("my_sign")]
        public String my_sign { get; set; }
        [ColumnAttrib("is_graduta")]
        public string is_graduta { get; set; }
        [ColumnAttrib("create_user")]
        public String create_user { get; set; }
        [ColumnAttrib("create_time")]
        public int? create_time { get; set; }
        [ColumnAttrib("HouseID")]
        public int? HouseID { get; set; }
    }

}
