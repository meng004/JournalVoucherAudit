using ExcelReport;
using ExcelReport.Driver.NPOI;
using ExcelReport.Renderers;
using JournalVoucherAudit.Domain;
using JournalVoucherAudit.Utility;
using NPOI.Extend;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JournalVoucherAudit.Service
{
    public class Export
    {

        private static string foottext = "注：{0}贷方本月发生额={1}贷方合计 - 收到财政授权支付资金额度";

        /// <summary>
        /// 修改第一个sheet的名称
        /// </summary>
        /// <param name="filename">文件名，包括路径</param>
        /// <param name="sheetName">新的sheet名</param>
        private void SetSheetName(string filename, string sheetName)
        {
            //更改sheetName
            var workbook = NPOIHelper.LoadWorkbook(filename);
            workbook.SetSheetName(0, sheetName);
            //保存文件            
            using (FileStream stream = File.OpenWrite(filename))
            {
                var buffer = workbook.SaveToBuffer();
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
            //文件更名
            //var path = Path.GetDirectoryName(filename);
            //var extension = Path.GetExtension(filename);
            //var newFilename = Path.Combine(path, sheetName + extension);
            //File.Move(filename, newFilename);
        }


        /// <summary>
        /// 导出并保存
        /// </summary>
        /// <param name="filename">保存文件名，包含路径</param>
        /// <param name="reportTitles">报表中的title</param>
        /// <param name="caiWuTotal">财务累计</param>
        /// <param name="guoKuTotal">国库累计</param>
        /// <param name="tiaoJieBiao">调节表</param>
        public void Save(string filename, Tuple<string, string, string> reportTitles, double caiWuTotal, double guoKuTotal, IEnumerable<TiaoJieItem> tiaoJieBiao)
        {
            // 项目启动时，添加
            Configurator.Put(".xlsx", new WorkbookLoader());
            //创建excel参数容器
            //var workbookParameterContainer = new WorkbookParameterContainer();
            var path = System.AppDomain.CurrentDomain.BaseDirectory;

            //var file = File.AppendText(System.AppDomain.CurrentDomain.BaseDirectory + "log.txt");
            //file.WriteLine(path);
            //file.Close();

            //workbookParameterContainer.Load(path + @"Template\Template.xml");
            //创建sheet的参数容器
            //var sheetParameterContainer = workbookParameterContainer["直内"];
            //计算小计
            var tiaoJieItems = tiaoJieBiao as IList<TiaoJieItem> ?? tiaoJieBiao.ToList();
            var caiWuSubTotal = tiaoJieItems.Sum(t => t.CreditAmount);
            var guoKuSubTotal = tiaoJieItems.Sum(t => t.Amount);
            //对账日期
            //文件名包含了报表日期，如：2020年3月-授权非税-财务国库对账单
            //因文件名使用绝对路径，所以先取文件名
            //文件名采用日期-科目-报表名的固定样式，日期取第一段
            var reportFilename = filename.Split('\\').Last();
            var tempDate = reportFilename.Split('-').First();
            var voucherDate = tempDate.ToDateTime();
            //月份的最后一天
            var lastDayOfMonth = voucherDate.LastDayOfMonth();

            //调节表title
            var title = reportTitles.Item1.Split('_').LastOrDefault();

            //输出excel
            ExportHelper.ExportToLocal(path + @"Template\Template.xlsx", filename,
                new SheetRenderer("直内",
                    new ParameterRenderer("Title", title),
                    new ParameterRenderer("CaiWuTitle", reportTitles.Item1),
                    new ParameterRenderer("GuoKuTitle", reportTitles.Item2),
                    new ParameterRenderer("CurrentDate", lastDayOfMonth.ToLongDateString()),//格式为2019年12月31日
                    new ParameterRenderer("CaiWuTotal", caiWuTotal),
                    new ParameterRenderer("GuoKuTotal", guoKuTotal),
                    new ParameterRenderer("CaiWuSubTotal", caiWuSubTotal),
                    new ParameterRenderer("GuoKuSubTotal", guoKuSubTotal),
                    new ParameterRenderer("CaiWuBalance", caiWuTotal - caiWuSubTotal),
                    new ParameterRenderer("GuoKuBalance", guoKuTotal - guoKuSubTotal),
                    //new ParameterRenderer("FootText", string.Format(foottext, reportTitles.Item1, reportTitles.Item1)),
                    new RepeaterRenderer<TiaoJieItem>("Reconciliation", tiaoJieItems,
                        // 财务，已入账未付款
                        // 日期，凭证号，摘要，金额
                        new ParameterRenderer<TiaoJieItem>("VoucherDate", t => t.VoucherDate),
                        new ParameterRenderer<TiaoJieItem>("VoucherNumber", t => t.VoucherNumber),
                        new ParameterRenderer<TiaoJieItem>("Remark", t => t.Remark),
                        new ParameterRenderer<TiaoJieItem>("CreditAmount", t => t.CreditAmount),
                        // 国库，已付款未入账
                        // 日期，摘要，金额
                        new ParameterRenderer<TiaoJieItem>("CreateDate", t => t.CreateDate),
                        new ParameterRenderer<TiaoJieItem>("RemarkReason", t => t.RemarkReason),
                        new ParameterRenderer<TiaoJieItem>("Amount", t => t.Amount)
                        )
                    )
                );
            //修改sheetname
            SetSheetName(filename, reportTitles.Item3);
        }

    }
}
