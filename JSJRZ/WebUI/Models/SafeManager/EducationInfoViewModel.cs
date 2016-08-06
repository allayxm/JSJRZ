using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXKJ.JSJRZ.WebUI.Models.SafeManager
{
    public class EducationInfoViewModel
    {
        public List<EducationInfoItemViewModel> ItemList { get; set; } = new List<EducationInfoItemViewModel>();
    }


    public class EducationInfoItemViewModel
    {
        public int ID { get; set; }
        public String Theme { get; set; }
        public DateTime Time { get; set; }
        public String Organizer { get; set; }
        public String Student { get; set; }
        public String Describe { get; set; }
    }
}