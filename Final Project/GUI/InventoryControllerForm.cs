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
    public partial class InventoryControllerForm : Form
    {
        Book book = new Book();
        Author author = new Author();
        Category category = new Category();
        Publisher Publisher = new Publisher();
        SqlDataAdapter daBook,daAuthor, daCategory, daPublisher;
        DataSet dsBook,dsAuthor, dsCategory, dsPublisher;
        DataTable dtBook, dtAuthor, dtCategory, dtPublisher;
        SqlCommandBuilder sqlBuilder;
        public InventoryControllerForm()
        {
            InitializeComponent();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonlistbook_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            dataGridViewbook.DataSource = book.BookList();
        }

        private void buttonsearchbook_Click(object sender, EventArgs e)
        {
            int searchisbn = Convert.ToInt32(textBoxisbn.Text.Trim());
            DataRow drBook = dtBook.Rows.Find(searchisbn);
            if (drBook != null)
            {
                textBoxtitle.Text = drBook["BookTitle"].ToString();
                textBoxisbn.Text = drBook["Isbn"].ToString();
                textBoxPublisher.Text = drBook["PublisherId"].ToString();
                textBoxauthor.Text = drBook["AuthorId"].ToString();
                textBoxcategory.Text = drBook["CategoryId"].ToString();
                textBoxqoh.Text = drBook["Qoh"].ToString();
                textBoxprice.Text = drBook["UnitPrice"].ToString();
            }
            else
            {
                MessageBox.Show("Books not found!", "Invalid Book ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonlistSuppliers_Click(object sender, EventArgs e)
        {
            Publisher publisher = new Publisher();
            dataGridViewsuppliser.DataSource = publisher.SuppliersList();
        }

        private void buttonaddauthor_Click(object sender, EventArgs e)
        {
            DataRow dr = dtAuthor.NewRow();
            dr["AuthorId"] = Convert.ToInt32(textBoxauthorid.Text.Trim());
            dr["AuthorName"] = textBoxauthorname.Text.Trim();
            dtAuthor.Rows.Add(dr);
            MessageBox.Show(dr.RowState.ToString());
        }

        private void buttonAddbook_Click(object sender, EventArgs e)
        {
            DataRow dr = dtBook.NewRow();
            dr["BookTitle"] = textBoxtitle.Text.Trim();
            dr["Isbn"] = textBoxisbn.Text.Trim();
            dr["PublisherId"] = Convert.ToInt32(textBoxPublisher.Text.Trim());
            dr["AuthorId"] = Convert.ToInt32(textBoxauthor.Text.Trim());
            dr["CategoryId"] = Convert.ToInt32(textBoxcategory.Text.Trim());
            dr["Qoh"] =textBoxqoh.Text.Trim();
            dr["UnitPrice"] = Convert.ToInt32(textBoxprice.Text.Trim());
            dtBook.Rows.Add(dr);
            MessageBox.Show(dr.RowState.ToString());
        }

        private void buttondeleteauthor_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxauthorid.Text.Trim());
            DataRow drAuthor = dtAuthor.Rows.Find(searchId);
            drAuthor.Delete();
            MessageBox.Show(drAuthor.RowState.ToString());
        }

        private void buttonupdateauthor_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxauthorid.Text.Trim());
            DataRow drAuthor = dtAuthor.Rows.Find(searchId);
            drAuthor["AuthorId"] = Convert.ToInt32(textBoxauthorid.Text.Trim());
            drAuthor["AuthorName"] = textBoxauthorname.Text.Trim();
            MessageBox.Show(drAuthor.RowState.ToString());
        }

        private void buttonsearchauthor_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxauthorid.Text.Trim());
            DataRow drAuthor = dtAuthor.Rows.Find(searchId);
            if (drAuthor != null)
            {
                textBoxauthorid.Text = drAuthor["AuthorId"].ToString();
                textBoxauthorname.Text = drAuthor["AuthorName"].ToString();
               
            }
            else
            {
                MessageBox.Show("Author not found!", "Invalid Author ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonupdatedatabseauthor_Click(object sender, EventArgs e)
        {
            daAuthor.Update(dsAuthor.Tables["Authors"]);
            MessageBox.Show("Database has been updated sucessfully.", "Confirmation");
        }

        private void buttonaddCategory_Click(object sender, EventArgs e)
        {
            DataRow dr = dtCategory.NewRow();
            dr["CategoryId"] = Convert.ToInt32(textBoxCategoryid.Text.Trim());
            dr["CategoryName"] = textBoxCategoryname.Text.Trim();
            dtCategory.Rows.Add(dr);
            MessageBox.Show(dr.RowState.ToString());
        }

        private void buttondeleteCategory_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxCategoryid.Text.Trim());
            DataRow drCategory = dtCategory.Rows.Find(searchId);
            drCategory.Delete();
            MessageBox.Show(drCategory.RowState.ToString());
        }

        private void buttonupdateCategory_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxCategoryid.Text.Trim());
            DataRow drCategory = dtCategory.Rows.Find(searchId);
            drCategory["CategoryId"] = Convert.ToInt32(textBoxCategoryid.Text.Trim());
            drCategory["CategoryName"] = textBoxCategoryname.Text.Trim();
            MessageBox.Show(drCategory.RowState.ToString());
        }

        private void buttondeleteSuppliers_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxPublisherid.Text.Trim());
            DataRow drPublisher = dtPublisher.Rows.Find(searchId);
            drPublisher.Delete();
            MessageBox.Show(drPublisher.RowState.ToString());
        }

        private void buttonupdateSuppliers_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxPublisherid.Text.Trim());
            DataRow drPublisher = dtPublisher.Rows.Find(searchId);
            drPublisher["PublisherId"] = Convert.ToInt32(textBoxPublisherid.Text.Trim());
            drPublisher["PublisherName"] = textBoxPublishername.Text.Trim();
            MessageBox.Show(drPublisher.RowState.ToString());
        }

        private void buttonsearchSuppliers_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxPublisherid.Text.Trim());
            DataRow drPublisher = dtPublisher.Rows.Find(searchId);
            if (drPublisher != null)
            {
                textBoxPublisherid.Text = drPublisher["PublisherId"].ToString();
                textBoxPublishername.Text = drPublisher["PublisherName"].ToString();

            }
            else
            {
                MessageBox.Show("Suppliers not found!", "Invalid Suppliers ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonupdaSuppliers_Click(object sender, EventArgs e)
        {
            daPublisher.Update(dsPublisher.Tables["Publishers"]);
            MessageBox.Show("Database has been updated sucessfully.", "Confirmation");
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you really want to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void buttonsearchCategory_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxCategoryid.Text.Trim());
            DataRow drCategory = dtCategory.Rows.Find(searchId);
            if (drCategory != null)
            {
                textBoxCategoryid.Text = drCategory["CategoryId"].ToString();
                textBoxCategoryname.Text = drCategory["CategoryName"].ToString();
               
            }
            else
            {
                MessageBox.Show("Category not found!", "Invalid Category ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonupdaCategory_Click(object sender, EventArgs e)
        {
            daCategory.Update(dsCategory.Tables["Categories"]);
            MessageBox.Show("Database has been updated sucessfully.", "Confirmation");
        }

        private void buttonaddSuppliers_Click(object sender, EventArgs e)
        {
            DataRow dr = dtPublisher.NewRow();
            dr["PublisherId"] = Convert.ToInt32(textBoxPublisherid.Text.Trim());
            dr["PublisherName"] = textBoxPublishername.Text.Trim();
            dtPublisher.Rows.Add(dr);
            MessageBox.Show(dr.RowState.ToString());
        }

        private void InventoryControllerForm_Load(object sender, EventArgs e)
        {
            dsBook = new DataSet("BookDB");
            dtBook = new DataTable("Books");
            dsBook.Tables.Add(dtBook);
            dtBook.Columns.Add("BookTitle", typeof(string));
            dtBook.Columns.Add("Isbn", typeof(string));
            dtBook.Columns.Add("SupplierId", typeof(Int32));
            dtBook.Columns.Add("AuthorId", typeof(Int32));
            dtBook.Columns.Add("CategoryId", typeof(Int32));
            dtBook.Columns.Add("Qoh", typeof(string));
            dtBook.Columns.Add("UnitPrice", typeof(Int32));
            dtBook.PrimaryKey = new DataColumn[] { dtBook.Columns["ISBN"] };
            daBook = new SqlDataAdapter("SELECT * FROM Books", UtillityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(daBook);
            daBook.Fill(dsBook.Tables["Books"]);

            dsAuthor = new DataSet("AuthorDB");
            dtAuthor = new DataTable("Authors");
            dsAuthor.Tables.Add(dtAuthor);
            dtAuthor.Columns.Add("AuthorId", typeof(Int32));
            dtAuthor.Columns.Add("AuthorName", typeof(string));
            dtAuthor.PrimaryKey = new DataColumn[] { dtAuthor.Columns["AuthorId"] };
            daAuthor = new SqlDataAdapter("SELECT * FROM Authors", UtillityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(daAuthor);
            daAuthor.Fill(dsAuthor.Tables["Authors"]);

            dsCategory = new DataSet("CategoryDB");
            dtCategory = new DataTable("Categories");
            dsCategory.Tables.Add(dtCategory);
            dtCategory.Columns.Add("CategoryId", typeof(Int32));
            dtCategory.Columns.Add("CategoryName", typeof(string));
            dtCategory.PrimaryKey = new DataColumn[] { dtCategory.Columns["CategoryId"] };
            daCategory = new SqlDataAdapter("SELECT * FROM Categories", UtillityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(daCategory);
            daCategory.Fill(dsCategory.Tables["Categories"]);

            dsPublisher = new DataSet("PublisherDB");
            dtPublisher = new DataTable("Publishers");
            dsPublisher.Tables.Add(dtPublisher);
            dtPublisher.Columns.Add("PublisherId", typeof(Int32));
            dtPublisher.Columns.Add("PublisherName", typeof(string));
            dtPublisher.PrimaryKey = new DataColumn[] { dtPublisher.Columns["PublisherId"] };
            daPublisher = new SqlDataAdapter("SELECT * FROM Publishers", UtillityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(daPublisher);
            daPublisher.Fill(dsPublisher.Tables["Publishers"]);
        }

        private void buttonlistauthor_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            dataGridViewauthor.DataSource = author.AuthorList();
        }

        private void buttonlistCategory_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            dataGridViewcategory.DataSource = category.CategoryList();
        }

        private void buttonUpdatedatabasebook_Click(object sender, EventArgs e)
        {
            daBook.Update(dsBook.Tables["Books"]);
            MessageBox.Show("Database has been updated sucessfully.", "Confirmation");
        }

        private void buttonDeletebook_Click(object sender, EventArgs e)
        {
            string searchisbn = textBoxisbn.Text.Trim();
            DataRow drBook = dtBook.Rows.Find(searchisbn);
            drBook.Delete();
            MessageBox.Show(drBook.RowState.ToString());
        }

        private void buttonUpdatebook_Click(object sender, EventArgs e)
        {
            string searchisbn = textBoxisbn.Text.Trim();
            DataRow drBook = dtBook.Rows.Find(searchisbn);
            drBook["BookTitle"] =textBoxtitle.Text.Trim();
            drBook["Isbn"] =textBoxisbn.Text.Trim();
            drBook["PublisherId"] = Convert.ToInt32(textBoxPublisher.Text.Trim());
            drBook["AuthorId"] = Convert.ToInt32(textBoxauthor.Text.Trim());
            drBook["CategoryId"] = Convert.ToInt32(textBoxcategory.Text.Trim());
            drBook["Qoh"] =textBoxqoh.Text.Trim();
            drBook["UnitPrice"] =Convert.ToInt32(textBoxprice.Text.Trim());
            MessageBox.Show(drBook.RowState.ToString());
        }
    }
}
