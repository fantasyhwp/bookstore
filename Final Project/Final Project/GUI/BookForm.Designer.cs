namespace Final_Project.GUI
{
    partial class BookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxprice = new System.Windows.Forms.TextBox();
            this.textBoxqoh = new System.Windows.Forms.TextBox();
            this.textBoxcategory = new System.Windows.Forms.TextBox();
            this.textBoxauthor = new System.Windows.Forms.TextBox();
            this.textBoxsuppler = new System.Windows.Forms.TextBox();
            this.textBoxyear = new System.Windows.Forms.TextBox();
            this.textBoxisbn = new System.Windows.Forms.TextBox();
            this.textBoxtitle = new System.Windows.Forms.TextBox();
            this.textBoxbookid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colBookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearPublished = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QOH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.textBoxprice);
            this.groupBox1.Controls.Add(this.textBoxqoh);
            this.groupBox1.Controls.Add(this.textBoxcategory);
            this.groupBox1.Controls.Add(this.textBoxauthor);
            this.groupBox1.Controls.Add(this.textBoxsuppler);
            this.groupBox1.Controls.Add(this.textBoxyear);
            this.groupBox1.Controls.Add(this.textBoxisbn);
            this.groupBox1.Controls.Add(this.textBoxtitle);
            this.groupBox1.Controls.Add(this.textBoxbookid);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(58, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Book Information";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(537, 39);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(64, 33);
            this.buttonClear.TabIndex = 18;
            this.buttonClear.Text = "Cl&ear";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // textBoxprice
            // 
            this.textBoxprice.Location = new System.Drawing.Point(380, 188);
            this.textBoxprice.Name = "textBoxprice";
            this.textBoxprice.Size = new System.Drawing.Size(108, 21);
            this.textBoxprice.TabIndex = 17;
            this.textBoxprice.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // textBoxqoh
            // 
            this.textBoxqoh.Location = new System.Drawing.Point(380, 150);
            this.textBoxqoh.Name = "textBoxqoh";
            this.textBoxqoh.Size = new System.Drawing.Size(108, 21);
            this.textBoxqoh.TabIndex = 16;
            // 
            // textBoxcategory
            // 
            this.textBoxcategory.Location = new System.Drawing.Point(380, 111);
            this.textBoxcategory.Name = "textBoxcategory";
            this.textBoxcategory.Size = new System.Drawing.Size(108, 21);
            this.textBoxcategory.TabIndex = 15;
            // 
            // textBoxauthor
            // 
            this.textBoxauthor.Location = new System.Drawing.Point(380, 73);
            this.textBoxauthor.Name = "textBoxauthor";
            this.textBoxauthor.Size = new System.Drawing.Size(108, 21);
            this.textBoxauthor.TabIndex = 14;
            // 
            // textBoxsuppler
            // 
            this.textBoxsuppler.Location = new System.Drawing.Point(380, 36);
            this.textBoxsuppler.Name = "textBoxsuppler";
            this.textBoxsuppler.Size = new System.Drawing.Size(108, 21);
            this.textBoxsuppler.TabIndex = 13;
            // 
            // textBoxyear
            // 
            this.textBoxyear.Location = new System.Drawing.Point(88, 150);
            this.textBoxyear.Name = "textBoxyear";
            this.textBoxyear.Size = new System.Drawing.Size(108, 21);
            this.textBoxyear.TabIndex = 12;
            // 
            // textBoxisbn
            // 
            this.textBoxisbn.Location = new System.Drawing.Point(88, 111);
            this.textBoxisbn.Name = "textBoxisbn";
            this.textBoxisbn.Size = new System.Drawing.Size(108, 21);
            this.textBoxisbn.TabIndex = 11;
            // 
            // textBoxtitle
            // 
            this.textBoxtitle.Location = new System.Drawing.Point(88, 73);
            this.textBoxtitle.Name = "textBoxtitle";
            this.textBoxtitle.Size = new System.Drawing.Size(108, 21);
            this.textBoxtitle.TabIndex = 10;
            // 
            // textBoxbookid
            // 
            this.textBoxbookid.Location = new System.Drawing.Point(88, 36);
            this.textBoxbookid.Name = "textBoxbookid";
            this.textBoxbookid.Size = new System.Drawing.Size(108, 21);
            this.textBoxbookid.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(322, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "Price";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(330, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "QOH";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(322, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "Category";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(322, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "Author";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(322, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Supplier";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "ISBN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book Id";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(67, 295);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(64, 33);
            this.buttonAdd.TabIndex = 19;
            this.buttonAdd.Text = "&Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(205, 295);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(64, 33);
            this.buttonUpdate.TabIndex = 20;
            this.buttonUpdate.Text = "&Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(347, 295);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(64, 33);
            this.buttonRemove.TabIndex = 21;
            this.buttonRemove.Text = "&Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBookId,
            this.colProductName,
            this.ISBN,
            this.YearPublished,
            this.SupplierId,
            this.Supplier,
            this.AuthorId,
            this.Author,
            this.CategoryId,
            this.Category,
            this.QOH,
            this.UnitPrice});
            this.dataGridView1.Location = new System.Drawing.Point(27, 367);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(696, 148);
            this.dataGridView1.TabIndex = 22;
            // 
            // colBookId
            // 
            this.colBookId.HeaderText = "Book Id";
            this.colBookId.Name = "colBookId";
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "Title";
            this.colProductName.Name = "colProductName";
            // 
            // ISBN
            // 
            this.ISBN.HeaderText = "ISBN";
            this.ISBN.Name = "ISBN";
            // 
            // YearPublished
            // 
            this.YearPublished.HeaderText = "Year Published";
            this.YearPublished.Name = "YearPublished";
            // 
            // SupplierId
            // 
            this.SupplierId.HeaderText = "Supplier Id";
            this.SupplierId.Name = "SupplierId";
            // 
            // Supplier
            // 
            this.Supplier.HeaderText = "Supplier";
            this.Supplier.Name = "Supplier";
            // 
            // AuthorId
            // 
            this.AuthorId.HeaderText = "Author Id";
            this.AuthorId.Name = "AuthorId";
            // 
            // Author
            // 
            this.Author.HeaderText = "Author";
            this.Author.Name = "Author";
            // 
            // CategoryId
            // 
            this.CategoryId.HeaderText = "Category Id";
            this.CategoryId.Name = "CategoryId";
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            // 
            // QOH
            // 
            this.QOH.HeaderText = "QOH";
            this.QOH.Name = "QOH";
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.Name = "UnitPrice";
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 555);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.groupBox1);
            this.Name = "BookForm";
            this.Text = "BookForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxprice;
        private System.Windows.Forms.TextBox textBoxqoh;
        private System.Windows.Forms.TextBox textBoxcategory;
        private System.Windows.Forms.TextBox textBoxauthor;
        private System.Windows.Forms.TextBox textBoxsuppler;
        private System.Windows.Forms.TextBox textBoxyear;
        private System.Windows.Forms.TextBox textBoxisbn;
        private System.Windows.Forms.TextBox textBoxtitle;
        private System.Windows.Forms.TextBox textBoxbookid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearPublished;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn QOH;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
    }
}