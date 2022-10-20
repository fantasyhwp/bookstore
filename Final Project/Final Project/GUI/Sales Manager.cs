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
    public partial class Sales_Manager : Form
    {
        SqlDataAdapter daCustomer;
        DataSet dsCustomer;
        DataTable dtCustomer;
        SqlCommandBuilder sqlBuilder;
        Customer aCustomer = new Customer();
        public Sales_Manager()
        {
            InitializeComponent();
        }

        private void menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenuForm mainMenuForm = new MainMenuForm();
            mainMenuForm.ShowDialog();
        }

        private void buttonlistallcustomers_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            dataGridViewlistcustomers.DataSource = customer.CustomersList();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DataRow dr = dtCustomer.NewRow();
            dr["CustomerId"] = textBoxcustomerid.Text.Trim();
            dr["CustomerName"] = textBoxcustomername.Text.Trim();
            dr["StreetAddress"] = textBoxstreeaddress.Text.Trim();
            dr["Province"] = textBoxprovince.Text.Trim();
            dr["City"] = textBoxcity.Text.Trim();
            dr["PostalCode"] = textBoxpostalcode.Text.Trim();
            dr["CreditLimit"] = Convert.ToInt32(textBoxcreditlimit.Text.Trim());
            dr["PhoneNumber"] = textBoxphonenumber.Text.Trim();
            dtCustomer.Rows.Add(dr);
            MessageBox.Show(dr.RowState.ToString());
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string customerID = textBoxcustomerid.Text.Trim();
            DataRow drCustomer = dtCustomer.Rows.Find(customerID);
            drCustomer["CustomerId"] = textBoxcustomerid.Text.Trim();
            drCustomer["CustomerName"] = textBoxcustomername.Text.Trim();
            drCustomer["StreetAddress"] = textBoxstreeaddress.Text.Trim();
            drCustomer["Province"] = textBoxprovince.Text.Trim();
            drCustomer["City"] = textBoxcity.Text.Trim();
            drCustomer["PostalCode"] = textBoxpostalcode.Text.Trim();
            drCustomer["CreditLimit"] = textBoxcreditlimit.Text.Trim();
            drCustomer["PhoneNumber"] = textBoxphonenumber.Text.Trim();
            MessageBox.Show(drCustomer.RowState.ToString());
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string searchId = textBoxcustomerid.Text.ToString();
            DataRow drCustomer = dtCustomer.Rows.Find(searchId);
            drCustomer.Delete();
            MessageBox.Show(drCustomer.RowState.ToString());
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchID = textBoxsearch.Text.ToString();
            DataRow drCustomer = dtCustomer.Rows.Find(searchID);
            if (drCustomer != null)
            {
                textBoxcustomerid.Text = drCustomer["CustomerId"].ToString();
                textBoxcustomername.Text= drCustomer["CustomerName"].ToString();
                textBoxstreeaddress.Text= drCustomer["StreetAddress"].ToString();
                textBoxprovince.Text= drCustomer["Province"].ToString();
                textBoxcity.Text= drCustomer["City"].ToString();
                textBoxpostalcode.Text= drCustomer["PostalCode"].ToString();
                textBoxcreditlimit.Text= drCustomer["CreditLimit"].ToString();
                textBoxphonenumber.Text= drCustomer["PhoneNumber"].ToString();
            }
            else
            {
                MessageBox.Show("Customer not found!", "Invalid Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sales_Manager_Load(object sender, EventArgs e)
        {
            dsCustomer = new DataSet("CustomerDS");
            dtCustomer = new DataTable("Customer");

            dsCustomer.Tables.Add(dtCustomer);

            dtCustomer.Columns.Add("CustomerId", typeof(string));
            dtCustomer.Columns.Add("CustomerName", typeof(string));
            dtCustomer.Columns.Add("StreetAddress", typeof(string));
            dtCustomer.Columns.Add("Province", typeof(string));
            dtCustomer.Columns.Add("City", typeof(string));
            dtCustomer.Columns.Add("PostalCode", typeof(string));
            dtCustomer.Columns.Add("CreditLimit", typeof(Int32));
            dtCustomer.Columns.Add("PhoneNumber", typeof(string));

            dtCustomer.PrimaryKey = new DataColumn[] { dtCustomer.Columns["CustomerId"] };

            daCustomer = new SqlDataAdapter("SELECT * FROM Customer", UtillityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(daCustomer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            daCustomer.Update(dsCustomer.Tables["Customer"]);
            MessageBox.Show("Database has been updated sucessfully.", "Confirmation");
        }
    }
    
}
