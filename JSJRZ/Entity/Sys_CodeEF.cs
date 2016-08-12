using System;
using MXKJ.DBMiddleWareLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXKJ.Entity
{
    [TableAttrib("sys_code", "id")]
    public struct Sys_CodeEF
    {
        [ColumnAttrib("id")]
        public String id { get; set; }
        [ColumnAttrib("type_id")]
        public String type_id { get; set; }
        [ColumnAttrib("code_name")]
        public String code_name { get; set; }
        [ColumnAttrib("code_icon")]
        public String code_icon { get; set; }
        [ColumnAttrib("code_order")]
        public int? code_order { get; set; }
        [ColumnAttrib("is_buildin")]
        public String is_buildin { get; set; }
    }

}
