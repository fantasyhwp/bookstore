using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.DAL;

namespace Final_Project.BLL
{
    public class Suppliers
    {
        private int supplierId;
        private string supplierName;

        public int SupplierId { get => supplierId; set => supplierId = value; }
        public string SupplierName { get => supplierName; set => supplierName = value; }

        public List<Suppliers> SuppliersList()
        {
            return (SuppliersDB.GetListRecord());
        }
        public void SearchStudent(int suppliersId)
        {
            SuppliersDB.SearchRecord(suppliersId);
        }
        public void UpdateStudent(Suppliers suppliers)
        {
            SuppliersDB.UpdateRecord(suppliers);
        }

        public void DeleteStudent(int suppliersId)
        {
            SuppliersDB.DeleteRecord(suppliersId);
        }
        public List<Suppliers> SearchStudent(string name)
        {

            return SuppliersDB.SearchRecord(name);
        }
    }
}
