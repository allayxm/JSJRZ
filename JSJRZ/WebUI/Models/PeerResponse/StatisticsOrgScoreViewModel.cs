using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXKJ.JSJRZ.WebUI.Models.PeerResponse
{
    public class StatisticsOrgScoreViewModel
    {
        public List<StatisticsOrgScoreItemViewModel> Itmes { get; set; } = new List<StatisticsOrgScoreItemViewModel>();
    }

    public class StatisticsOrgScoreItemViewModel
    {
        public string StudentName { get; set; }

        public string EvaluateStudentName1 { get; set; }
        public int EvaluateScore1 { get; set; }

        public string EvaluateStudentName2 { get; set; }
        public int EvaluateScore2 { get; set; }

        public string EvaluateStudentName3 { get; set; }
        public int EvaluateScore3 { get; set; }

    }
}