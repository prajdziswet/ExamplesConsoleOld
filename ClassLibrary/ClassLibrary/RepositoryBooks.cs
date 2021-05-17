using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class RepositoryBooks
    {
        // looks like with "DepartmentReaders", you can write for one occasion...  

        //for comfortable I do it open, but I break AV1014 (An object should not expose any other classes it depends on for Library)
        private List<Book> Books
        {
            get;
            set;
        }
            = new List<Book>();

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("Book's reference is null");
            }

            Book foundBook = Books?.FirstOrDefault(x => x.ISBN == book.ISBN);
            if (foundBook != null)
            {
                throw new ArgumentException($"This book's [{book.ISBN},{book.NameBook}] exists");
            }
            else
            {
                Books.Add(book);
            }
        }

        // what should we return ?
        // what AV1130? I return "list" (For convenience), but use IEnumerable inside 
        // And how should I convert the list (just below)? 
        public List<Book> FindBooks(String NameBook="",String NameAutor="",String LastNameAutor="")
        {
            IEnumerable < Book > request = null;
            if (NameBook.IsNullOrWhiteSpace() &&
                NameAutor.IsNullOrWhiteSpace() &&
                LastNameAutor.IsNullOrWhiteSpace())
            {
                return Books;//??? convert IEnumerable->list?
            }
            ;
            if (!NameBook.IsNullOrWhiteSpace())
            {
                request= Books.Where(book => book.NameBook == NameBook).ToList();
            }

            if (!NameAutor.IsNullOrWhiteSpace())
            {
                request =(request == null)?
                            Books.Where(book => book.AuthorBook.Name == NameAutor).ToList():
                            request.Where(book => book.AuthorBook.Name == NameAutor).ToList();
            }

            if (!LastNameAutor.IsNullOrWhiteSpace())
            {
                request = (request == null) ?
                    Books.Where(book => book.AuthorBook.LastName == LastNameAutor).ToList() :
                    request.Where(book => book.AuthorBook.LastName == LastNameAutor).ToList();
            }

            return request.ToList();
        }

        //What AV1135?
        public Book GetBook(String ISBN)
        {
            return Books.FirstOrDefault(book => book.ISBN == ISBN);
        }
    }
}