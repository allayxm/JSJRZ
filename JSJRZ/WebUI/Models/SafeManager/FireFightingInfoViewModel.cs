using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MXKJ.Common;

namespace MXKJ.JSJRZ.WebUI.Models.SafeManager
{
    public class FireFightingInfoViewModel
    {
        public List<SafeFireFightingInfoItemViewModel> ItemList { get; set; } = new List<SafeFireFightingInfoItemViewModel>();
    }

    public class SafeFireFightingInfoItemViewModel
    {
        public int? ID { get; set; }
        public String Location { get; set; }
        public DateTime? InputTime { get; set; }
        public DateTime? BuyTime { get; set; }
        public int? ExtinguisherNum { get; set; }
        public int? FireplugNum { get; set; }
        public String Manager { get; set; }
        public String MaintainState { get; set; }
        public String Memo { get; set; }
        
    }
}