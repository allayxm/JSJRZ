using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXKJ.JSJRZ.WebUI.Models.PeerResponse
{
    public class StudentScoringViewModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }

        public int EvaluateStudentID1 { get; set; }
        public int Score1 { get; set; }

        public int EvaluateStudentID2 { get; set; }
        public int Score2 { get; set; }

        public int EvaluateStudentID3 { get; set; }
        public int Score3 { get; set; }
    }
}