using JournalVoucherAudit.Domain;
using JournalVoucherAudit.Service;
using JournalVoucherAudit.Utility;
using JournalVoucherAudit.WinformsUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;

namespace JournalVoucherAudit.WinformsUI
{
    public partial class Form1 : Form
    {
        #region 字段
        /// <summary>
        /// 报表标题组
        /// 依次分别为财务title，国库title，sheet名称
        /// </summary>
        private readonly Dictionary<string, Tuple<string, string, string, string>> _titleDict = new Dictionary<string, Tuple<string, string, string, string>>
        {
            { caiZheng, new Tuple<string,string,string,string>(caiZheng, "直接支付预算内", "直内", string.Format(foottext,caiZheng,caiZheng)) },
            { jiaoYu, new Tuple<string,string,string,string>(jiaoYu, "直接支付预算外", "直外",string.Format(foottext,jiaoYu,jiaoYu))},
            { gongGong , new Tuple<string,string,string,string>(gongGong , "授权支付预算内", "授权公共", string.Empty)},
            { zhuanHu, new Tuple<string,string,string,string>(zhuanHu, "授权支付预算外", "授权非税",string.Empty )}
        };

        private static string foottext = "注：{0}贷方本月发生额={1}贷方合计 - 收到财政授权支付资金额度 =";
        private static string caiZheng = "财政补助收入";
        private static string jiaoYu = "教育事业收入";
        private static string gongGong = "零余额公共财政预算";
        private static string zhuanHu = "零余额纳入专户管理的非税收入";
        /// <summary>
        /// 生效规则
        /// </summary>
        private ActiveRule _rule = ActiveRule.AbsWithAmount | ActiveRule.AmountWithCount | ActiveRule.NumberWithAmount | ActiveRule.NumberWithSingleRecord;

        /// <summary>
        /// 报表类型，与配置文件中的key相同
        /// </summary>
        private const string _CaiWu = "CaiWu";
        private const string _GuoKu = "GuoKu";

        #endregion

        #region 帮助方法
        /// <summary>
        /// 当前报表标题
        /// 次序分别为：财务标题、国库标题、sheet名称、页脚备注
        /// </summary>
        private Tuple<string, string, string, string> GetReportTitles(string title)
        {
            Tuple<string, string, string, string> titles;
            _titleDict.TryGetValue(title, out titles);
            return titles;
        }

        private int GetTitleIndex(string reportName)
        {
            //读取配置文件中标题行的行号
            var value = ConfigurationManager.AppSettings[reportName];
            int index = 0;
            //转换为整数
            int.TryParse(value, out index);
            return index;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 财务文件的标题
        /// 财政补助收入
        /// 教育事业收入
        /// 零余额公共财政预算
        /// 零余额纳入专户管理的非税收入
        /// </summary>
        private string _caiWuTitle = string.Empty;
        /// <summary>
        /// 财务数据列表
        /// </summary>
        private IList<CaiWuItem> CaiWuData
        {
            get
            {
                //检查文件路径
                if (string.IsNullOrWhiteSpace(txt_CaiWuFilePath.Text))
                {
                    return new List<CaiWuItem>();
                }
                //读取excel，封装为对象列表
                //var excelImportCaiWu = new Import(txt_CaiWuFilePath.Text, 4);

                //读取标题行的行号
                var index = GetTitleIndex(_CaiWu);
                var excelImportCaiWu = new Import(txt_CaiWuFilePath.Text, index);
                var items = excelImportCaiWu.ReadCaiWu<CaiWuItem>();

                //取文件标题
                _caiWuTitle = excelImportCaiWu.CaiWuTile;

                return items.ToList();
            }
        }
        /// <summary>
        /// 国库数据列表
        /// </summary>
        private IList<GuoKuItem> GuoKuData
        {
            get
            {
                //检查文件路径
                if (string.IsNullOrWhiteSpace(txt_GuoKuFilePath.Text))
                {
                    return new List<GuoKuItem>();
                }
                //读取excel，封装为对象列表
                //var excelImportGuoKu = new Import(txt_GuoKuFilePath.Text, 1);

                //读取标题行的行号
                var index = GetTitleIndex(_GuoKu);
                var excelImportGuoKu = new Import(txt_GuoKuFilePath.Text, index);
                var items = excelImportGuoKu.ReadGuoKu<GuoKuItem>();
                return items.ToList();
            }
        }
        /// <summary>
        /// 读取程序集信息，构造窗体的标题
        /// </summary>
        private string FormTitle
        {
            get
            {
                var title = string.Empty;
                var version = string.Empty;
                //读取程序集的title
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (!string.IsNullOrWhiteSpace(titleAttribute.Title))
                    {
                        title = titleAttribute.Title;
                    }
                }
                //读取程序集的版本
                version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                return title + "-" + version;
            }
        }

        #endregion

        #region 初始化

        public Form1()
        {
            InitializeComponent();
            dgv_CaiWu.RowPostPaint += dgv_CaiWu_RowPostPaint;
            dgv_GuoKu.RowPostPaint += dgv_GuoKu_RowPostPaint;
            Text = FormTitle;
        }

        #endregion

