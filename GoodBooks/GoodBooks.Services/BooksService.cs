using System;
using System.Linq;
using GoodBooks.Data;

namespace GoodBooks.Services
{
    public class BooksService : IBookService
    {
     private readonly GoodBookDbContext _db;
        public BooksService(GoodBookDbContext db)
        {
            _db = db;
        }
        public void AddBook(Book book)
        {
            _db.Add(book);
            _db.SaveChanges();
        }
        public void DeleteBook(int bookId)
        {
            var bookToDelete = _db.Books.Find(bookId);
            if(bookToDelete != null){
                _db.Remove(bookToDelete);
            }else{
                throw new InvalidOperationException("Can't delete book that doesn't exist");
            }
        }

        public System.Collections.Generic.List<Book> GetAllBooks()
        {
            return _db.Books.ToList();
        }

        public Book GetBook(int bookId)
        {
           return _db.Books.Find(bookId);
        }
    }
}
