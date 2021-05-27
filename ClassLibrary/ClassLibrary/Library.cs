using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class Library
    {
        private RepositoryBooks repositoryBooks = new RepositoryBooks();

        public void AddBookInLibrary(Book book) => repositoryBooks.AddBook(book);

        public List<Book> FindBooks(String NameBook = "", String NameAutor = "", String LastNameAutor = "") =>
            repositoryBooks.FindBooks(NameBook, NameAutor, LastNameAutor);

        public Book GetBook(int ID) => repositoryBooks.GetBook(ID);

        private DepartmentReaders departmentReaders = new DepartmentReaders();

        public void AddReader(Reader reader) => departmentReaders.AddReader(reader);

        public Reader GetReader(int IDReader) => departmentReaders.GetReader(IDReader);

        public void ReaderBoroweBook(Reader reader,Book book)
        {
            if (!departmentReaders.CheckReader(reader))
            {
                throw new ArgumentException($"Not Exist {reader.ArgumentsToString()} in DepartmentReaders");
            }
            if (departmentReaders.CheckBorrowedBook(book))
            {
                throw new ArgumentException($"Other reader already borrowed this book ID={book.ID}");
            }

            if (repositoryBooks.GetBook(book.ID)==null)
            {
                throw new ArgumentException($"This book not exist {book.ArgumentsToString()} in RepositoryBooks");
            }
            if (repositoryBooks.CountBookWithISBN(book.ISBN)==departmentReaders.CountBorrowedBooksWithISBN(book.ISBN))
            {
                throw new ArgumentException($"ALL books with {book.ISBN} borrowed");
            }


            departmentReaders.BorrowBook(reader, book);
        }

    }
}
