using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;

namespace MXKJ.Entity
{
    [TableAttrib("edu_moral_code", "ID")]
    public struct Moral_CodeEF
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("Name")]
        public String Name { get; set; }
        [ColumnAttrib("Point")]
        public int? Point { get; set; }
    }

}
