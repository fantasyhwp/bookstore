using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project.BLL;
using Final_Project.DAL;
using System.Data.SqlClient;

namespace Final_Project.GUI
{
    public partial class LoginForm : Form
    {
        public static string  userid= null;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            User aUser = new User();
            int tempUserid = Convert.ToInt32(textBoxuserid.Text.Trim());
            string tempPassword = textBoxpassword.Text.Trim();
            if (aUser.VerfyLogIn(tempUserid,tempPassword))
            {
                FormEmployees formEmployees = new FormEmployees();
                this.Hide();
                formEmployees.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong User or Password");
            }
        }
    }
}
