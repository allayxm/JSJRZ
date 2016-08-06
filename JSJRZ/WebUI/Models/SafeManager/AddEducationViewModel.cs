using System;
using System.ComponentModel.DataAnnotations;
using MXKJ.Common;


namespace MXKJ.JSJRZ.WebUI.Models.SafeManager
{
    public class AddEducationViewModel
    {
        [Required]
        [Display(Name = "主题")]
        public String Theme { get; set; }
        [Required]
        [Display(Name = "时间")]
        [RegularExpression(Regular.Regular_Date, ErrorMessage = "请输入正确的填报时间")]
        public DateTime Time { get; set; }
        public String Organizer { get; set; }
        public String Student { get; set; }
        public String Describe { get; set; }
    }
}