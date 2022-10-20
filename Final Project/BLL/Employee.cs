using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.DAL;

namespace Final_Project.BLL
{
   public class Employee
    {
        private int employeeId;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string email;
        private int jobId;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public int JobId { get => jobId; set => jobId = value; }

        public List<Employee> ListEmployees()
        {
            return EmployeeDB.ListAllRecords();
        }
        public void UpdateEmployee(Employee employee)
        {
            EmployeeDB.UpdateRecord(employee);
        }
        public void DeleteEmployee(int EmployeeId)
        {
            EmployeeDB.DeleteRecord(EmployeeId);
        }
        public void SaveEmployee(Employee employee)
        {
            EmployeeDB.SaveRecord(employee);
        }
        public Employee SearchEmployee(int empId)
        {

            return EmployeeDB.SearchRecord(empId);
        }
        public List<Employee> SearchEmployee(string name)
        {

            return EmployeeDB.SearchRecord(name);
        }
    }
}
