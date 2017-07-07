using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LiHuo
{
    public partial class ChangePassword : Form
    {
        private readonly UserBLL userBLL = new UserBLL();
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newPwd = txtNewPwd.Text.Trim();
            if (newPwd =="")
            {
                MessageBox.Show("新密码不能为空");
                return;
            }
            if (MessageBox.Show("是否修改密码？","密码修改", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (userBLL.ChangePassword(GlobalVariable.LoginUserInfo.id, newPwd))
                {
                    MessageBox.Show("密码修改成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码修改失败");
                }
            }
        }
    }
}
