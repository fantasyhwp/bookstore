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
        private int bookId;
        private string title;
        private string isbn;
        private int yearPublished;
        private string author;
        private string category;
        private int qoh;
        private int unitPrice;
        private string supplier;


        public int BookId { get => bookId; set => bookId = value; }
        public string Title { get => title; set => title = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public int YearPublished { get => yearPublished; set => yearPublished = value; }
        public string Author { get => author; set => author = value; }
        public string Category { get => category; set => category = value; }
        public int Qoh { get => qoh; set => qoh = value; }
        public int UnitPrice { get => unitPrice; set => unitPrice = value; }
        public string Supplier { get => supplier; set => supplier = value; }

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
