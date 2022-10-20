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
            dr["StreetName"] = textBoxstreename.Text.Trim();
            dr["Province"] = textBoxprovince.Text.Trim();
            dr["City"] = textBoxcity.Text.Trim();
            dr["PostalCode"] = textBoxpostalcode.Text.Trim();
            dr["CreditLimit"] = Convert.ToInt32(textBoxcreditlimit.Text.Trim());
            dr["ContactEmail"] = textBoxemail.Text.Trim();
            dr["ContactName"] = textBoxcontactname.Text.Trim();
            dtCustomer.Rows.Add(dr);
            MessageBox.Show(dr.RowState.ToString());
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string customerID = textBoxcustomerid.Text.Trim();
            DataRow drCustomer = dtCustomer.Rows.Find(customerID);
            drCustomer["CustomerId"] = textBoxcustomerid.Text.Trim();
            drCustomer["CustomerName"] = textBoxcustomername.Text.Trim();
            drCustomer["StreetName"] = textBoxstreename.Text.Trim();
            drCustomer["Province"] = textBoxprovince.Text.Trim();
            drCustomer["City"] = textBoxcity.Text.Trim();
            drCustomer["PostalCode"] = textBoxpostalcode.Text.Trim();
            drCustomer["CreditLimit"] = textBoxcreditlimit.Text.Trim();
            drCustomer["ContactEmail"] = textBoxemail.Text.Trim();
            drCustomer["ContactName"] = textBoxcontactname.Text.Trim();
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
                textBoxstreename.Text= drCustomer["StreetName"].ToString();
                textBoxprovince.Text= drCustomer["Province"].ToString();
                textBoxcity.Text= drCustomer["City"].ToString();
                textBoxpostalcode.Text= drCustomer["PostalCode"].ToString();
                textBoxcreditlimit.Text= drCustomer["CreditLimit"].ToString();
                textBoxemail.Text= drCustomer["ContactEmail"].ToString();
                textBoxcontactname.Text = drCustomer["ContactName"].ToString();
            }
            else
            {
                MessageBox.Show("Customer not found!", "Invalid Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sales_Manager_Load(object sender, EventArgs e)
        {
            dsCustomer = new DataSet("CustomerDS");
            dtCustomer = new DataTable("Customers");
            dsCustomer.Tables.Add(dtCustomer);
            dtCustomer.Columns.Add("CustomerId", typeof(string));
            dtCustomer.Columns.Add("CustomerName", typeof(string));
            dtCustomer.Columns.Add("StreetName", typeof(string));
            dtCustomer.Columns.Add("Province", typeof(string));
            dtCustomer.Columns.Add("City", typeof(string));
            dtCustomer.Columns.Add("PostalCode", typeof(string));
            dtCustomer.Columns.Add("CreditLimit", typeof(Int32));
            dtCustomer.Columns.Add("ContactEmail", typeof(string));
            dtCustomer.Columns.Add("ContactName", typeof(string));
            dtCustomer.PrimaryKey = new DataColumn[] { dtCustomer.Columns["CustomerId"] };
            daCustomer = new SqlDataAdapter("SELECT * FROM Customers", UtillityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(daCustomer);
            daCustomer.Fill(dsCustomer.Tables["Customers"]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            daCustomer.Update(dsCustomer.Tables["Customers"]);
            MessageBox.Show("Database has been updated sucessfully.", "Confirmation");
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
