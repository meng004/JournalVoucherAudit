namespace JournalVoucherAudit.WinformsUI
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_Caution = new System.Windows.Forms.Label();
            this.btn_GuoKuFilePath = new System.Windows.Forms.Button();
            this.btn_CaiWuFilePath = new System.Windows.Forms.Button();
            this.txt_GuoKuFilePath = new System.Windows.Forms.TextBox();
            this.txt_CaiWuFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_GuoKu = new System.Windows.Forms.DataGridView();
            this.paymentNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkReasonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zhiJieGongGongBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.caiZhengBuZhuShouRuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zhiJieGongGongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_Audit = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_CaiWu = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.voucherNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voucherDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GuoKu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zhiJieGongGongBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caiZhengBuZhuShouRuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zhiJieGongGongBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CaiWu)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_Caution);
            this.groupBox1.Controls.Add(this.btn_GuoKuFilePath);
            this.groupBox1.Controls.Add(this.btn_CaiWuFilePath);
            this.groupBox1.Controls.Add(this.txt_GuoKuFilePath);
            this.groupBox1.Controls.Add(this.txt_CaiWuFilePath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(26, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(1314, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "比对数据";
            // 
            // lbl_Caution
            // 
            this.lbl_Caution.AutoSize = true;
            this.lbl_Caution.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Caution.Location = new System.Drawing.Point(14, 166);
            this.lbl_Caution.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_Caution.Name = "lbl_Caution";
            this.lbl_Caution.Size = new System.Drawing.Size(607, 33);
            this.lbl_Caution.TabIndex = 3;
            this.lbl_Caution.Text = "请先将国库与财务导出文件另存为xls文件";
            // 
            // btn_GuoKuFilePath
            // 
            this.btn_GuoKuFilePath.Location = new System.Drawing.Point(1152, 96);
            this.btn_GuoKuFilePath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_GuoKuFilePath.Name = "btn_GuoKuFilePath";
            this.btn_GuoKuFilePath.Size = new System.Drawing.Size(150, 46);
            this.btn_GuoKuFilePath.TabIndex = 1;
            this.btn_GuoKuFilePath.Text = "选择...";
            this.btn_GuoKuFilePath.UseVisualStyleBackColor = true;
            this.btn_GuoKuFilePath.Click += new System.EventHandler(this.btn_GuoKuFilePath_Click);
            // 
            // btn_CaiWuFilePath
            // 
            this.btn_CaiWuFilePath.Location = new System.Drawing.Point(1152, 38);
            this.btn_CaiWuFilePath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_CaiWuFilePath.Name = "btn_CaiWuFilePath";
            this.btn_CaiWuFilePath.Size = new System.Drawing.Size(150, 46);
            this.btn_CaiWuFilePath.TabIndex = 0;
            this.btn_CaiWuFilePath.Text = "选择...";
            this.btn_CaiWuFilePath.UseVisualStyleBackColor = true;
            this.btn_CaiWuFilePath.Click += new System.EventHandler(this.btn_CaiWuFilePath_Click);
            // 
            // txt_GuoKuFilePath
            // 
            this.txt_GuoKuFilePath.AllowDrop = true;
            this.txt_GuoKuFilePath.BackColor = System.Drawing.SystemColors.Window;
            this.txt_GuoKuFilePath.Location = new System.Drawing.Point(134, 100);
            this.txt_GuoKuFilePath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_GuoKuFilePath.Name = "txt_GuoKuFilePath";
            this.txt_GuoKuFilePath.ReadOnly = true;
            this.txt_GuoKuFilePath.Size = new System.Drawing.Size(1002, 35);
            this.txt_GuoKuFilePath.TabIndex = 1;
            this.txt_GuoKuFilePath.TabStop = false;
            this.txt_GuoKuFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_GuoKuFilePath_DragDrop);
            this.txt_GuoKuFilePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_CaiWuFilePath_DragEnter);
            // 
            // txt_CaiWuFilePath
            // 
            this.txt_CaiWuFilePath.AllowDrop = true;
            this.txt_CaiWuFilePath.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CaiWuFilePath.Location = new System.Drawing.Point(134, 42);
            this.txt_CaiWuFilePath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_CaiWuFilePath.Name = "txt_CaiWuFilePath";
            this.txt_CaiWuFilePath.ReadOnly = true;
            this.txt_CaiWuFilePath.Size = new System.Drawing.Size(1002, 35);
            this.txt_CaiWuFilePath.TabIndex = 1;
            this.txt_CaiWuFilePath.TabStop = false;
            this.txt_CaiWuFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_CaiWuFilePath_DragDrop);
            this.txt_CaiWuFilePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_CaiWuFilePath_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "国库数据";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "财务数据";
            // 
            // dgv_GuoKu
            // 
            this.dgv_GuoKu.AllowUserToAddRows = false;
            this.dgv_GuoKu.AllowUserToDeleteRows = false;
            this.dgv_GuoKu.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_GuoKu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_GuoKu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_GuoKu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paymentNumberDataGridViewTextBoxColumn,
            this.createDateDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.remarkReasonDataGridViewTextBoxColumn});
            this.dgv_GuoKu.DataSource = this.zhiJieGongGongBindingSource1;
            this.dgv_GuoKu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_GuoKu.Location = new System.Drawing.Point(0, 0);
            this.dgv_GuoKu.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgv_GuoKu.Name = "dgv_GuoKu";
            this.dgv_GuoKu.ReadOnly = true;
            this.dgv_GuoKu.RowTemplate.Height = 23;
            this.dgv_GuoKu.Size = new System.Drawing.Size(1043, 674);
            this.dgv_GuoKu.TabIndex = 0;
            this.dgv_GuoKu.TabStop = false;
            // 
            // paymentNumberDataGridViewTextBoxColumn
            // 
            this.paymentNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.paymentNumberDataGridViewTextBoxColumn.DataPropertyName = "PaymentNumber";
            this.paymentNumberDataGridViewTextBoxColumn.HeaderText = "支付令编号";
            this.paymentNumberDataGridViewTextBoxColumn.Name = "paymentNumberDataGridViewTextBoxColumn";
            this.paymentNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.paymentNumberDataGridViewTextBoxColumn.Width = 175;
            // 
            // createDateDataGridViewTextBoxColumn
            // 
            this.createDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.createDateDataGridViewTextBoxColumn.DataPropertyName = "CreateDate";
            this.createDateDataGridViewTextBoxColumn.HeaderText = "支付令生成日期";
            this.createDateDataGridViewTextBoxColumn.Name = "createDateDataGridViewTextBoxColumn";
            this.createDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.createDateDataGridViewTextBoxColumn.Width = 223;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "金额";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 103;
            // 
            // remarkReasonDataGridViewTextBoxColumn
            // 
            this.remarkReasonDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.remarkReasonDataGridViewTextBoxColumn.DataPropertyName = "RemarkReason";
            this.remarkReasonDataGridViewTextBoxColumn.HeaderText = "摘要事由";
            this.remarkReasonDataGridViewTextBoxColumn.Name = "remarkReasonDataGridViewTextBoxColumn";
            this.remarkReasonDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // zhiJieGongGongBindingSource1
            // 
            this.zhiJieGongGongBindingSource1.DataSource = typeof(JournalVoucherAudit.Domain.GuoKuItem);
            // 
            // caiZhengBuZhuShouRuBindingSource
            // 
            this.caiZhengBuZhuShouRuBindingSource.DataSource = typeof(JournalVoucherAudit.Domain.CaiWuItem);
            // 
            // zhiJieGongGongBindingSource
            // 
            this.zhiJieGongGongBindingSource.DataSource = typeof(JournalVoucherAudit.Domain.GuoKuItem);
            // 
            // btn_Audit
            // 
            this.btn_Audit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Audit.Location = new System.Drawing.Point(123, 70);
            this.btn_Audit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_Audit.Name = "btn_Audit";
            this.btn_Audit.Size = new System.Drawing.Size(150, 60);
            this.btn_Audit.TabIndex = 2;
            this.btn_Audit.Text = "对账";
            this.btn_Audit.UseVisualStyleBackColor = true;
            this.btn_Audit.Click += new System.EventHandler(this.btn_Audit_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Export.Location = new System.Drawing.Point(467, 70);
            this.btn_Export.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(150, 60);
            this.btn_Export.TabIndex = 3;
            this.btn_Export.Text = "导出";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Message.ForeColor = System.Drawing.Color.Red;
            this.lbl_Message.Location = new System.Drawing.Point(41, 157);
            this.lbl_Message.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(114, 33);
            this.lbl_Message.TabIndex = 4;
            this.lbl_Message.Text = "说明：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_Message);
            this.groupBox3.Controls.Add(this.btn_Audit);
            this.groupBox3.Controls.Add(this.btn_Export);
            this.groupBox3.Location = new System.Drawing.Point(1359, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(715, 216);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_GuoKu);
            this.panel1.Location = new System.Drawing.Point(1055, 254);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1043, 674);
            this.panel1.TabIndex = 6;
            // 
            // dgv_CaiWu
            // 
            this.dgv_CaiWu.AllowUserToAddRows = false;
            this.dgv_CaiWu.AllowUserToDeleteRows = false;
            this.dgv_CaiWu.AutoGenerateColumns = false;
            this.dgv_CaiWu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CaiWu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.voucherNumberDataGridViewTextBoxColumn,
            this.voucherDateDataGridViewTextBoxColumn,
            this.creditAmountDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn});
            this.dgv_CaiWu.DataSource = this.caiZhengBuZhuShouRuBindingSource;
            this.dgv_CaiWu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_CaiWu.Location = new System.Drawing.Point(0, 0);
            this.dgv_CaiWu.Margin = new System.Windows.Forms.Padding(6);
            this.dgv_CaiWu.Name = "dgv_CaiWu";
            this.dgv_CaiWu.ReadOnly = true;
            this.dgv_CaiWu.RowTemplate.Height = 23;
            this.dgv_CaiWu.Size = new System.Drawing.Size(1007, 674);
            this.dgv_CaiWu.TabIndex = 0;
            this.dgv_CaiWu.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_CaiWu);
            this.panel2.Location = new System.Drawing.Point(26, 254);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1007, 674);
            this.panel2.TabIndex = 7;
            // 
            // voucherNumberDataGridViewTextBoxColumn
            // 
            this.voucherNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.voucherNumberDataGridViewTextBoxColumn.DataPropertyName = "VoucherNumber";
            this.voucherNumberDataGridViewTextBoxColumn.HeaderText = "凭证号";
            this.voucherNumberDataGridViewTextBoxColumn.Name = "voucherNumberDataGridViewTextBoxColumn";
            this.voucherNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.voucherNumberDataGridViewTextBoxColumn.Width = 127;
            // 
            // voucherDateDataGridViewTextBoxColumn
            // 
            this.voucherDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.voucherDateDataGridViewTextBoxColumn.DataPropertyName = "VoucherDate";
            this.voucherDateDataGridViewTextBoxColumn.HeaderText = "凭证日期";
            this.voucherDateDataGridViewTextBoxColumn.Name = "voucherDateDataGridViewTextBoxColumn";
            this.voucherDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.voucherDateDataGridViewTextBoxColumn.Width = 151;
            // 
            // creditAmountDataGridViewTextBoxColumn
            // 
            this.creditAmountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.creditAmountDataGridViewTextBoxColumn.DataPropertyName = "CreditAmount";
            this.creditAmountDataGridViewTextBoxColumn.HeaderText = "贷方金额";
            this.creditAmountDataGridViewTextBoxColumn.Name = "creditAmountDataGridViewTextBoxColumn";
            this.creditAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.creditAmountDataGridViewTextBoxColumn.Width = 151;
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn.HeaderText = "摘要";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            this.remarkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2122, 944);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "财务-国库对账系统";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GuoKu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zhiJieGongGongBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caiZhengBuZhuShouRuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zhiJieGongGongBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CaiWu)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_Caution;
        private System.Windows.Forms.Button btn_GuoKuFilePath;
        private System.Windows.Forms.Button btn_CaiWuFilePath;
        private System.Windows.Forms.TextBox txt_GuoKuFilePath;
        private System.Windows.Forms.TextBox txt_CaiWuFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_GuoKu;
        private System.Windows.Forms.Button btn_Audit;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.BindingSource zhiJieGongGongBindingSource;
        private System.Windows.Forms.BindingSource caiZhengBuZhuShouRuBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkReasonDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource zhiJieGongGongBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_CaiWu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn voucherNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn voucherDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
    }
}

