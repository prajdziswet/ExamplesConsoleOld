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

            Book foundBook = Books?.FirstOrDefault(x => x.ID == book.ID);
            if (foundBook != null)
            {
                throw new ArgumentException($"This book's [{book.ID},{book.NameBook}] exists");
            }

                var foundBooks = Books?.Where(x => x.ISBN == book.ISBN);
                bool check=(bool) foundBooks?.Any(x=>x.NameBook!=book.NameBook||!x.AuthorBook.EqualArgument(book.AuthorBook));

            if (check)
            {
                foundBook = foundBooks?.FirstOrDefault(x => x.NameBook != book.NameBook || !x.AuthorBook.EqualArgument(book.AuthorBook));
                throw new ArgumentException($"This book with {book.ISBN} exist! Example is {foundBook.NameBook}-{foundBook.AuthorBook.Name}-{foundBook.AuthorBook.Name}");
            }

            Books.Add(book);

        }

 
        public List<Book> FindBooks(String NameBook="",String NameAutor="",String LastNameAutor="")
        {
            IEnumerable < Book > request = Books;

            if (NameBook.IsExist())
            {
                request= request.Where(book => book.NameBook == NameBook);
            }

            if (NameAutor.IsExist())
            {
                request = request.Where(book => book.AuthorBook.Name == NameAutor);
            }

            if (LastNameAutor.IsExist())
            {
                request = request.Where(book => book.AuthorBook.LastName == LastNameAutor);
            }

            return request.ToList();
        }

        public Book GetBook(int ID)
        {
            return Books.FirstOrDefault(book => book.ID == ID);
        }
    }
}