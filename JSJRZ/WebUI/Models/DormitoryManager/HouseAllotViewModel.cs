using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace MXKJ.JSJRZ.WebUI.Models.DormitoryManager
{
    public class HouseAllotViewModel
    {
        public List<HouseAllotInfoViewModel> HouseList { get; set; } = new List<HouseAllotInfoViewModel>();
        public List<SelectListItem> DormitoryList { get; set; } = new List<SelectListItem>();
        public string DormitorySelected { get; set; }
        public string FloorSelected { get; set; }

    }

    public class HouseAllotInfoViewModel
    {
        public int? ID { get; set; }
        public int? DormitoryID { get; set; }
        public String DormitoryName { get; set; }
        public int? Floor { get; set; }
        public String Number { get; set; }
        public String Area { get; set; }
        public int? BedNumber { get; set; }
        public int? ResidueBed { get; set; }
        public string StudentName { get; set; }
        public bool? IsUse { get; set; }
    }
}