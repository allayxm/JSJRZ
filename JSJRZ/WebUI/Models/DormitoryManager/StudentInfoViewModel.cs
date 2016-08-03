using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXKJ.JSJRZ.WebUI.Models.DormitoryManager
{
    public class StudentInfoViewModel
    {
        public string Name { get; set; }
        public string StudentID { get; set; }
        public string Sex { get; set; }
        public string MobileTel { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public string QQ { get; set; } 
        public string WeiXi { get; set; }
    }
}