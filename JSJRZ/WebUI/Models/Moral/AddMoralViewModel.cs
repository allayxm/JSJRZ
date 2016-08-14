using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MXKJ.JSJRZ.WebUI.Models.Moral
{
    public class AddMoralViewModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        //public String StudentsID { get; set; }
        //public String StudentsName { get; set; }
        public List<SelectListItem> TypeList { get; set; } = new List<SelectListItem>();
        [Display(Name = "操行评定")]
        [Required]
        public string TypeName { get; set; }
        public int Point { get; set; }
        public String Memo { get; set; }

        public string GradeSelected { get; set; }
        public List<SelectListItem> GradeList { get; set; } = new List<SelectListItem>();

        public string ClassSelected { get; set; }
        public List<SelectListItem> ClassList { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> StudenSelected_Left_List { get; set; } = new List<SelectListItem>();
        [Display(Name = "评定学生")]
        [Required]
        public string StudenSelected_Left { get; set; }

        public List<SelectListItem> StudenSelected_Right_List { get; set; } = new List<SelectListItem>();
        public string StudenSelected_Right { get; set; }
    }
}