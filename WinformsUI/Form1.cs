using JournalVoucherAudit.Domain;
using JournalVoucherAudit.Service;
using JournalVoucherAudit.WinformsUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JournalVoucherAudit.WinformsUI
{
    public partial class Form1 : Form
    {

        #region 属性

        /// <summary>
        /// 财务文件的标题
        /// 财政补助收入
        /// 教育事业收入
        /// 零余额公共财政预算
        /// 零余额纳入专户管理的非税收入
        /// </summary>
        private string _CaiWuTitle = string.Empty;
        /// <summary>
        /// 财务数据列表
        /// </summary>
        private IList<CaiWuItem> _CaiWuData
        {
            get
            {
                //检查文件路径
                if (string.IsNullOrWhiteSpace(txt_CaiWuFilePath.Text)) return null;
                //读取excel，封装为对象列表
                var excelImportCaiWu = new Import(txt_CaiWuFilePath.Text, 4);
                var items = excelImportCaiWu.ReadCaiWu<CaiWuItem>();

                //取文件标题
                _CaiWuTitle = excelImportCaiWu.CaiWuTile;

                return items.ToList();
            }
        }
        /// <summary>
        /// 国库数据列表
        /// </summary>
        private IList<GuoKuItem> _GuoKuData
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
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
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
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
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
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
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
            var caiWuException = caiWuAudit.Audit(_CaiWuData,_GuoKuData);
            var guoKuException = guoKuAudit.Audit(_CaiWuData,_GuoKuData);
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
            //保存文件对话
            SaveFileDialog saveFileDlg = new SaveFileDialog { Filter = Resources.FileFilter };

            if (DialogResult.OK.Equals(saveFileDlg.ShowDialog()))
            {
                //取出不符合要求的数据
                var caiWus = dgv_CaiWu.DataSource as IEnumerable<CaiWuItem>;
                var guoKus = dgv_GuoKu.DataSource as IEnumerable<GuoKuItem>;
                //合并两个集合为一个集合，便于报表处理
                var table = new TiaoJieTable(caiWus, guoKus);
                //计算发生额累计
                var caiWuTotal = _CaiWuData.Sum(t => t.CreditAmount);
                var guoKuTotal = _GuoKuData.Sum(t => t.Amount);

                //导出excel
                var export = new Export();
                export.Save(saveFileDlg.FileName, _CaiWuTitle, caiWuTotal, guoKuTotal, table.Data);

                lbl_Message.Text = "导出成功";
            };
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
