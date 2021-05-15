using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class RepositoryBooks
    {
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
        public List<Book> FindBooks(String NameBook="",String NameAutor="",String LastNameAutor="")
        {
            IEnumerable < Book > request = null;
            if (NameBook.IsNullOrWhiteSpace() &&
                NameAutor.IsNullOrWhiteSpace() &&
                LastNameAutor.IsNullOrWhiteSpace())
            {
                return Books;//?? convert IEnumerable->list?
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

        public Book GetBook(String ISBN)
        {
            return Books.FirstOrDefault(book => book.ISBN == ISBN);
        }
    }
}