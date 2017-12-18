using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MXKJ.JSJRZ.WebUI.Models.SelfStatement
{
    public class InputStatementViewModel
    {
        [Display(Name = "自我陈述")]
        public string Statement { get; set; }

        public int StudentID { get; set; }

    }
}