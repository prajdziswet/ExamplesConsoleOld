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

        public Book GetBook(String ISBN) => repositoryBooks.GetBook(ISBN);

        private DepartmentReaders departmentReaders = new DepartmentReaders();

        public void AddReader(Reader reader) => departmentReaders.AddReader(reader);

        public Reader GetReader(int IDReader) => departmentReaders.GetReader(IDReader);

    }
}
