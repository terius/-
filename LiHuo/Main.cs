using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
namespace LiHuo
{
    public partial class Main : Form
    {
      
        private readonly UserBLL userBLL = new UserBLL();
        public Main()
        {
          //  GlobalVariable.LoginUserInfo = userBLL.GetUserInfoById(2);
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            labTitle.Text = "欢迎 " + GlobalVariable.LoginUserInfo.UserName + " 用户登录";
            if (GlobalVariable.LoginUserInfo.PermissonLevel =="4")
            {
                btnUserManager.Visible = true;
            }
            else
            {
                btnUserManager.Visible = false;
             
            }
            btnReport.Visible = false;
            if (GlobalVariable.LoginUserInfo.PermissonLevel == "3" || GlobalVariable.LoginUserInfo.PermissonLevel == "4")
            {
                btnReport.Visible = true;
            }

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
            // Application.Exit();
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            UserManager frm = new UserManager();
            frm.ShowDialog();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            Input frm = new Input();
            frm.ShowDialog();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            InputQuery frm = new InputQuery();
            frm.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            InputReport frm = new InputReport();
            frm.ShowDialog();
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            ChangePassword frm = new ChangePassword();
            frm.ShowDialog();
        }
    }
}
