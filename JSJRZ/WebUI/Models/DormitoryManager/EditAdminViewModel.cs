using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MXKJ.JSJRZ.WebUI.Models.DormitoryManager
{
    public class EditAdminViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "姓名")]
        public String Name { get; set; }
        public String WorkType { get; set; }
        public String WorkTime { get; set; }
        [Required]
        [Display(Name = "公寓楼")]
        public int Dormitory { get; set; }
        public List<SelectListItem> DormitoryList { get; set; } = new List<SelectListItem>();
        public int? Floor { get; set; }
        public String Duty { get; set; }
        public String Tel { get; set; }
        public String Memo { get; set; }
    }
}