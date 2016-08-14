using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXKJ.JSJRZ.WebUI.Models.Moral
{
    public class MoralManageViewModel
    {
        public List<MoralManageItemViewModel> Items { get; set; } = new List<MoralManageItemViewModel>();
    }

    public class MoralManageItemViewModel
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public string ClassName { get; set; }
        public int Point { get; set; } 
        public string Memo { get; set; }
    }
}