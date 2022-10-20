using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.DAL;

namespace Final_Project.BLL
{
    public class Customer
    {
        private int customerId;
        private string customerName;
        private string streetName;
        private string province;
        private string city;
        private string postalCode;
        private string contactName;
        private string contactEmail;
        private int creditLimit;

       

        
        public string CustomerName { get => customerName; set => customerName = value; }
        public int CreditLimit { get => creditLimit; set => creditLimit = value; }
        public string Province { get => province; set => province = value; }
        public string City { get => city; set => city = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public string ContactName { get => contactName; set => contactName = value; }
        public string ContactEmail { get => contactEmail; set => contactEmail = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string StreetName { get => streetName; set => streetName = value; }

        public List<Customer> CustomersList()
        {
            return (CustomerDB.GetListRecord());
        }
    }
}
