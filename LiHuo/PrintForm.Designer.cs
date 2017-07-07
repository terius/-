namespace LiHuo
{
    partial class PrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintForm));
            this.button1 = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.printPreviewButton = new System.Windows.Forms.Button();
            this.runtimeDialogButton = new System.Windows.Forms.Button();
            this.printPreviewButton2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(338, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // printPreviewButton
            // 
            this.printPreviewButton.Location = new System.Drawing.Point(338, 185);
            this.printPreviewButton.Name = "printPreviewButton";
            this.printPreviewButton.Size = new System.Drawing.Size(75, 23);
            this.printPreviewButton.TabIndex = 2;
            this.printPreviewButton.Text = "打印预览";
            this.printPreviewButton.UseVisualStyleBackColor = true;
            this.printPreviewButton.Click += new System.EventHandler(this.printPreviewButton_Click_1);
            // 
            // runtimeDialogButton
            // 
            this.runtimeDialogButton.Location = new System.Drawing.Point(338, 225);
            this.runtimeDialogButton.Name = "runtimeDialogButton";
            this.runtimeDialogButton.Size = new System.Drawing.Size(75, 23);
            this.runtimeDialogButton.TabIndex = 3;
            this.runtimeDialogButton.Text = "button3";
            this.runtimeDialogButton.UseVisualStyleBackColor = true;
            this.runtimeDialogButton.Click += new System.EventHandler(this.runtimeDialogButton_Click_1);
            // 
            // printPreviewButton2
            // 
            this.printPreviewButton2.Location = new System.Drawing.Point(338, 267);
            this.printPreviewButton2.Name = "printPreviewButton2";
            this.printPreviewButton2.Size = new System.Drawing.Size(75, 23);
            this.printPreviewButton2.TabIndex = 4;
            this.printPreviewButton2.Text = "button3";
            this.printPreviewButton2.UseVisualStyleBackColor = true;
            this.printPreviewButton2.Click += new System.EventHandler(this.printPreviewButton2_Click);
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 485);
            this.Controls.Add(this.printPreviewButton2);
            this.Controls.Add(this.runtimeDialogButton);
            this.Controls.Add(this.printPreviewButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "PrintForm";
            this.Text = "PrintForm";
            this.Load += new System.EventHandler(this.PrintForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button printPreviewButton;
        private System.Windows.Forms.Button runtimeDialogButton;
        private System.Windows.Forms.Button printPreviewButton2;
    }
}