using ExcelReport;
using JournalVoucherAudit.Domain;
using NPOI.Extend;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JournalVoucherAudit.Utility;

namespace JournalVoucherAudit.Service
{
    public class Export
    {

        #region 字段
        /// <summary>
        /// 报表标题组
        /// </summary>
        private readonly Dictionary<string, Tuple<string, string, string>> _titleDict = new Dictionary<string, Tuple<string, string, string>>
        {
            { "财政补助收入", new Tuple<string,string,string>("财政补助收入", "直接支付预算内", "直内") },
            { "教育事业收入", new Tuple<string,string,string>("教育事业收入", "直接支付预算外", "直外")},
            { "零余额公共财政预算" , new Tuple<string,string,string>("零余额公共财政预算" , "授权支付预算内", "授权公共")},
            { "零余额纳入专户管理的非税收入", new Tuple<string,string,string>("零余额纳入专户管理的非税收入", "授权支付预算外", "授权非税" )}
        };

        #endregion

        #region 帮助方法
        /// <summary>
        /// 当前报表标题
        /// 次序分别为：财务标题、国库标题、sheet名称
        /// </summary>
        private Tuple<string, string, string> GetReportTitles(string title)
        {
            var titles = new Tuple<string, string, string>(string.Empty, string.Empty, "直内");
            _titleDict.TryGetValue(title, out titles);
            return titles;
        }

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
        #endregion

        /// <summary>
        /// 导出并保存
        /// </summary>
        /// <param name="filename">保存文件名，包含路径</param>
        /// <param name="title">财务文件中的title</param>
        /// <param name="caiWuTotal">财务累计</param>
        /// <param name="guoKuTotal">国库累计</param>
        /// <param name="tiaoJieBiao">调节表</param>
        public void Save(string filename, string title, double caiWuTotal, double guoKuTotal, IEnumerable<TiaoJieItem> tiaoJieBiao)
        {
            //设置报表内标题与sheet名称
            var reportTitles = GetReportTitles(title);
            //创建excel参数容器
            var workbookParameterContainer = new WorkbookParameterContainer();
            workbookParameterContainer.Load(@"Template\Template.xml");
            //创建sheet的参数容器
            var sheetParameterContainer = workbookParameterContainer["直内"];
            //计算小计
            var tiaoJieItems = tiaoJieBiao as IList<TiaoJieItem> ?? tiaoJieBiao.ToList();
            var caiWuSubTotal = tiaoJieItems.Sum(t => t.CreditAmount);
            var guoKuSubTotal = tiaoJieItems.Sum(t => t.Amount);
            //对账日期
            var voucherDate = tiaoJieItems.First().VoucherDate.ToDateTime();
            //月份的最后一天
            var lastDayOfMonth = voucherDate.LastDayOfMonth();
            
            //输出excel
            ExportHelper.ExportToLocal(@"Template\Template.xls", filename,
                new SheetFormatter("直内",
                    new PartFormatter(sheetParameterContainer["CaiWuTitle"], reportTitles.Item1),
                    new PartFormatter(sheetParameterContainer["GuoKuTitle"], reportTitles.Item2),
                    new CellFormatter(sheetParameterContainer["CurrentDate"], lastDayOfMonth.ToShortDateString()),
                    new CellFormatter(sheetParameterContainer["CaiWuTotal"], caiWuTotal),
                    new CellFormatter(sheetParameterContainer["GuoKuTotal"], guoKuTotal),
                    new CellFormatter(sheetParameterContainer["CaiWuSubTotal"], caiWuSubTotal),
                    new CellFormatter(sheetParameterContainer["GuoKuSubTotal"], guoKuSubTotal),
                    new CellFormatter(sheetParameterContainer["CaiWuBalance"], caiWuTotal - caiWuSubTotal),
                    new CellFormatter(sheetParameterContainer["GuoKuBalance"], guoKuTotal - guoKuSubTotal),
                    new TableFormatter<TiaoJieItem>(sheetParameterContainer["VoucherDate"], tiaoJieItems,
                        new CellFormatter<TiaoJieItem>(sheetParameterContainer["Amount"], t => t.Amount),
                        new CellFormatter<TiaoJieItem>(sheetParameterContainer["CreateDate"], t => t.CreateDate),
                        new CellFormatter<TiaoJieItem>(sheetParameterContainer["CreditAmount"], t => t.CreditAmount),
                        new CellFormatter<TiaoJieItem>(sheetParameterContainer["Remark"], t => t.Remark),
                        new CellFormatter<TiaoJieItem>(sheetParameterContainer["RemarkReason"], t => t.RemarkReason),
                        new CellFormatter<TiaoJieItem>(sheetParameterContainer["VoucherDate"], t => t.VoucherDate),
                        new CellFormatter<TiaoJieItem>(sheetParameterContainer["VoucherNumber"], t => t.VoucherNumber)
                        )
                    )
                );
            //修改sheetname
            SetSheetName(filename, reportTitles.Item3);
        }

    }
}
