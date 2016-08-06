using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MXKJ.Common;

namespace MXKJ.JSJRZ.WebUI.Models.DormitoryManager
{
    public class CreateHouseViewModel
    {
        [Required]
        [Display(Name = "公寓楼")]
        public int? DormitoryID { get; set; }
        public String DormitoryName { get; set; }
        public List<System.Web.Mvc.SelectListItem> DormitoryList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public String Unit { get; set; }
        [Required]
        [RegularExpression(Regular.Regular_PositiveInteger, ErrorMessage = "楼层必须是整数")]
        [Display(Name = "楼层")]
        public int? Floor { get; set; }
        [Required]
        [RegularExpression(Regular.Regular_PositiveInteger, ErrorMessage = "房间数必须是整数")]
        [Display(Name = "房间数")]
        public int? Number { get; set; }
        [Required]
        [RegularExpression(Regular.Regular_PositiveInteger, ErrorMessage = "床位数必须是整数")]
        [Display(Name = "床位数")]
        public int? BedNumber { get; set; }
        public String Area { get; set; }
    }
}