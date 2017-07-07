using BLL;
using Model;
using System;
using System.Windows.Forms;

namespace LiHuo
{
    public partial class QueryEdit : Form
    {
        private int _userId;
        private readonly UserBLL userBLL = new UserBLL();
        private string title;
        public QueryEdit(int id = 0)
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
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private bool CheckInput(UserInfo info)
        {
            

         
            return true;
        }

       
    }
}
