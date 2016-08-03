using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXKJ.JSJRZ.WebUI.Models.DormitoryManager
{
    public class HouseAllotViewModel
    {
        public int HouseID { get; set; }
        public string DormitoryName {get;set;}
        public string FloorName { get; set; }
        public string HouseNumber { get; set; }
        public string Area { get; set; }
        public int BedNumber { get; set; }
        public string StudentID { get; set; }
        public string StudentName { get; set; }
    }
}