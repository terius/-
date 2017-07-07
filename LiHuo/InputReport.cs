using BLL;
using Helpers;
using Model;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace LiHuo
{
    public partial class InputReport : Form
    {
        private readonly InputBLL bll = new InputBLL();
        bool showKJTJ = false;
        public InputReport()
        {
          //  GlobalVariable.LoginUserInfo = new UserBLL().GetUserInfoByLoginName("admin");
            InitializeComponent();
        }

        private void Input_Load(object sender, EventArgs e)
        {
            labTitle.Text = GlobalVariable.LoginUserInfo.UserName + "(" + GlobalVariable.LoginUserInfo.CompanyName + ")";
            InitDataGridView();
            BindCompany();
        }

        private void BindCompany()
        {
            DataTable dt = bll.GetCompanyList();
            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "-----全部----";
            dt.Rows.InsertAt(dr, 0);
            cboxCompany.DataSource = dt;
            cboxCompany.DisplayMember = "CompanyName";
            cboxCompany.ValueMember = "CompanyId";
        }

        private void InitDataGridView()
        {
            superGrid1.EnableHeadersVisualStyles = false;
            this.superGrid1.Columns.Clear();
            CommonHelper.AddColumn(this.superGrid1, "类别", "TradeType");
            ShowAL = rbShowKLY.Checked ? true : false;
            if (ShowAL)
            {
                CommonHelper.AddColumn(this.superGrid1, "空陆运", "A_L_TYPE");
            }
            CommonHelper.AddColumn(this.superGrid1, "总票数", "Ticket");
            CommonHelper.AddColumn(this.superGrid1, "总件数", "Piece");
            CommonHelper.AddColumn(this.superGrid1, "总重量(KG)", "Weight");
            CommonHelper.AddColumn(this.superGrid1, "总价值(元)", "Price");
            //  SetBorderAndGridlineStyles();


        }

        private void SetBorderAndGridlineStyles()
        {
            this.superGrid1.GridColor = Color.BlueViolet;
            this.superGrid1.BorderStyle = BorderStyle.Fixed3D;
            this.superGrid1.CellBorderStyle =
                DataGridViewCellBorderStyle.Single;
            this.superGrid1.RowHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            this.superGrid1.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
        }




        private void btnQuery_Click(object sender, EventArgs e)
        {
            showKJTJ = false;
            DataTable dt = QueryData();
            this.superGrid1.DataSource = dt;
        }
        bool ShowAL = true;
        //private void CheckKLYShow()
        //{
        //    ShowAL = rbShowKLY.Checked ? true : false;
        //    if (ShowAL)
        //    {
        //        this.superGrid1.Columns["A_L_TYPE"].Visible = true;
        //    }
        //    else
        //    {
        //        this.superGrid1.Columns["A_L_TYPE"].Visible = false;
        //    }
        //}

        private void superGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.superGrid1.Columns.Contains("A_L_TYPE") && this.superGrid1.Rows[e.RowIndex].Cells["A_L_TYPE"].Value.ToString() == "合计")
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 239, 213);

            }

        }



        private void rbShowKLY_CheckedChanged(object sender, EventArgs e)
        {
            InitDataGridView();
            this.superGrid1.DataSource = null;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            InitDataGridView();
            this.superGrid1.DataSource = null;
        }

        private void btnQueryCKTJ_Click(object sender, EventArgs e)
        {
            showKJTJ = true;
            DataTable dt = QueryData();
            this.superGrid1.DataSource = dt;
        }

        private DataTable QueryData(string ieFlagType = "")
        {
            string company = cboxCompany.SelectedValue.ToString();
            DateTime inputDate_s = DateTime.MinValue;
            DateTime inputDate_e = DateTime.MinValue;
            if (stime.Checked)
            {
                inputDate_s = stime.Value.Date;
            }
            if (etime.Checked)
            {
                inputDate_e = etime.Value.Date;
            }
            string ieFlag = "";
            if (rbI.Checked)
            {
                ieFlag = "I";
            }
            else if (rbE.Checked)
            {
                ieFlag = "E";
            }

            // CheckKLYShow();
            return bll.QueryInputReportNew(company, inputDate_s, inputDate_e, ieFlag, ShowAL, showKJTJ, ieFlagType);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.superGrid1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "导出Excel (*.xls)|*.xls";
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.RestoreDirectory = true;
                //   saveFileDialog.CreatePrompt = true;
                saveFileDialog.Title = "导出文件保存路径";
                saveFileDialog.FileName = "统计_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    if (filePath.Length != 0)
                    {
                        labMessage.Text = "正在导出Excel";
                        Application.DoEvents();
                        ReportData rpdata = CreateReportData();
                        //   DataTable dt = QueryData("E");// (DataTable)this.superGrid1.DataSource; // Se convierte el DataSource 
                        Hashtable ht = CommonHelper.GetDataGridViewDisplayColumns(this.superGrid1);
                        ExcelHelper.ExportReportData(rpdata, filePath, ht, DateTime.Now.ToString("yyyy-MM-dd"));
                        labMessage.Text = "";
                        //  Print(filePath);
                        System.Diagnostics.Process.Start(filePath);
                        // MessageBox.Show("导出成功");
                    }
                }
            }
        }

        private ReportData CreateReportData()
        {
            ReportData rpdata = new ReportData();
            rpdata.CreateDate = DateTime.Now.ToString("yyyy-MM-dd");
            rpdata.DateSelect = (stime.Checked ? stime.Value.ToString("yyyy-MM-dd") : "") + " - "
                 + (etime.Checked ? etime.Value.ToString("yyyy-MM-dd") : "");
            if (rpdata.DateSelect == " - ")
            {
                rpdata.DateSelect = "";
            }
            rpdata.Company = cboxCompany.SelectedIndex > 0 ? cboxCompany.Text : "所有";
            if (rbI.Checked)
            {
                rpdata.I_Data = QueryData("I");
                rpdata.E_Data = null;
            }
            else if (rbE.Checked)
            {
                rpdata.I_Data = null;
                rpdata.E_Data = QueryData("E");
            }
            else
            {
                rpdata.I_Data = QueryData("I");
                rpdata.E_Data = QueryData("E");
            }
            return rpdata;
        }

        private void Print(string filePath)
        {
            //Workbook workbook = new Workbook();
            //workbook.ShowTabs = false;
            //workbook.LoadFromFile(filePath);

            //Worksheet sheet = workbook.Worksheets[0];
            //sheet.PageSetup.PrintArea = "A1:F39";
            //sheet.PageSetup.PrintTitleRows = "$2:$2";
            //sheet.PageSetup.FitToPagesWide = 1;
            //sheet.PageSetup.FitToPagesTall = 1;
            //sheet.PageSetup.Orientation = PageOrientationType.Portrait;
            //sheet.PageSetup.PaperSize = PaperSizeType.PaperA4;

            //PrintDialog dialog = new PrintDialog();

            //dialog.AllowPrintToFile = true;
            //dialog.AllowCurrentPage = true;
            //dialog.AllowSomePages = true;
            //dialog.AllowSelection = true;
            //dialog.UseEXDialog = true;
            //dialog.PrinterSettings.Duplex = Duplex.Simplex;
            //dialog.PrinterSettings.FromPage = 0;
            //dialog.PrinterSettings.ToPage = 8;
            //dialog.PrinterSettings.PrintRange = PrintRange.SomePages;
            //  workbook.PrintDialog = dialog;
            //   PrintDocument pd = workbook.PrintDocument;
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{ pd.Print(); }
        }
    }
}
