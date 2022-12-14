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
using Final_Project.VALIDATION;

namespace Final_Project.GUI
{
    public partial class FormEmployees : Form
    {
        public FormEmployees()
        {
            InitializeComponent();
        }

        private void buttonlistemp_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            List<Employee> listEmp = emp.ListEmployees();
            listViewemp.Items.Clear();
            if (listEmp.Count != 0)
            {
                foreach (Employee anEmp in listEmp)
                {
                    ListViewItem item = new ListViewItem(anEmp.EmployeeId.ToString());
                    item.SubItems.Add(anEmp.FirstName);
                    item.SubItems.Add(anEmp.LastName);
                    item.SubItems.Add(anEmp.PhoneNumber);
                    item.SubItems.Add(anEmp.Email);
                    item.SubItems.Add(anEmp.JobId.ToString());
                    listViewemp.Items.Add(item);
                }

            }
            else
            {
                MessageBox.Show("Empty List!", "No Employee");
            }
        }

        private void buttonsave_Click(object sender, EventArgs e)
        {
            string tempId = textBoxEmpid.Text.Trim();
            if (!(Validator.IsValidId(tempId)))
            {
                MessageBox.Show("Employee ID must be 4-digit number", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmpid.Clear();
                textBoxEmpid.Focus();
                return;
            }
            Employee tempEmp = new Employee();
            tempEmp = tempEmp.SearchEmployee(Convert.ToInt32(textBoxEmpid.Text.Trim()));
            if (tempEmp != null)
            {
                MessageBox.Show("This Employee ID already exists!", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmpid.Clear();
                textBoxEmpid.Focus();
                return;
            }
            string tempFirstName = textBoxfirstname.Text.Trim();
            if (!(Validator.IsValidName(tempFirstName)))
            {
                MessageBox.Show("Invalid First Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxfirstname.Clear();
                textBoxfirstname.Focus();
                return;
            }
            string tempLastName = textBoxlastname.Text.Trim();
            if (!(Validator.IsValidName(tempLastName)))
            {
                MessageBox.Show("Invalid Last Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxlastname.Clear();
                textBoxlastname.Focus();
                return;
            }
            string tempJob = textBoxjobid.Text.Trim();
            if ((Validator.IsEmpty(tempJob)))
            {
                MessageBox.Show("Job Title is required", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxjobid.Clear();
                textBoxjobid.Focus();
                return;
            }
            string tempPhoneNumber = textBoxphonenumber.Text.Trim();
            if ((Validator.IsEmpty(tempPhoneNumber)))
            {
                MessageBox.Show("PhoneNumber is required", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxphonenumber.Clear();
                textBoxphonenumber.Focus();
            }
            string tempEmail = textBoxemail.Text.Trim();
            if ((Validator.IsEmpty(tempEmail)))
            {
                MessageBox.Show("Invalid Email", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxemail.Clear();
                textBoxemail.Focus();
            }
            Employee emp = new Employee();
            emp.EmployeeId = Convert.ToInt32(textBoxEmpid.Text.Trim());
            emp.FirstName = textBoxfirstname.Text.Trim();
            emp.LastName = textBoxlastname.Text.Trim();
            emp.PhoneNumber = textBoxphonenumber.Text.Trim();
            emp.Email = textBoxemail.Text.Trim();
            emp.JobId = Convert.ToInt32(textBoxjobid.Text.Trim());
            emp.SaveEmployee(emp);
            MessageBox.Show("Employee data saved successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonupdate_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.EmployeeId = Convert.ToInt32(textBoxEmpid.Text.Trim());
            emp.FirstName = textBoxfirstname.Text.Trim();
            emp.LastName = textBoxlastname.Text.Trim();
            emp.PhoneNumber = textBoxphonenumber.Text.Trim();
            emp.Email = textBoxemail.Text.Trim();
            emp.JobId = Convert.ToInt32(textBoxjobid.Text.Trim());
            DialogResult answer = MessageBox.Show("Do you really want to update this employee info? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (answer == DialogResult.Yes)
            {
                emp.UpdateEmployee(emp);
            }
        }

        private void buttondeleteemp_Click(object sender, EventArgs e)
        {
            Employee delemp = new Employee();
            delemp = delemp.SearchEmployee(Convert.ToInt32(textBoxEmpid.Text));
            if (delemp != null)
            {
                delemp.DeleteEmployee(Convert.ToInt32(textBoxEmpid.Text));
                DialogResult delete=MessageBox.Show("Delete Successful!", "Successful", MessageBoxButtons.OK);
                if (delete == DialogResult.Yes)
                {
                    textBoxEmpid.Clear();
                    textBoxfirstname.Clear();
                    textBoxlastname.Clear();
                    textBoxphonenumber.Clear();
                    textBoxemail.Clear();
                    textBoxjobid.Clear();
                }
            }
            else
            {
                MessageBox.Show("This Employee does not exist", "Error", MessageBoxButtons.OK);
                textBoxEmpid.Text = "";
                textBoxEmpid.Focus();
                return;
            }
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Do you really want to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void buttonsearch_Click(object sender, EventArgs e)
        {
            int indexSelected = comboBoxsearchby.SelectedIndex;
            switch (indexSelected)
            {
               
                case 1:
                    //Search by FirstName
                    Employee emp = new Employee();
                    List<Employee> listEmp = emp.SearchEmployee(textBoxinfo.Text.ToString());
                    listViewemp.Items.Clear();
                    if (listEmp.Count != 0)
                    {
                        foreach (Employee anEmp in listEmp)
                        {
                            ListViewItem item = new ListViewItem(anEmp.EmployeeId.ToString());
                            item.SubItems.Add(anEmp.FirstName);
                            item.SubItems.Add(anEmp.LastName);
                            item.SubItems.Add(anEmp.PhoneNumber);
                            item.SubItems.Add(anEmp.Email);
                            item.SubItems.Add(anEmp.JobId.ToString());
                            listViewemp.Items.Add(item);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Employee not found!", "Error");
                    }
                    break;
                case 2:
                    //Search by last name
                    Employee emp2 = new Employee();
                    List<Employee> listEmp2 = emp2.SearchEmployee(textBoxinfo.Text.Trim());
                    listViewemp.Items.Clear();
                    if (listEmp2.Count != 0)
                    {
                        foreach (Employee anEmp in listEmp2)
                        {
                            ListViewItem item = new ListViewItem(anEmp.EmployeeId.ToString());
                            item.SubItems.Add(anEmp.FirstName);
                            item.SubItems.Add(anEmp.LastName);
                            item.SubItems.Add(anEmp.Email);
                            item.SubItems.Add(anEmp.JobId.ToString());
                            item.SubItems.Add(anEmp.PhoneNumber);
                            listViewemp.Items.Add(item);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Employee not found!", "Error");
                    }
                    break;
                case 3:
                    //Search by id
                    Employee emp3 = new Employee();
                    List<Employee> listEmp3 = emp3.SearchEmployee(textBoxinfo.Text.Trim());
                    listViewemp.Items.Clear();
                    if (listEmp3.Count != 0)
                    {
                        foreach (Employee anEmp in listEmp3)
                        {
                            ListViewItem item = new ListViewItem(anEmp.EmployeeId.ToString());
                            item.SubItems.Add(anEmp.FirstName);
                            item.SubItems.Add(anEmp.LastName);
                            item.SubItems.Add(anEmp.Email);
                            item.SubItems.Add(anEmp.JobId.ToString());
                            item.SubItems.Add(anEmp.PhoneNumber);
                            listViewemp.Items.Add(item);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Employee not found!", "Error");
                    }
                    break;

                default:
                    break;
            }

        }

        private void comboBoxsearchby_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSelected = comboBoxsearchby.SelectedIndex;

            switch (indexSelected)
            {
                case 1:
                    labelinfo.Text = "Please enter the Employee ID";
                    textBoxinfo.Clear();
                    textBoxinfo.Focus();
                    break;
                case 2:
                    labelinfo.Text = "Please enter the First Name";
                    textBoxinfo.Clear();
                    textBoxinfo.Focus();
                    break;
                case 3:
                    labelinfo.Text = "Please enter the last Name";
                    textBoxinfo.Clear();
                    textBoxinfo.Focus();
                    break;

                default:
                    break;
            }
        }

        private void listViewemp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonuserlistall_Click(object sender, EventArgs e)
        {
            User user = new User();
            List<User> listUser = user.ListUsers();
            listViewUser.Items.Clear();
            if (listUser.Count != 0)
            {
                foreach (User anUser in listUser)
                {
                    ListViewItem item = new ListViewItem(anUser.UserId.ToString());
                    item.SubItems.Add(anUser.Password);
                    item.SubItems.Add(anUser.EmployeeId.ToString());
                    listViewUser.Items.Add(item);
                }

            }
            else
            {
                MessageBox.Show("Empty List!", "No User");
            }
        }

        private void buttonuserSave_Click(object sender, EventArgs e)
        {
            string userId = textBoxuserid.Text.Trim();
            if (!(Validator.IsValidId(userId)))
            {
                MessageBox.Show("Employee ID must be 4-digit number", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxuserid.Clear();
                textBoxuserid.Focus();
                return;
            }
            User user = new User();
            user = user.SearchUser(Convert.ToInt32(textBoxuserid.Text.Trim()));
            if (user != null)
            {
                MessageBox.Show("This User ID already exists!", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxuserid.Clear();
                textBoxuserid.Focus();
                return;
            }
            string userPassword = textBoxpassword.Text.Trim();
            if (!(Validator.IsValidName(userPassword)))
            {
                MessageBox.Show("Invalid Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxpassword.Clear();
                textBoxpassword.Focus();
                return;
            }
            string UserempId = textBoxuseremployeeid.Text.Trim();
            if ((Validator.IsEmpty(UserempId)))
            {
                MessageBox.Show("EmployeeId is required", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxuseremployeeid.Clear();
                textBoxuseremployeeid.Focus();
                return;
            }
            User user1 = new User();
            user1.UserId = Convert.ToInt32(textBoxuseremployeeid.Text.Trim());
            user1.Password = textBoxpassword.Text.Trim();
            user1.EmployeeId = Convert.ToInt32(textBoxuseremployeeid.Text.Trim());
            user1.SaveUser(user1);
            MessageBox.Show("User data saved successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonuserupdate_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserId = Convert.ToInt32(textBoxuserid.Text.Trim());
            user.Password = textBoxpassword.Text.Trim();
            user.EmployeeId = Convert.ToInt32(textBoxuseremployeeid.Text.Trim());
            DialogResult answer = MessageBox.Show("Do you really want to update this employee info? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (answer == DialogResult.Yes)
            {
                user.UpdateUser(user);
            }
        }

        private void buttonuserdelete_Click(object sender, EventArgs e)
        {
            User deluser = new User();
            deluser = deluser.SearchUser(Convert.ToInt32(textBoxuserid.Text));
            if (deluser != null)
            {
                deluser.DeleteUser(Convert.ToInt32(textBoxuserid.Text));
                DialogResult delete = MessageBox.Show("Delete Successful!", "Successful", MessageBoxButtons.OK);
                if (delete == DialogResult.Yes)
                {
                    textBoxuserid.Clear();
                    textBoxpassword.Clear();
                    textBoxuseremployeeid.Clear();
                }
            }
            else
            {
                MessageBox.Show("This User does not exist", "Error", MessageBoxButtons.OK);
                textBoxuserid.Text = "";
                textBoxuserid.Focus();
                return;
            }
        }

        private void buttonusersearch_Click(object sender, EventArgs e)
        {
            
        }
    }
}
