using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MXKJ.JSJRZ.WebUI.Models.Common
{
    public class StudentSelectViewModel
    {
        public string GradeSelected { get; set; }
        public List<SelectListItem> GradeList { get; set; } = new List<SelectListItem>();

        public string ClassSelected { get; set; }
        public List<SelectListItem> ClassList { get; set; } = new List<SelectListItem>();

        public string StudentName { get; set; }

        public List<SelectListItem> StudenList { get; set; } = new List<SelectListItem>();
        public string StudenSelected { get; set; }

        public List<SelectListItem> SelectedStudentList { get; set; } = new List<SelectListItem>();

    }
}