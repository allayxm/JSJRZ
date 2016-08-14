using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXKJ.Common.JsonStruct
{
    /// <summary>
    /// 日历Json
    /// </summary>
    public class JsonStruct_FullCalendar
    {
        public int id { get; set; }
        public string title { get; set; }
        public bool allDay { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string url { get; set; }
        public string[] className { get; set; }
        public bool editable { get; set; }
        public bool startEditable { get; set; }
        public bool durationEditable { get; set; }
        public string rendering { get; set; }
        public bool overlap { get; set; }
        public string constraint { get; set; }
        public string source { get; set; }
        public string color { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public string textColor { get; set; }
    }
}
