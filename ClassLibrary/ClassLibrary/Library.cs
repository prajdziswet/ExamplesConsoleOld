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

        public void ReaderBoroweBook(int IDReader, String NameBook)
        {
            if (departmentReaders.GetReader(IDReader)==null)
            {
                throw new ArgumentException($"Not Exist Reader with (ID={IDReader}) in DepartmentReaders");
            }

            if (NameBook.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException($"Not set Namebook");
            }

            var listAllBookWithName = repositoryBooks.FindBooks(NameBook);
          
            if (listAllBookWithName.Count == 0)
            {
                    throw new ArgumentException($"This book ({NameBook}) not exist in RepositoryBooks");
            }

           String ISBN = listAllBookWithName[0].ISBN;

           HashSet<Book> allBookWithISBN= new HashSet<Book>(listAllBookWithName);

           HashSet<Book> borrowedBookWithISBN = departmentReaders.BorrowedBooksWithISBN(ISBN);

            //Free Book
            allBookWithISBN.ExceptWith(borrowedBookWithISBN);

            if (allBookWithISBN.Count==0)
            {
                throw new ArgumentException("ALL books borrowed");
            }

            Book freeBook = allBookWithISBN.First();

            departmentReaders.BorrowBook(departmentReaders.GetReader(IDReader),
                                                freeBook);


        }
    }
}
