using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MXKJ.JSJRZ.WebUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            #region 客户端校验
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            #endregion

            #region 客户端表格
            bundles.Add(new StyleBundle("~/bundles/DataTable/css").Include(
          "~/plugins/datatables/dataTables.bootstrap.css",
          "~/plugins/datatables/jquery.dataTables.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/DataTable/js").Include(
          "~/plugins/datatables/jquery.dataTables.min.js",
          "~/plugins/datatables/dataTables.bootstrap.min.js"));
            #endregion

            #region 切换开关
            bundles.Add(new StyleBundle("~/bundles/Switch/css").Include(
         "~/plugins/switch/bootstrap-switch.min.css",
         "~/plugins/switch/bootstrap-switch.css",
         "~/plugins/switch/main.css"
         ));

            bundles.Add(new ScriptBundle("~/bundles/Switch/js").Include(
         "~/plugins/switch/bootstrap-switch.min.js",
         "~/plugins/switch/highlight.js",
         "~/plugins/switch/main.js"
         ));
            #endregion

            #region 下拉列表
            bundles.Add(new StyleBundle("~/bundles/select2/css").Include(
         "~/plugins/select2/select2.min.css"
         ));
            bundles.Add(new ScriptBundle("~/bundles/select2/js").Include(
        "~/plugins/select2/select2.full.min.js"
        ));
            #endregion

            #region 弹出层
            bundles.Add(new ScriptBundle("~/bundles/layer/js").Include(
       "~/plugins/layer/layer.js"
       ));

            #endregion

            #region 日期控件
            bundles.Add(new StyleBundle("~/bundles/datepicker/css").Include(
         "~/plugins/datepicker/css/bootstrap-datetimepicker.min.css"
         ));

            bundles.Add(new ScriptBundle("~/bundles/datepicker/js").Include(
       "~/plugins/datepicker/js/bootstrap-datetimepicker.min.js",
        "~/plugins/datepicker/js/locales/bootstrap-datetimepicker.zh-CN.js"
       ));

            #endregion

            #region 日历控件
            bundles.Add(new StyleBundle("~/bundles/fullcalendar/css").Include(
         "~/plugins/fullcalendar/fullcalendar.min.css"
         ));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar/js").Include(
        "~/plugins/fullcalendar/moment.min.js",
        "~/plugins/fullcalendar/fullcalendar.min.js"
        ));
            #endregion
        }
    }
}