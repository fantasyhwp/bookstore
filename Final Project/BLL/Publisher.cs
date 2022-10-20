using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.DAL;

namespace Final_Project.BLL
{
    public class Publisher
    {
        private int publisherId;
        private string publisherName;

        public int PublisherId { get => publisherId; set => publisherId = value; }
        public string PublisherName { get => publisherName; set => publisherName = value; }

        public List<Publisher> SuppliersList()
        {
            return (PublisherDB.GetListRecord());
        }
        public void SearchStudent(int suppliersId)
        {
            PublisherDB.SearchRecord(suppliersId);
        }
        public void UpdateStudent(Publisher suppliers)
        {
            PublisherDB.UpdateRecord(suppliers);
        }

        public void DeleteStudent(int suppliersId)
        {
            PublisherDB.DeleteRecord(suppliersId);
        }
        public List<Publisher> SearchStudent(string name)
        {

            return PublisherDB.SearchRecord(name);
        }
    }
}
