using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXKJ.JSJRZ.WebUI.Models.Moral
{
    public class ViewDetailMoralViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string StudentsName { get; set; }
        public string Moral { get; set; }
        public int Point { get; set; }
        public string Memo { get; set; }
    }
}