using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.DAL;

namespace Final_Project.BLL
{
    public class User
    {
        private int userId;
        private string password;
        private int employeeId;

        
        public string Password { get => password; set => password = value; }
        public int UserId { get => userId; set => userId = value; }
        public int EmployeeId { get => employeeId; set => employeeId = value; }

        public bool VerfyLogIn(int userid, string password)
        {
            return UserDB.LogIn(userid, password);
        }
        public List<User> ListUsers()
        {
            return UserDB.ListAllRecords();
        }
        public void UpdateUser(User user)
        {
            UserDB.UpdateRecord(user);
        }
        public void DeleteUser(int UserId)
        {
            UserDB.DeleteRecord(UserId);
        }
        public void SaveUser(User user)
        {
            UserDB.SaveRecord(user);
        }
        public User SearchUser(int userId)
        {

            return UserDB.SearchRecord(userId);
        }
        
    }
}
