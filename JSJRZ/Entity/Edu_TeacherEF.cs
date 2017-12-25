using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXKJ.Entity
{
    [TableAttrib("edu_teacher", "id")]
    public struct Edu_TeacherEF
    {
        [ColumnAttrib("id")]
        public int? id { get; set; }
        [ColumnAttrib("term")]
        public String term { get; set; }
        [ColumnAttrib("class_id")]
        public int? class_id { get; set; }
        [ColumnAttrib("grade_id")]
        public int? grade_id { get; set; }
        [ColumnAttrib("school_year")]
        public String school_year { get; set; }
        [ColumnAttrib("course_id")]
        public int? course_id { get; set; }
        [ColumnAttrib("teacher_id")]
        public int? teacher_id { get; set; }
        [ColumnAttrib("grade_name")]
        public String grade_name { get; set; }
        [ColumnAttrib("teacher_type")]
        public bool? teacher_type { get; set; }
        [ColumnAttrib("academic_year")]
        public String academic_year { get; set; }
    }

}
