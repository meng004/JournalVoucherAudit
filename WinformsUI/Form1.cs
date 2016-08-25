﻿using JournalVoucherAudit.Domain;
using JournalVoucherAudit.Service;
using JournalVoucherAudit.Utility;
using JournalVoucherAudit.WinformsUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace JournalVoucherAudit.WinformsUI
{
    public partial class Form1 : Form
    {
        #region 字段
        /// <summary>
        /// 报表标题组
        /// 依次分别为财务title，国库title，sheet名称
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
            Tuple<string, string, string> titles;
            _titleDict.TryGetValue(title, out titles);
            return titles;
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
                if (string.IsNullOrWhiteSpace(txt_CaiWuFilePath.Text)) return null;
                //读取excel，封装为对象列表
                var excelImportCaiWu = new Import(txt_CaiWuFilePath.Text, 4);
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
                if (string.IsNullOrWhiteSpace(txt_GuoKuFilePath.Text)) return null;
                //读取excel，封装为对象列表
                var excelImportGuoKu = new Import(txt_GuoKuFilePath.Text, 1);
                var items = excelImportGuoKu.ReadGuoKu<GuoKuItem>();
                return items.ToList();
            }
        }

        #endregion

        public Form1()
        {
            InitializeComponent();
            dgv_CaiWu.RowPostPaint += dgv_CaiWu_RowPostPaint;
            dgv_GuoKu.RowPostPaint += dgv_GuoKu_RowPostPaint;
        }

        #region 事件处理

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


        /// <summary>
        /// 对账
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Audit_Click(object sender, EventArgs e)
        {
            //重置消息
            lbl_Message.Text = string.Empty;

            ////对账
            //var audit = new Audit();
            ////不符合要求的财务数据
            //var caiWuException = audit.CNotInG(_CaiWuData, _GuoKuData);
            ////var caiWuException = audit.CaiWuNotInGuoKu(_CaiWuData, _GuoKuData);
            ////不符合要求的国库数据
            //var guoKuException = audit.GNotInC(_CaiWuData, _GuoKuData);
            ////var guoKuException = audit.GuoKuNotInCaiWu(_CaiWuData, _GuoKuData);

            //对账
            var caiWuAudit = new CaiWuAudit();
            var guoKuAudit = new GuoKuAudit();
            //取不符合要求的数据
            var caiWuException = caiWuAudit.Audit(CaiWuData, GuoKuData);
            var guoKuException = guoKuAudit.Audit(CaiWuData, GuoKuData);
            //绑定数据
            //将数据转换为可排序对象
            dgv_CaiWu.DataSource = caiWuException.OrderBy(t => t.CreditAmount).ToList();

            dgv_GuoKu.DataSource = guoKuException.OrderBy(t => t.Amount).ToList();
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
    }
}
