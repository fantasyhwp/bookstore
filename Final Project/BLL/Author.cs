using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.DAL;

namespace Final_Project.BLL
{
    public class Author
    {
        private int authorId;
        private string authorName;

        public int AuthorId { get => authorId; set => authorId = value; }
        public string AuthorName { get => authorName; set => authorName = value; }
        public List<Author> AuthorList()
        {
            return (AuthorDB.GetListRecord());
        }
        public void SearchAuthor(int authorId)
        {
            AuthorDB.SearchRecord(authorId);
        }
        public List<Author> SearchAuthor(string name)
        {

            return AuthorDB.SearchRecord(name);
        }
    }
}
