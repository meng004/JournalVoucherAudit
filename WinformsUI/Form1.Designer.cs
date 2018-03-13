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
            this.PaymentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemarkReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Audit = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chk_AbsWithAmount = new System.Windows.Forms.CheckBox();
            this.chk_NumberWithSingleRecord = new System.Windows.Forms.CheckBox();
            this.chk_NumberWithAmount = new System.Windows.Forms.CheckBox();
            this.chk_AmountWithCount = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_CaiWu = new System.Windows.Forms.DataGridView();
            this.VoucherNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VoucherDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GuoKu)).BeginInit();
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
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 108);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "比对数据";
            // 
            // lbl_Caution
            // 
            this.lbl_Caution.AutoSize = true;
            this.lbl_Caution.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Caution.Location = new System.Drawing.Point(7, 83);
            this.lbl_Caution.Name = "lbl_Caution";
            this.lbl_Caution.Size = new System.Drawing.Size(304, 16);
            this.lbl_Caution.TabIndex = 3;
            this.lbl_Caution.Text = "请先将国库与财务导出文件另存为xls文件";
            // 
            // btn_GuoKuFilePath
            // 
            this.btn_GuoKuFilePath.Location = new System.Drawing.Point(576, 48);
            this.btn_GuoKuFilePath.Name = "btn_GuoKuFilePath";
            this.btn_GuoKuFilePath.Size = new System.Drawing.Size(75, 23);
            this.btn_GuoKuFilePath.TabIndex = 1;
            this.btn_GuoKuFilePath.Text = "选择...";
            this.btn_GuoKuFilePath.UseVisualStyleBackColor = true;
            this.btn_GuoKuFilePath.Click += new System.EventHandler(this.btn_GuoKuFilePath_Click);
            // 
            // btn_CaiWuFilePath
            // 
            this.btn_CaiWuFilePath.Location = new System.Drawing.Point(576, 19);
            this.btn_CaiWuFilePath.Name = "btn_CaiWuFilePath";
            this.btn_CaiWuFilePath.Size = new System.Drawing.Size(75, 23);
            this.btn_CaiWuFilePath.TabIndex = 0;
            this.btn_CaiWuFilePath.Text = "选择...";
            this.btn_CaiWuFilePath.UseVisualStyleBackColor = true;
            this.btn_CaiWuFilePath.Click += new System.EventHandler(this.btn_CaiWuFilePath_Click);
            // 
            // txt_GuoKuFilePath
            // 
            this.txt_GuoKuFilePath.AllowDrop = true;
            this.txt_GuoKuFilePath.BackColor = System.Drawing.SystemColors.Window;
            this.txt_GuoKuFilePath.Location = new System.Drawing.Point(67, 50);
            this.txt_GuoKuFilePath.Name = "txt_GuoKuFilePath";
            this.txt_GuoKuFilePath.ReadOnly = true;
            this.txt_GuoKuFilePath.Size = new System.Drawing.Size(503, 21);
            this.txt_GuoKuFilePath.TabIndex = 1;
            this.txt_GuoKuFilePath.TabStop = false;
            this.txt_GuoKuFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_GuoKuFilePath_DragDrop);
            this.txt_GuoKuFilePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_CaiWuFilePath_DragEnter);
            // 
            // txt_CaiWuFilePath
            // 
            this.txt_CaiWuFilePath.AllowDrop = true;
            this.txt_CaiWuFilePath.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CaiWuFilePath.Location = new System.Drawing.Point(67, 21);
            this.txt_CaiWuFilePath.Name = "txt_CaiWuFilePath";
            this.txt_CaiWuFilePath.ReadOnly = true;
            this.txt_CaiWuFilePath.Size = new System.Drawing.Size(503, 21);
            this.txt_CaiWuFilePath.TabIndex = 1;
            this.txt_CaiWuFilePath.TabStop = false;
            this.txt_CaiWuFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_CaiWuFilePath_DragDrop);
            this.txt_CaiWuFilePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_CaiWuFilePath_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "国库数据";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "财务数据";
            // 
            // dgv_GuoKu
            // 
            this.dgv_GuoKu.AllowUserToAddRows = false;
            this.dgv_GuoKu.AllowUserToDeleteRows = false;
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
            this.PaymentNumber,
            this.CreateDate,
            this.Amount,
            this.RemarkReason});
            this.dgv_GuoKu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_GuoKu.Location = new System.Drawing.Point(0, 0);
            this.dgv_GuoKu.Name = "dgv_GuoKu";
            this.dgv_GuoKu.ReadOnly = true;
            this.dgv_GuoKu.RowTemplate.Height = 23;
            this.dgv_GuoKu.Size = new System.Drawing.Size(522, 337);
            this.dgv_GuoKu.TabIndex = 0;
            this.dgv_GuoKu.TabStop = false;
            // 
            // PaymentNumber
            // 
            this.PaymentNumber.DataPropertyName = "PaymentNumber";
            this.PaymentNumber.HeaderText = "支付令号";
            this.PaymentNumber.Name = "PaymentNumber";
            this.PaymentNumber.ReadOnly = true;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "生成日期";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "金额";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // RemarkReason
            // 
            this.RemarkReason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RemarkReason.DataPropertyName = "RemarkReason";
            this.RemarkReason.HeaderText = "摘要事由";
            this.RemarkReason.Name = "RemarkReason";
            this.RemarkReason.ReadOnly = true;
            // 
            // btn_Audit
            // 
            this.btn_Audit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Audit.Location = new System.Drawing.Point(228, 14);
            this.btn_Audit.Name = "btn_Audit";
            this.btn_Audit.Size = new System.Drawing.Size(75, 30);
            this.btn_Audit.TabIndex = 2;
            this.btn_Audit.Text = "对账";
            this.btn_Audit.UseVisualStyleBackColor = true;
            this.btn_Audit.Click += new System.EventHandler(this.btn_Audit_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Export.Location = new System.Drawing.Point(228, 50);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(75, 30);
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
            this.lbl_Message.Location = new System.Drawing.Point(6, 83);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(59, 16);
            this.lbl_Message.TabIndex = 4;
            this.lbl_Message.Text = "说明：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.chk_AbsWithAmount);
            this.groupBox3.Controls.Add(this.chk_NumberWithSingleRecord);
            this.groupBox3.Controls.Add(this.chk_NumberWithAmount);
            this.groupBox3.Controls.Add(this.chk_AmountWithCount);
            this.groupBox3.Controls.Add(this.lbl_Message);
            this.groupBox3.Controls.Add(this.btn_Audit);
            this.groupBox3.Controls.Add(this.btn_Export);
            this.groupBox3.Location = new System.Drawing.Point(680, 13);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(358, 108);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "生效规则";
            // 
            // chk_AbsWithAmount
            // 
            this.chk_AbsWithAmount.AutoSize = true;
            this.chk_AbsWithAmount.Checked = true;
            this.chk_AbsWithAmount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_AbsWithAmount.Location = new System.Drawing.Point(68, 67);
            this.chk_AbsWithAmount.Margin = new System.Windows.Forms.Padding(2);
            this.chk_AbsWithAmount.Name = "chk_AbsWithAmount";
            this.chk_AbsWithAmount.Size = new System.Drawing.Size(108, 16);
            this.chk_AbsWithAmount.TabIndex = 5;
            this.chk_AbsWithAmount.Text = "同凭证多次支付";
            this.chk_AbsWithAmount.UseVisualStyleBackColor = true;
            this.chk_AbsWithAmount.CheckedChanged += new System.EventHandler(this.chk_AbsWithAmount_CheckedChanged);
            // 
            // chk_NumberWithSingleRecord
            // 
            this.chk_NumberWithSingleRecord.AutoSize = true;
            this.chk_NumberWithSingleRecord.Checked = true;
            this.chk_NumberWithSingleRecord.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_NumberWithSingleRecord.Location = new System.Drawing.Point(68, 35);
            this.chk_NumberWithSingleRecord.Margin = new System.Windows.Forms.Padding(2);
            this.chk_NumberWithSingleRecord.Name = "chk_NumberWithSingleRecord";
            this.chk_NumberWithSingleRecord.Size = new System.Drawing.Size(120, 16);
            this.chk_NumberWithSingleRecord.TabIndex = 5;
            this.chk_NumberWithSingleRecord.Text = "单笔凭证号与金额";
            this.chk_NumberWithSingleRecord.UseVisualStyleBackColor = true;
            this.chk_NumberWithSingleRecord.CheckedChanged += new System.EventHandler(this.chk_NumberWithSingleRecord_CheckedChanged);
            // 
            // chk_NumberWithAmount
            // 
            this.chk_NumberWithAmount.AutoSize = true;
            this.chk_NumberWithAmount.Checked = true;
            this.chk_NumberWithAmount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_NumberWithAmount.Location = new System.Drawing.Point(68, 51);
            this.chk_NumberWithAmount.Margin = new System.Windows.Forms.Padding(2);
            this.chk_NumberWithAmount.Name = "chk_NumberWithAmount";
            this.chk_NumberWithAmount.Size = new System.Drawing.Size(120, 16);
            this.chk_NumberWithAmount.TabIndex = 5;
            this.chk_NumberWithAmount.Text = "同凭证分多笔支付";
            this.chk_NumberWithAmount.UseVisualStyleBackColor = true;
            this.chk_NumberWithAmount.CheckedChanged += new System.EventHandler(this.chk_NumberWithAmount_CheckedChanged);
            // 
            // chk_AmountWithCount
            // 
            this.chk_AmountWithCount.AutoSize = true;
            this.chk_AmountWithCount.Checked = true;
            this.chk_AmountWithCount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_AmountWithCount.Location = new System.Drawing.Point(68, 20);
            this.chk_AmountWithCount.Margin = new System.Windows.Forms.Padding(2);
            this.chk_AmountWithCount.Name = "chk_AmountWithCount";
            this.chk_AmountWithCount.Size = new System.Drawing.Size(96, 16);
            this.chk_AmountWithCount.TabIndex = 5;
            this.chk_AmountWithCount.Text = "金额与记录数";
            this.chk_AmountWithCount.UseVisualStyleBackColor = true;
            this.chk_AmountWithCount.CheckedChanged += new System.EventHandler(this.chk_AmountWithCount_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_GuoKu);
            this.panel1.Location = new System.Drawing.Point(528, 127);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 337);
            this.panel1.TabIndex = 6;
            // 
            // dgv_CaiWu
            // 
            this.dgv_CaiWu.AllowUserToAddRows = false;
            this.dgv_CaiWu.AllowUserToDeleteRows = false;
            this.dgv_CaiWu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CaiWu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VoucherNumber,
            this.VoucherDate,
            this.CreditAmount,
            this.Remark});
            this.dgv_CaiWu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_CaiWu.Location = new System.Drawing.Point(0, 0);
            this.dgv_CaiWu.Name = "dgv_CaiWu";
            this.dgv_CaiWu.ReadOnly = true;
            this.dgv_CaiWu.RowTemplate.Height = 23;
            this.dgv_CaiWu.Size = new System.Drawing.Size(504, 337);
            this.dgv_CaiWu.TabIndex = 0;
            this.dgv_CaiWu.TabStop = false;
            // 
            // VoucherNumber
            // 
            this.VoucherNumber.DataPropertyName = "VoucherNumber";
            this.VoucherNumber.HeaderText = "凭证号";
            this.VoucherNumber.Name = "VoucherNumber";
            this.VoucherNumber.ReadOnly = true;
            // 
            // VoucherDate
            // 
            this.VoucherDate.DataPropertyName = "VoucherDate";
            this.VoucherDate.HeaderText = "凭证日期";
            this.VoucherDate.Name = "VoucherDate";
            this.VoucherDate.ReadOnly = true;
            // 
            // CreditAmount
            // 
            this.CreditAmount.DataPropertyName = "CreditAmount";
            this.CreditAmount.HeaderText = "贷方金额";
            this.CreditAmount.Name = "CreditAmount";
            this.CreditAmount.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "摘要";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_CaiWu);
            this.panel2.Location = new System.Drawing.Point(13, 127);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 337);
            this.panel2.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 488);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1082, 526);
            this.MinimumSize = new System.Drawing.Size(967, 526);
            this.Name = "Form1";
            this.Text = "财务-国库对账系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GuoKu)).EndInit();
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
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_CaiWu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chk_AbsWithAmount;
        private System.Windows.Forms.CheckBox chk_NumberWithAmount;
        private System.Windows.Forms.CheckBox chk_AmountWithCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chk_NumberWithSingleRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemarkReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn VoucherNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn VoucherDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}

