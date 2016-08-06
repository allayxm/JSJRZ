using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXKJ.JSJRZ.WebUI.Models.SafeManager
{
    public class SafetyCheckInfoViewModel
    {
        public List<SafetyCheckInfoItemViewModel> ItemList { get; set; } = new List<SafetyCheckInfoItemViewModel>();
    }

    public class SafetyCheckInfoItemViewModel
    {
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public string Position { get; set; }
        public String Condition { get; set; }
        public String Crew { get; set; }
        public String Memo { get; set; }

    }
}