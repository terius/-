namespace LiHuo
{
    partial class InputReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labMessage = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnQueryCKTJ = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cboxCompany = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbShowKLY = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.etime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbIE_ALL = new System.Windows.Forms.RadioButton();
            this.rbE = new System.Windows.Forms.RadioButton();
            this.rbI = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.labTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.superGrid1 = new FGTran.SuperGrid();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labMessage);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnQueryCKTJ);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.cboxCompany);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.etime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.stime);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.labTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1111, 235);
            this.panel1.TabIndex = 0;
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.ForeColor = System.Drawing.Color.Red;
            this.labMessage.Location = new System.Drawing.Point(492, 196);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(0, 12);
            this.labMessage.TabIndex = 32;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnExport.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Location = new System.Drawing.Point(800, 169);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(157, 48);
            this.btnExport.TabIndex = 31;
            this.btnExport.Text = "导出Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQueryCKTJ
            // 
            this.btnQueryCKTJ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQueryCKTJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnQueryCKTJ.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQueryCKTJ.Location = new System.Drawing.Point(942, 110);
            this.btnQueryCKTJ.Name = "btnQueryCKTJ";
            this.btnQueryCKTJ.Size = new System.Drawing.Size(157, 48);
            this.btnQueryCKTJ.TabIndex = 30;
            this.btnQueryCKTJ.Text = "查询参考统计";
            this.btnQueryCKTJ.UseVisualStyleBackColor = false;
            this.btnQueryCKTJ.Click += new System.EventHandler(this.btnQueryCKTJ_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnExit.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(972, 169);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(127, 48);
            this.btnExit.TabIndex = 29;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cboxCompany
            // 
            this.cboxCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCompany.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxCompany.FormattingEnabled = true;
            this.cboxCompany.Location = new System.Drawing.Point(135, 147);
            this.cboxCompany.Name = "cboxCompany";
            this.cboxCompany.Size = new System.Drawing.Size(246, 27);
            this.cboxCompany.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.rbShowKLY);
            this.groupBox1.Location = new System.Drawing.Point(135, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 46);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.Location = new System.Drawing.Point(150, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(122, 20);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Text = "不显示空陆运";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbShowKLY
            // 
            this.rbShowKLY.AutoSize = true;
            this.rbShowKLY.Checked = true;
            this.rbShowKLY.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbShowKLY.Location = new System.Drawing.Point(12, 18);
            this.rbShowKLY.Name = "rbShowKLY";
            this.rbShowKLY.Size = new System.Drawing.Size(106, 20);
            this.rbShowKLY.TabIndex = 3;
            this.rbShowKLY.TabStop = true;
            this.rbShowKLY.Text = "显示空陆运";
            this.rbShowKLY.UseVisualStyleBackColor = true;
            this.rbShowKLY.CheckedChanged += new System.EventHandler(this.rbShowKLY_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 21);
            this.label5.TabIndex = 27;
            this.label5.Text = "统计类型：";
            // 
            // etime
            // 
            this.etime.Checked = false;
            this.etime.CustomFormat = "yyyy-MM-dd";
            this.etime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.etime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.etime.Location = new System.Drawing.Point(332, 188);
            this.etime.Name = "etime";
            this.etime.ShowCheckBox = true;
            this.etime.Size = new System.Drawing.Size(140, 26);
            this.etime.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(281, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 21);
            this.label2.TabIndex = 25;
            this.label2.Text = "到：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbIE_ALL);
            this.groupBox2.Controls.Add(this.rbE);
            this.groupBox2.Controls.Add(this.rbI);
            this.groupBox2.Location = new System.Drawing.Point(135, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 46);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // rbIE_ALL
            // 
            this.rbIE_ALL.AutoSize = true;
            this.rbIE_ALL.Checked = true;
            this.rbIE_ALL.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbIE_ALL.Location = new System.Drawing.Point(12, 18);
            this.rbIE_ALL.Name = "rbIE_ALL";
            this.rbIE_ALL.Size = new System.Drawing.Size(58, 20);
            this.rbIE_ALL.TabIndex = 5;
            this.rbIE_ALL.TabStop = true;
            this.rbIE_ALL.Text = "全部";
            this.rbIE_ALL.UseVisualStyleBackColor = true;
            // 
            // rbE
            // 
            this.rbE.AutoSize = true;
            this.rbE.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbE.Location = new System.Drawing.Point(221, 18);
            this.rbE.Name = "rbE";
            this.rbE.Size = new System.Drawing.Size(58, 20);
            this.rbE.TabIndex = 4;
            this.rbE.Text = "出口";
            this.rbE.UseVisualStyleBackColor = true;
            // 
            // rbI
            // 
            this.rbI.AutoSize = true;
            this.rbI.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbI.Location = new System.Drawing.Point(128, 17);
            this.rbI.Name = "rbI";
            this.rbI.Size = new System.Drawing.Size(58, 20);
            this.rbI.TabIndex = 3;
            this.rbI.Text = "进口";
            this.rbI.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(31, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 21);
            this.label4.TabIndex = 23;
            this.label4.Text = "进出口：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(53, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 21);
            this.label3.TabIndex = 22;
            this.label3.Text = "日期：";
            // 
            // stime
            // 
            this.stime.Checked = false;
            this.stime.CustomFormat = "yyyy-MM-dd";
            this.stime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.stime.Location = new System.Drawing.Point(135, 188);
            this.stime.Name = "stime";
            this.stime.ShowCheckBox = true;
            this.stime.Size = new System.Drawing.Size(140, 26);
            this.stime.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "公司名称：";
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnQuery.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(942, 48);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(157, 48);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查询统计";
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // labTitle
            // 
            this.labTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labTitle.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.Location = new System.Drawing.Point(0, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(1111, 45);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "label1";
            this.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.superGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 235);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1111, 518);
            this.panel2.TabIndex = 1;
            // 
            // superGrid1
            // 
            this.superGrid1.AllowUserToAddRows = false;
            this.superGrid1.AllowUserToDeleteRows = false;
            this.superGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.superGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.superGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.superGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGrid1.Location = new System.Drawing.Point(0, 0);
            this.superGrid1.Name = "superGrid1";
            this.superGrid1.PageSize = 15;
            this.superGrid1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superGrid1.RowTemplate.Height = 35;
            this.superGrid1.Size = new System.Drawing.Size(1111, 518);
            this.superGrid1.TabIndex = 0;
            this.superGrid1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.superGrid1_CellFormatting);
            // 
            // InputReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 753);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "InputReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据查询界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Input_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private FGTran.SuperGrid superGrid1;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker stime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbE;
        private System.Windows.Forms.RadioButton rbI;
        private System.Windows.Forms.DateTimePicker etime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rbShowKLY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboxCompany;
        private System.Windows.Forms.Button btnQueryCKTJ;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.RadioButton rbIE_ALL;
    }
}