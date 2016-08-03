using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace MXKJ.JSJRZ.WebUI.Models.DormitoryManager
{
    public class AdminInfoViewModel
    {
        public List<AdminInfoItemViewModel> AdminList { get; set; } = new List<AdminInfoItemViewModel>();
        public List<SelectListItem> DormitoryList { get; set; } = new List<SelectListItem>();
        public int DormitorySelected { get; set; }
        public List<SelectListItem> FloorList { get; set; } = new List<SelectListItem>();
        public int FloorSelected { get; set; }
    }

    public class AdminInfoItemViewModel
    {
        public int? ID { get; set; }
        public String Name { get; set; }
        public String WorkType { get; set; }
        public String WorkTime { get; set; }
        public string Dormitory { get; set; }
        public string Floor { get; set; }
        public String Duty { get; set; }
        public String Tel { get; set; }
        public String Memo { get; set; }
    }
}