using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace MXKJ.JSJRZ.WebUI.Models.DormitoryManager
{
    public class HouseAllotInfoViewModel
    {
        public List<HouseAllotItemViewModel> HouseList { get; set; } = new List<HouseAllotItemViewModel>();
        public List<SelectListItem> DormitoryList { get; set; } = new List<SelectListItem>();
        public int DormitorySelected { get; set; }
        public List<SelectListItem> FloorList { get; set; } = new List<SelectListItem>();
        public int FloorSelected { get; set; }

    }

    public class HouseAllotItemViewModel
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