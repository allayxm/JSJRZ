using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MXKJ.JSJRZ.WebUI.Models.DormitoryManager
{
    public class HouseInfoViewModel
    {
        public List<HouseDetailInfoViewModel> HouseList { get; set; } = new List<HouseDetailInfoViewModel>();
    }

    public class HouseDetailInfoViewModel
    {
        public int? ID { get; set; }
        public int? DormitoryID { get; set; }
        public String DormitoryName { get; set; }
        public int? Floor { get; set; }
        public String Number { get; set; }
        public String Area { get; set; }
        public int? BedNumber { get; set; }
        public bool? IsUse { get; set; }
    }
}