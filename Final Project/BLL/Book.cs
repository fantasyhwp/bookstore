using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.DAL;

namespace Final_Project.BLL
{
    public class Book
    {
        
        
        private string isbn;
        private string bookTitel;       
        private string qoh;
        private int unitPrice;
        private int categoryId;
        private int publisherId;
        private int authorId;


        
        public string Isbn { get => isbn; set => isbn = value; }
        public string Qoh { get => qoh; set => qoh = value; }
        public int UnitPrice { get => unitPrice; set => unitPrice = value; }
        public string BookTitel { get => bookTitel; set => bookTitel = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public int PublisherId { get => publisherId; set => publisherId = value; }
        public int AuthorId { get => authorId; set => authorId = value; }

        public List<Book> BookList()
        {
            return (BookDB.GetListRecord());
        }
        public void SearchBook(int bookId)
        {
            BookDB.SearchRecord(bookId);
        }
        public void UpdateStudent(Book book)
        {
            BookDB.UpdateRecord(book);
        }
        public void DeleteStudent(int bookId)
        {
            BookDB.DeleteRecord(bookId);
        }
        public List<Book> Searchbook(string name)
        {

            return BookDB.SearchRecord(name);
        }
    }
}
