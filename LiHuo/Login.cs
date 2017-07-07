using BLL;
using DAL;
using Helpers;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LiHuo
{
    public partial class Login : Form
    {
        private readonly COMMON common = new COMMON();
        private readonly UserBLL userBLL = new UserBLL();
        public Login()
        {
            GlobalVariable.LoginUserInfo = null;
            InitializeComponent();
            label4.Text = "V" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
            // Application.Exit();
        }

        private void login()
        {

            string userName = tbUser.Text.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            string pwd = tbPWD.Text.Trim();
            if (string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            UserInfo loginInfo = userBLL.GetUserInfoByLoginName(userName);
            if (loginInfo != null)
            {
                if (!loginInfo.IsActive)
                {
                    MessageBox.Show("该用户已禁用，无法登录！");
                    return;
                }
                string enPwd = loginInfo.Password;
                pwd = StringHelper.Sha256(pwd);
                if (pwd.Equals(enPwd))
                {
                    GlobalVariable.LoginUserInfo = loginInfo;
                    GlobalVariable.LoginUserInfo.LastLoginIp = userBLL.UpdateLoginIp(loginInfo.id);
                    this.Hide();
                    Main mainForm = new Main();
                    mainForm.Show();

                }
                else
                {
                    MessageBox.Show("密码错误");
                }
            }
            else
            {
                MessageBox.Show("用户名错误");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();


        }

        private void tbPWD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
    }
}
