using BLL;
using Helpers;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LiHuo
{
    public partial class Input : Form
    {
        private readonly InputBLL bll = new InputBLL();
        private readonly UserBLL userBLL = new UserBLL();
        public Input()
        {
            InitializeComponent();
        }

        string _editVoyageNo = "";
        UserInfo editCompanyInfo;
        public Input(string editVoyageNo, bool isA,string companyId)
        {
            _editVoyageNo = editVoyageNo;
            editCompanyInfo = userBLL.GetUserInfoByCompanyId(companyId);
            InitializeComponent();
            if (isA)
            {
                rbA.Checked = true;
            }
            else
            {
                rbL.Checked = true;
            }
        }
        IList<PerType> pers = GlobalVariable.LoginUserInfo.UserPer;
        private void Input_Load(object sender, EventArgs e)
        {
            labVoyageNo.Text = "";
            labTitle.Text = GlobalVariable.LoginUserInfo.UserName + "(" + GlobalVariable.LoginUserInfo.CompanyName + ")";
            if (pers.Contains(PerType.Delete))
            {
                btnDelete.Show();
            }
            else
            {
                btnDelete.Hide();
            }
            InitDataGridView();
            LoadDefaultData();

        }

        private void LoadDefaultData()
        {
            if (!string.IsNullOrEmpty(_editVoyageNo))
            {
                this.Text = "查询修改（" + _editVoyageNo + "）";
                this.txtVoyageNo.Text = _editVoyageNo;
                this.txtVoyageNo.Enabled = false;
                GetData();
            }
        }

        private void InitDataGridView()
        {
            superGrid1.EnableHeadersVisualStyles = false;
            CommonHelper.AddColumn(this.superGrid1, "类别", "TradeType");
            CommonHelper.AddColumn(this.superGrid1, "流水号", "SNo");
            CommonHelper.AddColumn(this.superGrid1, "票数", "Ticket", false);
            CommonHelper.AddColumn(this.superGrid1, "件数", "Piece", false);
            CommonHelper.AddColumn(this.superGrid1, "重量", "Weight", false);
            CommonHelper.AddColumn(this.superGrid1, "价值", "Price", false);
            CommonHelper.AddColumn(this.superGrid1, "备注", "Remark", false);
            CommonHelper.AddHideColumn(this.superGrid1, "id", "id");
            CommonHelper.AddHideColumn(this.superGrid1, "TradeTypeValue", "TradeTypeValue");
            this.superGrid1.CellEnter += SuperGrid1_CellEnter;
            this.superGrid1.Rows.Add(new string[] { "A类", "", "", "", "", "", "", "", "A" });
            this.superGrid1.Rows.Add(new string[] { "B类", "", "", "", "", "", "", "", "B" });
            this.superGrid1.Rows.Add(new string[] { "C类", "", "", "", "", "", "", "", "C" });
            this.superGrid1.Rows.Add(new string[] { "普货", "", "", "", "", "", "", "", "D" });
            this.superGrid1.Rows.Add(new string[] { "合计", "", "", "", "", "", "", "", "" });
            this.superGrid1.Rows[0].Cells["Price"].ReadOnly = true;
            this.superGrid1.Rows[0].Cells["Price"].Style.BackColor = Color.FromArgb(211, 211, 211);
            this.superGrid1.Columns[1].DefaultCellStyle.BackColor = Color.FromArgb(211, 211, 211);
            this.superGrid1.Rows[4].ReadOnly = true;
            this.superGrid1.Rows[4].DefaultCellStyle.BackColor = Color.FromArgb(211, 211, 211);
        }

        private void SuperGrid1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;

            if (!dg.CurrentCell.ReadOnly)
            {
                this.superGrid1.BeginEdit(true);//将单元格设为编辑状态

            }
        }

        private void CalculateTotal()
        {
            int ticket = 0;
            int packno = 0;
            double weight = 0.00;
            decimal price = 0m;
            for (int i = 0; i < 4; i++)
            {
                ticket += StringHelper.SafeGetIntFromObj(this.superGrid1.Rows[i].Cells[2].Value);
                packno += StringHelper.SafeGetIntFromObj(this.superGrid1.Rows[i].Cells[3].Value);
                weight += StringHelper.SafeGetDoubleFromObj(this.superGrid1.Rows[i].Cells[4].Value);
                price += StringHelper.SafeGetDecimalFromObj(this.superGrid1.Rows[i].Cells[5].Value);
            }
            this.superGrid1.Rows[4].Cells[2].Value = ticket.ToString();
            this.superGrid1.Rows[4].Cells[3].Value = packno.ToString();
            this.superGrid1.Rows[4].Cells[4].Value = weight.ToString();
            this.superGrid1.Rows[4].Cells[5].Value = price.ToString();
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!pers.Contains(PerType.Delete))
            {
                MessageBox.Show("您没有删除的权限");
                return;
            }
            string voyageNo = txtVoyageNo.Text.Trim();
            if (voyageNo =="")
            {
                return;
            }
            if (MessageBox.Show("请确认是否要删除总运单号:" + voyageNo + "  的所有信息？?\r\n请操作很危险！将导致流水号不连续！！！","警告",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (MessageBox.Show("请再次确认是否要删除?\r\n请操作很危险！将导致流水号不连续！！！\r\n因此操作所造成的问题本公司概不负责，请知悉！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int rs = bll.DeleteData(voyageNo);
                    if (rs >0)
                    {
                        MessageBox.Show("删除成功！共删除了" + rs + "条信息");
                        ClearData(true);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
               
            }
          
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                ChangeConfirmButton(false);
                IList<Hashtable> paramsList = new List<Hashtable>();
                Hashtable ht = null;
                int id = 0;
                string sType = "";
                string voyageNo = txtVoyageNo.Text.Trim();
                int ticket = 0;
                int piece = 0;
                double weight = 0;
                for (int i = 0; i < 4; i++)
                {
                    ticket = StringHelper.SafeGetIntFromObj(this.superGrid1.Rows[i].Cells["Ticket"].Value);
                    piece = StringHelper.SafeGetIntFromObj(this.superGrid1.Rows[i].Cells["Piece"].Value);
                    weight = StringHelper.SafeGetDoubleFromObj(this.superGrid1.Rows[i].Cells["Weight"].Value);
                    if (ticket == 0 && piece == 0 && weight == 0)
                    {
                        continue;
                    }
                    id = StringHelper.SafeGetIntFromObj(this.superGrid1.Rows[i].Cells["id"].Value);
                    ht = new Hashtable();
                    ht["id"] = id;
                    ht["Ticket"] = ticket;
                    ht["Piece"] = piece;
                    ht["Weight"] = weight;
                    ht["Price"] = StringHelper.SafeGetDecimalFromObj(this.superGrid1.Rows[i].Cells["Price"].Value);
                    ht["Remark"] = this.superGrid1.Rows[i].Cells["Remark"].Value.ToString();
                    sType = GetTradeType(i);
                    ht["TradeType"] = sType;
                    
                    if (id <= 0)
                    {
                        if (editCompanyInfo != null)
                        {
                            ht["CompanyId"] = editCompanyInfo.CompanyId;
                            ht["CompanyName"] = editCompanyInfo.CompanyName;
                            ht["CompanyShortName"] = editCompanyInfo.CompanyShortName;
                        }
                        else
                        {
                            ht["CompanyId"] = GlobalVariable.LoginUserInfo.CompanyId;
                            ht["CompanyName"] = GlobalVariable.LoginUserInfo.CompanyName;
                            ht["CompanyShortName"] = GlobalVariable.LoginUserInfo.CompanyShortName;
                        }
                        ht["AddUserId"] = GlobalVariable.LoginUserInfo.id;
                        ht["AddUserName"] = GlobalVariable.LoginUserInfo.UserName;
                        ht["VoyageNo"] = voyageNo;
                        ht["A_L_TYPE"] = rbA.Checked ? "A" : "L";
                        ht["I_E_FLAG"] = rbI.Checked ? "I" : "E";
                        ht["InputDate"] = stime.Value;
                        ht["addIP"] = NetHelper.GetLocalIP();

                    }
                    else
                    {
                        ht["SNo"] = this.superGrid1.Rows[i].Cells["SNo"].Value.ToString();
                        ht["ModifyUserId"] = GlobalVariable.LoginUserInfo.id;
                        ht["ModifyUserName"] = GlobalVariable.LoginUserInfo.UserName;
                        ht["ModifyIp"] = NetHelper.GetLocalIP();
                        ht["Modifytime"] = DateTime.Now;
                    }
                    V1Info headInfo = bll.GetV1Info(voyageNo, sType, GlobalVariable.LoginUserInfo.CompanyId);
                    ht["Ticket_C"] = headInfo.Ticket;
                    ht["Piece_C"] = headInfo.PackNo;
                    ht["Weight_C"] = headInfo.Weight;
                    ht["Price_C"] = 0;
                    paramsList.Add(ht);
                }
                IList<string> newSNOList = new List<string>();

                int rs = bll.SaveInputData(paramsList, ref newSNOList);
                if (rs > 0)
                {
                    if (!string.IsNullOrEmpty(_editVoyageNo))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }

                    ShowNewSNO(newSNOList);

                    MessageBox.Show("保存成功，共更新" + rs + "笔数据");
                    //  ClearData(true);
                    txtVoyageNo.Text = "";
                    txtVoyageNo.Focus();
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
        }

        private void ShowNewSNO(IList<string> newSnList)
        {
            string[] snlist = new string[2];
            string stype, sno;
            for (int i = 0; i < newSnList.Count; i++)
            {
                snlist = newSnList[i].Split('_');
                stype = snlist[0];
                sno = snlist[1];
                foreach (DataGridViewRow dr in this.superGrid1.Rows)
                {
                    if (dr.Cells["TradeTypeValue"].Value.ToString() == stype)
                    {
                        dr.Cells["SNo"].Value = sno;
                        break;
                    }
                }

            }
        }

        private string GetTradeType(int index)
        {
            string sType = "";
            switch (index)
            {
                case 0:
                    sType = "A";
                    break;
                case 1:
                    sType = "B";
                    break;
                case 2:
                    sType = "C";
                    break;
                case 3:
                    sType = "D";
                    break;
                default:
                    break;
            }
            return sType;
        }

        private void txtVoyageNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetData();
            }
        }


        private bool CheckVoyageLength()
        {
            int len = txtVoyageNo.Text.Trim().Length;
            if (rbA.Checked)
            {
                if (len != 11)
                {
                    MessageBox.Show("总运单长度错误！空运总运单长度必须为11位");
                    return false;
                }
            }
            else if (rbL.Checked)
            {
                if (len != 13)
                {
                    MessageBox.Show("总运单长度错误！陆运总运单长度必须为13位");
                    return false;
                }
            }
            return true;
        }

        private bool CheckData()
        {
            string voyageNo = txtVoyageNo.Text.Trim();
            if (voyageNo == "")
            {
                MessageBox.Show("总运单号不能为空");
                txtVoyageNo.Focus();
                return false;
            }

            if (!rbI.Checked && !rbE.Checked)
            {
                MessageBox.Show("请选择进出口选项");
                return false;
            }

            if (!rbA.Checked && !rbL.Checked)
            {
                MessageBox.Show("请选择空陆运选项");
                return false;
            }

            bool isPerPass = CheckActionPer(voyageNo);
          //  CheckButtonEnable(hasValue);
            if (!isPerPass)
            {
            
                return false;
            }

            if (!CheckVoyageLength())
            {

                txtVoyageNo.Focus();
                return false;
            }



            string val = "";
            int itemp = 0;
            double idouble = 0;
            foreach (DataGridViewRow item in this.superGrid1.Rows)
            {
                NumState state = CheckItemNumState(item);
                if (state == NumState.TicketLagerThenPACK)
                {
                    MessageBox.Show("票数必须小于等于件数");
                    item.Cells["Ticket"].Style.BackColor = Color.Red;
                    item.Cells["Piece"].Style.BackColor = Color.Red;
                    return false;
                }
                else
                {
                    item.Cells["Ticket"].Style.BackColor = Color.White;
                    item.Cells["Piece"].Style.BackColor = Color.White;
                }

                if (state == NumState.ValueError)
                {
                    MessageBox.Show("数值输入错误，请检查！");
                    return false;
                }

                if (state == NumState.HasOneZero)
                {
                    MessageBox.Show("票数，件数，重量有某一项为0，禁止保存！");
                    return false;
                }

                for (int i = 2; i < 4; i++)
                {
                    val = item.Cells[i].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(val))
                    {
                        if (!int.TryParse(val, out itemp) || itemp < 0)
                        {
                            MessageBox.Show("输入项有非法字符");
                            return false;
                        }

                    }
                }

                for (int i = 4; i < 6; i++)
                {
                    val = item.Cells[i].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(val))
                    {
                        if (!double.TryParse(val, out idouble) || idouble < 0)
                        {
                            MessageBox.Show("输入项有非法字符");
                            return false;
                        }

                    }
                }
            }
            return true;
        }


        private bool CheckActionPer(string voyageNo)
        {
            bool hasValue = bll.CheckDataExists(voyageNo);
            string company = bll.GetTradeCode(voyageNo);
            if (hasValue)
            {
                if (pers.Contains(PerType.EditALL))
                {
                    ChangeConfirmButton(true);
                    return true;
                }
                if (pers.Contains(PerType.EditCompany) && GlobalVariable.LoginUserInfo.CompanyId == company)
                {
                    ChangeConfirmButton(true);
                    return true;
                }
            }
            else
            {
                if (pers.Contains(PerType.Add))
                {
                    ChangeConfirmButton(true);
                    return true;
                }
            }
            MessageBox.Show("您的操作权限不足，没有保存的权限");
            ChangeConfirmButton(false);
            txtVoyageNo.Focus();
            return false;
        }



        private NumState CheckItemNumState(DataGridViewRow row)
        {
            int ticket = StringHelper.SafeGetIntFromObj(row.Cells["Ticket"].Value);
            int piece = StringHelper.SafeGetIntFromObj(row.Cells["Piece"].Value);
            double weight = StringHelper.SafeGetDoubleFromObj(row.Cells["Weight"].Value);
            if (ticket < 0 || piece < 0 || weight < 0)
            {
                return NumState.ValueError;
            }
            if (ticket > piece)
            {
                return NumState.TicketLagerThenPACK;
            }

            if (ticket == 0 && piece == 0 && weight == 0)
            {
                return NumState.ALLZero;
            }
            else if (ticket == 0 || piece == 0 || weight == 0)
            {
                return NumState.HasOneZero;
            }

            return NumState.OK;
        }

        private void ClearData(bool isFull)
        {
            int length = isFull ? this.superGrid1.ColumnCount - 1 : this.superGrid1.ColumnCount - 2;
            foreach (DataGridViewRow item in this.superGrid1.Rows)
            {
                for (int i = 1; i < length; i++)
                {
                    item.Cells[i].Value = "";
                }
            }
        }

        private void GetData()
        {

            string voyageNo = txtVoyageNo.Text.Trim();

            if (string.IsNullOrEmpty(voyageNo))
            {
                return;
            }

            ClearData(true);
            if (!CheckVoyageLength())
            {
                return;
            }

            if (!CheckActionPer(voyageNo))
            {
                return;
            }



           
            string tradeId = (GlobalVariable.LoginUserInfo.PermissonLevel == "1"
                || GlobalVariable.LoginUserInfo.PermissonLevel == "2") ? GlobalVariable.LoginUserInfo.CompanyId : "";
            DataTable dt = bll.GetDataByVoyAgeNo(voyageNo, tradeId);
            bool hasValue = (dt != null && dt.Rows.Count > 0);
            
            if (hasValue)
            {
                labVoyageNo.Text = "已有总运单：" + voyageNo;
                if (dt.Rows[0]["A_L_TYPE"].ToString() == "A")
                {
                    rbA.Checked = true;
                }
                else
                {
                    rbL.Checked = true;
                }

                if (dt.Rows[0]["I_E_FLAG"].ToString() == "I")
                {
                    rbI.Checked = true;
                }
                else
                {
                    rbE.Checked = true;
                }


                string sType = "";
                for (int i = 0; i < 4; i++)
                {
                    sType = GetTradeType(i);

                    foreach (DataRow drData in dt.Rows)
                    {
                        if (drData["TradeType"].ToString().Equals(sType, StringComparison.CurrentCultureIgnoreCase))
                        {
                            DataGridViewRow dr = this.superGrid1.Rows[i];
                            dr.Cells["SNo"].Value = drData["SNo"].ToString();
                            dr.Cells["Ticket"].Value = drData["Ticket"].ToString();
                            dr.Cells["Piece"].Value = drData["Piece"].ToString();
                            dr.Cells["Weight"].Value = drData["Weight"].ToString();
                            dr.Cells["Price"].Value = drData["Price"].ToString();
                            dr.Cells["Remark"].Value = drData["Remark"].ToString();
                            dr.Cells["id"].Value = drData["id"].ToString();
                            break;
                        }
                    }
                    //DataRow[] drData = dt.Select("TradeType = '" + sType + "'");
                    //if (drData != null && drData.Length > 0)
                    //{

                    //}
                }
                CalculateTotal();

            }
            else
            {
                labVoyageNo.Text = "新总运单：" + voyageNo;
                for (int i = 0; i < 5; i++)
                {
                    DataGridViewRow dr = this.superGrid1.Rows[i];
                    dr.Cells["Ticket"].Value = "0";
                    dr.Cells["Piece"].Value = "0";
                    dr.Cells["Weight"].Value = "0";
                    dr.Cells["Price"].Value = "0";
                }
                this.superGrid1.Rows[0].Cells["Price"].Value = "";
            }

        }

        //private void CheckButtonEnable(bool hasValue)
        //{
        //    switch (GlobalVariable.LoginUserInfo.PermissonLevel)
        //    {
        //        case "1":
        //            if (hasValue)
        //            {
        //                ChangeConfirmButton(false);
        //            }
        //            else
        //            {
        //                ChangeConfirmButton(true);
        //            }
        //            break;
        //        case "3":
        //            if (hasValue)
        //            {
        //                ChangeConfirmButton(true);
        //            }
        //            else
        //            {
        //                ChangeConfirmButton(false);
        //            }
        //            break;
        //        default:
        //            break;
        //    }

        //}

        private void superGrid1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            this.superGrid1.Rows[e.RowIndex].ErrorText = "";
            string val = "";
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                int newInteger = 0;
                val = e.FormattedValue.ToString().Trim();
                if (!string.IsNullOrEmpty(val) && (!int.TryParse(val, out newInteger) || newInteger < 0))
                {
                    e.Cancel = true;
                    superGrid1.Rows[e.RowIndex].ErrorText = "数字格式错误，请重新输入。";
                    MessageBox.Show("数字格式错误，请重新输入。");
                    return;
                }


            }
            else if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                double newDouble = 0.00f;
                val = e.FormattedValue.ToString().Trim();
                if (!string.IsNullOrEmpty(val) && (!double.TryParse(val, out newDouble) || newDouble < 0.00))
                {
                    e.Cancel = true;
                    superGrid1.Rows[e.RowIndex].ErrorText = "数字格式错误，请重新输入";
                    MessageBox.Show("数字格式错误，请重新输入。");
                    return;
                }
            }
        }

        private void ChangeConfirmButton(bool enable)
        {
            if (enable)
            {
                btnConfirm.BackColor = Color.FromArgb(128, 128, 255);
                btnConfirm.Enabled = true;
            }
            else
            {
                btnConfirm.BackColor = Color.FromArgb(220, 220, 220);
                btnConfirm.Enabled = false;
            }
        }

        private void superGrid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotal();
        }

        private void rbA_CheckedChanged(object sender, EventArgs e)
        {
            ChangeVoyageLength();
            CheckVoyageEnable();
        }

        private void rbL_CheckedChanged(object sender, EventArgs e)
        {
            ChangeVoyageLength();
            CheckVoyageEnable();
        }

        private void ChangeVoyageLength()
        {
            if (rbA.Checked)
            {
                this.txtVoyageNo.MaxLength = 11;
                string txt = this.txtVoyageNo.Text.Trim();
                if (txt.Length > 11)
                {
                    this.txtVoyageNo.Text = txt.Substring(0, 11);
                }
            }
            else if (rbL.Checked)
            {
                this.txtVoyageNo.MaxLength = 13;
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckVoyageEnable()
        {
            if ((rbI.Checked || rbE.Checked) && (rbA.Checked || rbL.Checked))
            {
                txtVoyageNo.Enabled = true;
            }
            else
            {
                txtVoyageNo.Enabled = false;
            }
        }

        private void rbE_CheckedChanged(object sender, EventArgs e)
        {
            CheckVoyageEnable();
        }

        private void rbI_CheckedChanged(object sender, EventArgs e)
        {
            CheckVoyageEnable();
        }
    }

    public enum NumState
    {
        OK,
        TicketLagerThenPACK,
        ALLZero,
        HasOneZero,
        ValueError
    }


}
