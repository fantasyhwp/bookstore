using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.GUI
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void uToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            this.Hide();
            login.ShowDialog();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEmployees emp = new FormEmployees();
            this.Hide();
            emp.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void salesManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales_Manager sales_Manager = new Sales_Manager();
            this.Hide();
            sales_Manager.ShowDialog();

        }

        private void bookToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            InventoryControllerForm inventoryControllerForm = new InventoryControllerForm();
            this.Hide();
            inventoryControllerForm.ShowDialog();
        }
    }
}
