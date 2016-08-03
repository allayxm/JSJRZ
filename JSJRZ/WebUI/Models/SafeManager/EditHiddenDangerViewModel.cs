using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXKJ.JSJRZ.WebUI.Models.SafeManager
{
    public class EditHiddenDangerViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "组织者")]
        public String Organizer { get; set; }
        [Required]
        [Display(Name = "检查时间")]
        [RegularExpression(@"^[0-9]{4}-(((0[13578]|(10|12))-(0[1-9]|[1-2][0-9]|3[0-1]))|(02-(0[1-9]|[1-2][0-9]))|((0[469]|11)-(0[1-9]|[1-2][0-9]|30)))$", ErrorMessage = "请输入正确的时间")]
        public DateTime CheckTime { get; set; }
        public String Participant { get; set; }
        public String RectificationMeasures { get; set; }
        public String Address { get; set; }
    }
}