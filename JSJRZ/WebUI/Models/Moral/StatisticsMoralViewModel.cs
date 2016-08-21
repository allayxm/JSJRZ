using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data;
using System.Linq;
using System.Web;

namespace MXKJ.JSJRZ.WebUI.Models.Moral
{
    public class StatisticsMoralViewModel
    {
        public int GradeSelected { get; set; }
        public List<SelectListItem> GradeList { get; set; } = new List<SelectListItem>();

        public int ClassSelected { get; set; }
        public List<SelectListItem> ClassList { get; set; } = new List<SelectListItem>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DataTable StatisticsTable { get; set; } = new DataTable();
    }
}