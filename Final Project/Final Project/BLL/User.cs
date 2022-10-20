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
        private int userid;
        private string password;

        
        public string Password { get => password; set => password = value; }
        public int Userid { get => userid; set => userid = value; }

        public bool VerfyLogIn(int userid, string password)
        {
            return UserDB.LogIn(userid, password);
        }

        
    }
}
