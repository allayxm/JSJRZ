using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MXKJ.JSJRZ.WebUI.Models.SelfStatement
{
    public class ViewStatementViewModel
    {
        public List<ViewStatementItemViewModel> ItemList = new List<ViewStatementItemViewModel>();
    }
    public class ViewStatementItemViewModel
    {
        public int Year { get; set; }
        public string Rang { get; set; }

        public string Memo { get; set; }
    }
}