using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXKJ.JSJRZ.WebUI.Models.DormitoryManager
{
    public class DormitoryInfoViewModel
    {
        public List<DormitoryItemsViewModel> Items { get; set; } = new List<DormitoryItemsViewModel>();
    }

    public class DormitoryItemsViewModel
    {
        public int? ID { get; set; }

        public string BuildName { get; set; }

        public string Unit { get; set; }

        public string Campus { get; set; }

        public string Position { get; set; }

        public string ManagementTel { get; set; }

        public double Area { get; set; }

        public int? Storey { get; set; }

        public int? LyaerHouseNumber { get; set; }

    }
}