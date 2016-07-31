using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MXKJ.JSJRZ.WebUI.Models.DormitoryManager
{
    public class EditDormitoryViewModel
    {
        public int? ID { get; set; }
        [Required]
        [Display(Name = "建筑名称")]
        public String BuildName { get; set; }

        [Display(Name = "建筑类型")]
        public String BuildType { get; set; }

        public List<System.Web.Mvc.SelectListItem> BuildTypeList { get; set; } = new List<System.Web.Mvc.SelectListItem>()
        {
            new System.Web.Mvc.SelectListItem( ) { Text="房屋建筑",Value="房屋建筑" },
            new System.Web.Mvc.SelectListItem( ) { Text="围墙",Value="围墙" },
            new System.Web.Mvc.SelectListItem( ) { Text="校门",Value="校门" },
            new System.Web.Mvc.SelectListItem( ) { Text="其它",Value="其它" }
        };

        [Display(Name = "房屋状态")]
        public String HouseState { get; set; }

        public List<System.Web.Mvc.SelectListItem> HouseStateList { get; set; } = new List<System.Web.Mvc.SelectListItem>()
        {
            new System.Web.Mvc.SelectListItem( ) { Text="正常",Value="正常" },
            new System.Web.Mvc.SelectListItem( ) { Text="危房",Value="危房" },
            new System.Web.Mvc.SelectListItem( ) { Text="严重危房",Value="严重危房" },
            new System.Web.Mvc.SelectListItem( ) { Text="拟拆除",Value="拟拆除" },
            new System.Web.Mvc.SelectListItem( ) { Text="外借",Value="外借" },
            new System.Web.Mvc.SelectListItem( ) { Text="出租",Value="出租" },
            new System.Web.Mvc.SelectListItem( ) { Text="租用",Value="租用" },
            new System.Web.Mvc.SelectListItem( ) { Text="其它",Value="其它" }
        };

        [Required]
        [RegularExpression(@"^\+?[1-9][0-9]*$", ErrorMessage = "楼层必须是正数")]
        [Display(Name = "楼层")]
        public int? Storey { get; set; }

        [Display(Name = "建筑时间")]
        public String BuildTime { get; set; }

        [Display(Name = "占用面积")]
        public double? OccupiedArea { get; set; }

        [Display(Name = "面积")]
        public double? Area { get; set; }

        [Display(Name = "所在校区")]
        public String Campus { get; set; }

        [Required]
        [Display(Name = "楼编号")]
        public String Unit { get; set; }

        [Display(Name = "建筑用途")]
        public String Purpose { get; set; }

        public List<System.Web.Mvc.SelectListItem> PurposeList { get; set; } = new List<System.Web.Mvc.SelectListItem>()
        {
            new System.Web.Mvc.SelectListItem( ) { Text="学生宿舍",Value="学生宿舍" },
            new System.Web.Mvc.SelectListItem( ) { Text="教学楼",Value="教学楼" },
            new System.Web.Mvc.SelectListItem( ) { Text="办公楼",Value="办公楼" },
            new System.Web.Mvc.SelectListItem( ) { Text="其它",Value="其它" }
        };

        [Display(Name = "房屋结构")]
        public String HouseStructure { get; set; }
        public List<System.Web.Mvc.SelectListItem> HouseStructureList { get; set; } = new List<System.Web.Mvc.SelectListItem>()
        {
            new System.Web.Mvc.SelectListItem( ) { Text="框架结构",Value="框架结构" },
            new System.Web.Mvc.SelectListItem( ) { Text="砖混结构",Value="砖混结构" },
            new System.Web.Mvc.SelectListItem( ) { Text="砖木结构",Value="砖木结构" },
            new System.Web.Mvc.SelectListItem( ) { Text="土木结构",Value="土木结构" }
        };

        [Required]
        [RegularExpression(@"^\+?[1-9][0-9]*$", ErrorMessage = "房间数必须是正数")]
        [Display(Name = "每层最大房间数")]
        public int? LyaerHouseNumber { get; set; }

        [Display(Name = "楼管处电话")]
        public String ManagementTel { get; set; }

        [Display(Name = "建筑用费")]
        public String BuildMoney { get; set; }

        [Display(Name = "财产")]
        public String Property { get; set; }

        [Display(Name = "位置")]
        public String Position { get; set; }

        [Display(Name = "备注")]
        public String Memo { get; set; }
    }
}