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
        Suppliers suppliers = new Suppliers();
        SqlDataAdapter daBook,daAuthor, daCategory,daSuppliers;
        DataSet dsBook,dsAuthor, dsCategory, dsSuppliers;
        DataTable dtBook, dtAuthor, dtCategory, dtSuppliers;
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
            int searchId = Convert.ToInt32(textBoxbookid.Text.Trim());
            DataRow drBook = dtBook.Rows.Find(searchId);
            if (drBook != null)
            {
                textBoxbookid.Text = drBook["BookId"].ToString();
                textBoxtitle.Text = drBook["Title"].ToString();
                textBoxisbn.Text = drBook["Isbn"].ToString();
                textBoxyear.Text = drBook["YearPublished"].ToString();
                textBoxsuppler.Text = drBook["Supplier"].ToString();
                textBoxauthor.Text = drBook["Author"].ToString();
                textBoxcategory.Text = drBook["Category"].ToString();
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
            Suppliers suppliers = new Suppliers();
            dataGridViewsuppliser.DataSource = suppliers.SuppliersList();
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
            dr["BookId"] = textBoxbookid.Text.Trim();
            dr["Title"] = textBoxtitle.Text.Trim();
            dr["Isbn"] = textBoxisbn.Text.Trim();
            dr["YearPublished"] = Convert.ToInt32(textBoxyear.Text.Trim());
            dr["Supplier"] = textBoxsuppler.Text.Trim();
            dr["Author"] = textBoxauthor.Text.Trim();
            dr["Category"] = textBoxcategory.Text.Trim();
            dr["Qoh"] = Convert.ToInt32(textBoxqoh.Text.Trim());
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
            daAuthor.Update(dsAuthor.Tables["Author"]);
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
            int searchId = Convert.ToInt32(textBoxSuppliersid.Text.Trim());
            DataRow drSuppliers = dtSuppliers.Rows.Find(searchId);
            drSuppliers.Delete();
            MessageBox.Show(drSuppliers.RowState.ToString());
        }

        private void buttonupdateSuppliers_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxSuppliersid.Text.Trim());
            DataRow drSuppliers = dtSuppliers.Rows.Find(searchId);
            drSuppliers["SupplierId"] = Convert.ToInt32(textBoxSuppliersid.Text.Trim());
            drSuppliers["SupplierName"] = textBoxSuppliersname.Text.Trim();
            MessageBox.Show(drSuppliers.RowState.ToString());
        }

        private void buttonsearchSuppliers_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxSuppliersid.Text.Trim());
            DataRow drSuppliers = dtSuppliers.Rows.Find(searchId);
            if (drSuppliers != null)
            {
                textBoxSuppliersid.Text = drSuppliers["SupplierId"].ToString();
                textBoxSuppliersname.Text = drSuppliers["SupplierName"].ToString();

            }
            else
            {
                MessageBox.Show("Suppliers not found!", "Invalid Suppliers ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonupdaSuppliers_Click(object sender, EventArgs e)
        {
            daSuppliers.Update(dsSuppliers.Tables["Suppliers"]);
            MessageBox.Show("Database has been updated sucessfully.", "Confirmation");
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
            daCategory.Update(dsCategory.Tables["Category"]);
            MessageBox.Show("Database has been updated sucessfully.", "Confirmation");
        }

        private void buttonaddSuppliers_Click(object sender, EventArgs e)
        {
            DataRow dr = dtSuppliers.NewRow();
            dr["SupplierId"] = Convert.ToInt32(textBoxSuppliersid.Text.Trim());
            dr["SupplierName"] = textBoxSuppliersname.Text.Trim();
            dtSuppliers.Rows.Add(dr);
            MessageBox.Show(dr.RowState.ToString());
        }

        private void InventoryControllerForm_Load(object sender, EventArgs e)
        {
            dsBook = new DataSet("BookDB");
            dtBook = new DataTable("Books");
            dsBook.Tables.Add(dtBook);
            dtBook.Columns.Add("BookId", typeof(Int32));
            dtBook.Columns.Add("Title", typeof(string));
            dtBook.Columns.Add("Isbn", typeof(string));
            dtBook.Columns.Add("YearPublished", typeof(Int32));
            dtBook.Columns.Add("Supplier", typeof(string));
            dtBook.Columns.Add("Author", typeof(string));
            dtBook.Columns.Add("Category", typeof(string));
            dtBook.Columns.Add("Qoh", typeof(Int32));
            dtBook.Columns.Add("UnitPrice", typeof(Int32));

            dtBook.PrimaryKey = new DataColumn[] { dtBook.Columns["BookId"] };
            daBook = new SqlDataAdapter("SELECT * FROM Books", UtillityDB.ConnectDB());
            sqlBuilder = new SqlCommandBuilder(daBook);
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
            int searchId = Convert.ToInt32(textBoxbookid.Text.Trim());
            DataRow drBook = dtBook.Rows.Find(searchId);
            drBook.Delete();
            MessageBox.Show(drBook.RowState.ToString());
        }

        private void buttonUpdatebook_Click(object sender, EventArgs e)
        {
            int searchId = Convert.ToInt32(textBoxbookid.Text.Trim());
            DataRow drBook = dtBook.Rows.Find(searchId);
            drBook["BookId"] =Convert.ToInt32(textBoxbookid.Text.Trim());
            drBook["Title"] =textBoxtitle.Text.Trim();
            drBook["Isbn"] =textBoxisbn.Text.Trim();
            drBook["YearPublished"] =Convert.ToInt32(textBoxyear.Text.Trim());
            drBook["Supplier"] =textBoxsuppler.Text.Trim();
            drBook["Author"] =textBoxauthor.Text.Trim();
            drBook["Category"] =textBoxcategory.Text.Trim();
            drBook["Qoh"] =Convert.ToInt32(textBoxqoh.Text.Trim());
            drBook["UnitPrice"] =Convert.ToInt32(textBoxprice.Text.Trim());
            MessageBox.Show(drBook.RowState.ToString());
        }
    }
}
