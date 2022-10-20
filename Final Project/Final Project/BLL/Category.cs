using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.DAL;

namespace Final_Project.BLL
{
    public class Category
    {
        private int categoryId;
        private string categoryName;

        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }

        public List<Category> CategoryList()
        {
            return (CategoryDB.GetListRecord());
        }
        public void SearchCategory(int categoryId)
        {
            CategoryDB.SearchRecord(categoryId);
        }
        public List<Category> SearchCategory(string name)
        {

            return CategoryDB.SearchRecord(name);
        }
    }
    
}
