using JournalVoucherAudit.Domain;
using NPOI.Extend;
using System.Collections.Generic;
using System.Linq;

namespace JournalVoucherAudit.Service
{
    public class Import
    {
        /// <summary>
        /// 收财政支付资金额度的字符串
        /// </summary>
        private const string _ZiJinEDu = "收财政授权支付资金额度";
        /// <summary>
        /// 财务文件的标题
        /// </summary>
        private Dictionary<string, string> _TitleDict = new Dictionary<string, string>
        {
            { "财政拨款收入","财政补助收入" },
            { "事业收入","教育事业收入" },
            { "公共财政预算", "零余额公共财政预算" },
            { "纳入专户管理非税收入", "零余额纳入专户管理的非税收入" }
        };

        /// <summary>
        /// 标题行的行号
        /// </summary>
        private int _TitleRowIndex = 0;
        /// <summary>
        /// Excel文件路径
        /// </summary>
        private string _FilePath = string.Empty;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="filePath">Excel文件路径</param>
        /// <param name="titleRowIndex">标题行的行号</param>
        public Import(string filePath, int titleRowIndex)
        {
            _FilePath = filePath;
            _TitleRowIndex = titleRowIndex;
        }
        /// <summary>
        /// 转化为列表
        /// 处理财务数据
        /// </summary>   
        /// <typeparam name="CaiWu">财务</typeparam>
        /// <returns></returns>
        public IEnumerable<CaiWu> ReadCaiWu<CaiWu>()
            where CaiWu : CaiWuItem, new()
        {
            //读取excel
            var workbook = NPOIHelper.LoadWorkbook(_FilePath);
            //读取第一个sheet
            var sheet = workbook.GetSheetAt(0);
            //读取标题行
            var row = sheet.GetRow(_TitleRowIndex);
            //用表头创建‘标题名-列号’字典
            var cells = new Dictionary<string, int>();
            if (null != row)
            {
                for (int i = row.FirstCellNum; i < row.LastCellNum; i++)
                {
                    //取单元值
                    var cell = row.GetCell(i);
                    if (null == cell) continue;
                    //新建item
                    var key = cell.StringCellValue;
                    var value = cell.ColumnIndex;
                    //检查标题名是否为空
                    if (string.IsNullOrWhiteSpace(key)) continue;
                    //添加到字典
                    cells.Add(key, i);
                }
            }


            //新建list
            var list = new List<CaiWu>();
            //在list中插入数据
            //去掉第一行及最后两行数据
            for (int i = _TitleRowIndex + 2; i < sheet.LastRowNum - 2; i++)
            {
                //取excel的行数据
                var sheetRow = sheet.GetRow(i);
                //如果没有数据，读取下一行
                if (null == sheetRow) continue;
                //新建财务
                var caiWu = new CaiWu();
                caiWu.CreditAmount = sheetRow.GetCell(cells["贷方金额"]).NumericCellValue;
                caiWu.Remark = sheetRow.GetCell(cells["摘要"]).StringCellValue;
                caiWu.VoucherDate = sheetRow.GetCell(cells["凭证日期"]).StringCellValue;
                caiWu.VoucherNumber = sheetRow.GetCell(cells["凭证号"]).StringCellValue;
                list.Add(caiWu);
            }

            //删除“收财政授权支付资金额度”
            var ziJinEDu = list.Where(t => t.Remark.Contains(_ZiJinEDu)).ToList();
            var count = ziJinEDu.Count();
            if (null != ziJinEDu && ziJinEDu.Count() > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var item = ziJinEDu.ElementAt(i);
                    list.Remove(item);
                }
            }

            return list;
        }
        /// <summary>
        /// 转化为列表
        /// 处理国库数据
        /// </summary>
        /// <typeparam name="GuoKu">国库</typeparam>
        /// <returns></returns>
        public IEnumerable<GuoKu> ReadGuoKu<GuoKu>(string natureOfFunds = "经费拨款")
            where GuoKu : GuoKuItem, new()
        {
            //读取excel
            var workbook = NPOIHelper.LoadWorkbook(_FilePath);
            //读取第一个sheet
            var sheet = workbook.GetSheetAt(0);
            //读取标题行
            var row = sheet.GetRow(_TitleRowIndex);
            //用表头创建‘标题名-列号’字典
            var cells = new Dictionary<string, int>();
            if (null != row)
            {
                for (int i = row.FirstCellNum; i < row.LastCellNum; i++)
                {
                    //取单元值
                    var cell = row.GetCell(i);
                    if (null == cell) continue;
                    //新建item
                    var key = cell.ToString();
                    var value = cell.ColumnIndex;
                    //检查标题名是否为空
                    if (string.IsNullOrWhiteSpace(key)) continue;
                    //添加到字典
                    cells.Add(key, i);
                }
            }


            //新建list
            var list = new List<GuoKu>();
            //在list中插入数据
            //排除最后一行，总计金额，取lastrownum-1
            //2020.5.9 国库报表格式变更，最后一行不是总计金额，取lastrownum即可
            for (int i = _TitleRowIndex + 1; i <= sheet.LastRowNum ; i++)
            {
                //取excel的行数据
                var sheetRow = sheet.GetRow(i);
                //如果没有数据，读取下一行
                if (null == sheetRow) continue;
                //如果资金性质不匹配，读取下一行
                if (natureOfFunds != sheetRow.GetCell(cells["资金性质"]).StringCellValue) continue;
                //新建财务
                var guoKu = new GuoKu();
                guoKu.Amount = sheetRow.GetCell(cells["金额"]).NumericCellValue;
                guoKu.RemarkReason = sheetRow.GetCell(cells["摘要事由"]).StringCellValue;
                guoKu.CreateDate = sheetRow.GetCell(cells["银行支付日期"]).DateCellValue.ToShortDateString();
                guoKu.PaymentNumber = sheetRow.GetCell(cells["支付令编号"]).StringCellValue;
                list.Add(guoKu);
            }

            return list;
        }
        /// <summary>
        /// 标准化财务报表标题
        /// </summary>
        public string CaiWuTitle
        {
            get
            {
                //读取excel
                var workbook = NPOIHelper.LoadWorkbook(_FilePath);
                //读取第一个sheet
                var sheet = workbook.GetSheetAt(0);

                //读取财务导出数据的标题行
                var rownum = _TitleRowIndex - 2 < 0 ? 0 : _TitleRowIndex - 2;
                var titleRow = sheet.GetRow(rownum);
                //取单元值
                var titleCell = titleRow.Cells[0].StringCellValue;
                //取标题关键字
                //var keys = _TitleDict.Keys;
                //excel文件中是否包含该关键字
                //var key = keys.SingleOrDefault(k => titleCell.Contains(k));
                //取标准标题
                var value = string.Empty;
                //_TitleDict.TryGetValue(key, out value);

                //取科目编号
                //如[41010101]事业收入_教育事业收入_纳入专户管理的非税收入
                var index_begin = titleCell.IndexOf('[');
                //var index_end = titleCell.IndexOf(']');
                value = titleCell.Substring(index_begin);

                return value;
            }
        }
    }
}
