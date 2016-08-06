using System;
using System.ComponentModel.DataAnnotations;
using MXKJ.Common;

namespace MXKJ.JSJRZ.WebUI.Models.SafeManager
{
    public class AddFireFightingViewModel
    {
        [Required]
        [Display(Name = "器材位置")]
        public String Location { get; set; }
        [Display(Name = "填报时间")]
        [RegularExpression(Regular.Regular_Date, ErrorMessage = "请输入正确的填报时间")]
        public DateTime? InputTime { get; set; }
        [Display(Name = "购买时间")]
        [RegularExpression(Regular.Regular_Date, ErrorMessage = "请输入正确的购买时间")]
        public DateTime? BuyTime { get; set; }
        [Display(Name = "灭火器数量")]
        [RegularExpression(Regular.Regular_PositiveInteger, ErrorMessage = "请输入正确的灭火器数量")]
        public int? ExtinguisherNum { get; set; }
        [Display(Name = "消火栓个数")]
        [RegularExpression(Regular.Regular_PositiveInteger, ErrorMessage = "请输入正确的消火栓个数")]
        public int? FireplugNum { get; set; }
        public String Manager { get; set; }
        public String MaintainState { get; set; }
        public String Memo { get; set; }
    }
}