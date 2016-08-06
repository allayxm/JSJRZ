using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MXKJ.Common;

namespace MXKJ.JSJRZ.WebUI.Models.DormitoryManager
{
    public class EditHouseViewModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "公寓楼")]
        public int? DormitoryID { get; set; }
        public String DormitoryName { get; set; }
        public List<System.Web.Mvc.SelectListItem> DormitoryList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        [Required]
        [RegularExpression(Regular.Regular_PositiveInteger, ErrorMessage = "楼层必须是整数")]
        [Display(Name = "楼层")]
        public int? Floor { get; set; }
        public string HouseNumber { get; set; }
        [Required]
        [RegularExpression(Regular.Regular_PositiveInteger, ErrorMessage = "床位数必须是整数")]
        [Display(Name = "床位数")]
        public int? BedNumber { get; set; }
        public String Area { get; set; }

        public bool IsUse { get; set; }
    }
}