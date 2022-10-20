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
        private string customerId;
        private string customerName;
        private string streetAddress;
        private string province;
        private string city;
        private string postalCode;
        private int creditLimit;
        private string phoneNumber;

        public string CustomerId { get => customerId; set => customerId = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string StreetAddress { get => streetAddress; set => streetAddress = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public int CreditLimit { get => creditLimit; set => creditLimit = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Province { get => province; set => province = value; }
        public string City { get => city; set => city = value; }

        public List<Customer> CustomersList()
        {
            return (CustomerDB.GetListRecord());
        }
    }
}
