using System.Collections.Generic;
using GoodBooks.Data;

namespace GoodBooks.Services
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
        public Book GetBook(int bookId);
        public void AddBook(Book book);
        public void DeleteBook(int bookId);
    }
}