        #region 财务文件路径
        /// <summary>
        /// 选择财务excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CaiWuFilePath_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = Resources.FileFilter };
            if (DialogResult.OK.Equals(dialog.ShowDialog()))
            {
                //保存文件路径                
                txt_CaiWuFilePath.Text = dialog.FileName;
            }
        }
        /// <summary>
        /// 释放拖放文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_CaiWuFilePath_DragDrop(object sender, DragEventArgs e)
        {
            //获取文件路径
            string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            txt_CaiWuFilePath.Text = path;
        }
        /// <summary>
        /// 拖放文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_CaiWuFilePath_DragEnter(object sender, DragEventArgs e)
        {
            //拖放的是文件
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Link : DragDropEffects.None;
        }

        #endregion

        #region 国库文件路径
        /// <summary>
        /// 选择国库excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GuoKuFilePath_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = Resources.FileFilter };
            if (DialogResult.OK.Equals(dialog.ShowDialog()))
            {
                //保存文件路径
                txt_GuoKuFilePath.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// 释放拖放文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_GuoKuFilePath_DragDrop(object sender, DragEventArgs e)
        {
            //获取文件路径
            string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            txt_GuoKuFilePath.Text = path;
        }
        #endregion

        #region 对账与导出

        /// <summary>
        /// 对账
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Audit_Click(object sender, EventArgs e)
        {
            //lbl_Caution.Text = System.AppDomain.CurrentDomain.BaseDirectory + @"Template\Template.xml";
            //return;

            //检查数据文件
            if (!CaiWuData.Any() || !GuoKuData.Any())
            {
                lbl_Message.Text = Resources.ErrorMessage;
                return;
            }

            //重置消息
            lbl_Message.Text = string.Empty;

            //对账
            var caiWuAudit = new CaiWuAudit(_rule);
            var guoKuAudit = new GuoKuAudit(_rule);
            //取不符合要求的数据
            var caiWuException = caiWuAudit.Audit(CaiWuData, GuoKuData);
            var guoKuException = guoKuAudit.Audit(CaiWuData, GuoKuData);
            //转换为可排序列表
            var caiWuSort = new SortableBindingList<CaiWuItem>(caiWuException);
            //转换为可排序列表
            var guoKuSort = new SortableBindingList<GuoKuItem>(guoKuException);
            //绑定数据
            //将数据转换为可排序对象
            dgv_CaiWu.DataSource = caiWuSort.OrderBy(t => t.CreditAmount).ToList();

            dgv_GuoKu.DataSource = guoKuSort.OrderBy(t => t.Amount).ToList();
        }

        /// <summary>
        /// 导出excel报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Export_Click(object sender, EventArgs e)
        {
            //取出不符合要求的数据
            var caiWus = dgv_CaiWu.DataSource as IEnumerable<CaiWuItem>;
            var guoKus = dgv_GuoKu.DataSource as IEnumerable<GuoKuItem>;
            //检查数据源
            if (caiWus == null || guoKus == null)
            {
                lbl_Message.Text = Resources.ErrorMessage;
                return;
            }
            //合并两个集合为一个集合，便于报表处理
            var table = new TiaoJieTable(caiWus, guoKus);
            //计算发生额累计
            var caiWuTotal = CaiWuData.Sum(t => t.CreditAmount);
            var guoKuTotal = GuoKuData.Sum(t => t.Amount);
            //设置报表内标题与sheet名称
            var reportTitles = GetReportTitles(_caiWuTitle);
            //文件名
            var voucherDate = table.Data.First().VoucherDate.ToDateTime();
            var filename = $"{voucherDate.Year}年{voucherDate.Month}月-{reportTitles.Item3}-财务国库对账单";
            //保存文件对话
            SaveFileDialog saveFileDlg = new SaveFileDialog { Filter = Resources.FileFilter, FileName = filename };

            if (DialogResult.OK.Equals(saveFileDlg.ShowDialog()))
            {
                //导出excel
                var export = new Export();
                export.Save(saveFileDlg.FileName, reportTitles, caiWuTotal, guoKuTotal, table.Data);
                //提示消息
                lbl_Message.Text = Resources.ResultMessage;
            }
        }

        #endregion

        #region DataGridView添加序号
        /// <summary>
        /// 为DataGridView添加序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_CaiWu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgv_CaiWu.RowHeadersWidth,
                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgv_CaiWu.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgv_CaiWu.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        /// <summary>
        /// 为DataGridView添加序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_GuoKu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgv_GuoKu.RowHeadersWidth,
                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgv_GuoKu.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgv_GuoKu.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        #endregion

        #region 生效规则

        private void chk_AmountWithCount_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_AmountWithCount.Checked)
                _rule = _rule | ActiveRule.AmountWithCount;
            else
                _rule = _rule & ~ActiveRule.AmountWithCount;
        }

        private void chk_NumberWithAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_NumberWithAmount.Checked)
                _rule = _rule | ActiveRule.NumberWithAmount;
            else
                _rule = _rule & ~ActiveRule.NumberWithAmount;
        }

        private void chk_AbsWithAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_AbsWithAmount.Checked)
                _rule = _rule | ActiveRule.AbsWithAmount;
            else
                _rule = _rule & ~ActiveRule.AbsWithAmount;
        }

        private void chk_NumberWithSingleRecord_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_NumberWithSingleRecord.Checked)
                _rule = _rule | ActiveRule.NumberWithSingleRecord;
            else
                _rule = _rule & ~ActiveRule.NumberWithSingleRecord;
        }

        #endregion

    }
}
