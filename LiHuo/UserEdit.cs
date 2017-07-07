using BLL;
using Model;
using System;
using System.Windows.Forms;

namespace LiHuo
{
    public partial class UserEdit : Form
    {
        private int _userId;
        private readonly UserBLL userBLL = new UserBLL();
        private string title;
        public UserEdit(int id = 0)
        {
            InitializeComponent();
            this._userId = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserEdit_Load(object sender, EventArgs e)
        {
            if (this._userId > 0)
            {
                this.title = "编辑";
                var info = userBLL.GetUserInfoById(_userId);
                if (info != null)
                {
                    txtCompanyId.Text = info.CompanyId;
                    txtCompanyName.Text = info.CompanyName;
                    txtCompanyShortName.Text = info.CompanyShortName;
                    txtLoginName.Text = info.LoginName;
                    tbUserName.Text = info.UserName;
                    switch (info.PermissonLevel)
                    {
                        case "1":
                            level1.Checked = true;
                            break;
                        case "2":
                            level2.Checked = true;
                            break;
                        case "3":
                            level3.Checked = true;
                            break;
                        case "4":
                            level4.Checked = true;
                            break;
                        default:
                            level1.Checked = true;
                            break;
                    }
                    rbIsActive.Checked = info.IsActive;
                

                }
            }
            else
            {
                this.title = "新增";
            }
            this.Text = this.title + "用户";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UserInfo info = new UserInfo();
            info.id = _userId;
            if (info.id >0)
            {
                info.ModifyUserId = GlobalVariable.LoginUserInfo.id; 
            }
            else
            {
                info.AddUserId = GlobalVariable.LoginUserInfo.id;
            }
            info.CompanyName = txtCompanyName.Text.Trim();
            info.CompanyId = txtCompanyId.Text.Trim();
            info.CompanyShortName = txtCompanyShortName.Text.Trim();
         
            info.UserName = tbUserName.Text.Trim();
            info.Password = tbPWD.Text.Trim();
            info.LoginName = txtLoginName.Text.Trim();
            if (level1.Checked)
            {
                info.PermissonLevel = "1";
            }
            else if (level2.Checked)
            {
                info.PermissonLevel = "2";
            }
            else if (level3.Checked)
            {
                info.PermissonLevel = "3";
            }
            else if (level4.Checked)
            {
                info.PermissonLevel = "4";
            }
       
            info.IsActive = rbIsActive.Checked ? true : false;
            if (CheckInput(info))
            {
                if (userBLL.SaveUserInfo(info))
                {
                    MessageBox.Show(this.title + "用户成功");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this.title + "用户失败");
                }
            }
        }

        private bool CheckInput(UserInfo info)
        {
            if (string.IsNullOrEmpty(info.LoginName))
            {
                MessageBox.Show("登录名不能为空");
                txtLoginName.Focus();
                txtLoginName.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(info.UserName))
            {
                MessageBox.Show("用户名不能为空");
                tbUserName.Focus();
                tbUserName.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(info.CompanyId))
            {
                MessageBox.Show("公司id不能为空");
                txtCompanyId.Focus();
                txtCompanyId.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(info.CompanyName))
            {
                MessageBox.Show("公司名称不能为空");
                txtCompanyName.Focus();
                txtCompanyName.SelectAll();
                return false;
            }
           

            if (info.id <= 0 && string.IsNullOrEmpty(info.Password))
            {
                MessageBox.Show("新增用户密码不能为空");
                tbPWD.Focus();
                tbPWD.SelectAll();
                return false;
            }

            if (userBLL.CheckUserNameExist(info.LoginName,info.id))
            {
                MessageBox.Show("登录名不能重复");
                txtLoginName.Focus();
                txtLoginName.SelectAll();
                return false;
            }

         
            return true;
        }

       
    }
}
