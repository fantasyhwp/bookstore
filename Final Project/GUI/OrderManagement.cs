using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project.Models;


namespace Final_Project.GUI
{
    public partial class OrderManagement : Form
    {
        HiTechDBEntities dBEntities = new HiTechDBEntities();
        public OrderManagement()
        {
            InitializeComponent();
        }

        private void buttonlistall_Click(object sender, EventArgs e)
        {
            var listOrder = (from order in dBEntities.Orders select order).ToList<Order>();
            dataGridVieworder.DataSource = listOrder;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.OrderId = Convert.ToInt32(textBoxOrderid.Text.Trim());
            order.OrderDate = Convert.ToDateTime(maskedTextBoxorderdate.Text);
            order.CustomerId = Convert.ToInt32(textBoxCustomerID.Text.Trim());
            order.EmployeeId = Convert.ToInt32(textBoxEmployeeID.Text.Trim());
            order.ShippingDate = Convert.ToDateTime(maskedTextBoxshipdate.Text);
            order.RequiredDate = Convert.ToDateTime(maskedTextBoxrequiredate.Text);
            order.OrderType = textBoxordertype.Text.Trim();
            order.OrderStatus = textBoxOrderStatus.Text.Trim();
            dBEntities.Orders.Add(order);
            dBEntities.SaveChanges();
            MessageBox.Show("Orders saved successfully", "successfully");

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            dBEntities.Orders.Attach(order);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            dBEntities.Orders.Remove(order);
        }

        private void buttonorderlinelist_Click(object sender, EventArgs e)
        {
            var listOrderline = (from orderLine in dBEntities.OrderLines select orderLine).ToList<OrderLine>();
            dataGridViewlistorderline.DataSource = listOrderline;
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you really want to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
    }
}
