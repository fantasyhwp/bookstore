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
            
            int Userid = Convert.ToInt32(textBoxuserid.Text.Trim());
            string Password = textBoxpassword.Text.Trim();
            if (Userid == 1111 && Password == "henrybrown")
            {
                FormEmployees formEmployees = new FormEmployees();
                this.Hide();
                formEmployees.ShowDialog();
            }
            else if (Userid == 2222 && Password == "thomasmoore")
            {
                Sales_Manager sales_Manager = new Sales_Manager();
                this.Hide();
                sales_Manager.ShowDialog();
            }
            else if (Userid == 3333 && Password == "peterwang")
            {
                InventoryControllerForm inventoryControllerForm = new InventoryControllerForm();
                this.Hide();
                inventoryControllerForm.ShowDialog();
            }
            else if (Userid == 4444 && Password == "jennifer")
            {
                OrderManagement orderManagement = new OrderManagement();
                this.Hide();
                orderManagement.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong User or Password");
            }
        }
    }
}
