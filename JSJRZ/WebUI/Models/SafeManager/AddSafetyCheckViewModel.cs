using System;
using System.ComponentModel.DataAnnotations;
using MXKJ.Common;

namespace MXKJ.JSJRZ.WebUI.Models.SafeManager
{
    public class AddSafetyCheckViewModel
    {
        [Required]
        [Display(Name = "检查时间")]
        [RegularExpression(Regular.Regular_Date, ErrorMessage = "请输入正确的时间")]
        public DateTime? Time { get; set; }
        public string Position { get; set; }
        public String Condition { get; set; }
        public String Crew { get; set; }
        public String Memo { get; set; }
    }
}