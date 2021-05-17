using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class Library
    {
        //You can see just below, I open method (I think this is inconvenient ), but I have private inside and It can be open RepositoryBooks here?
        //look RepositoryBook - I break AV1014 (An object should not expose any other classes it depends on)
        private RepositoryBooks repositoryBooks = new RepositoryBooks();

        //???
        public void AddBook(Book book) => repositoryBooks.AddBook(book);

        //What AV1135?
        public List<Book> FindBooks(String NameBook = "", String NameAutor = "", String LastNameAutor = "") =>
            repositoryBooks.FindBooks(NameBook, NameAutor, LastNameAutor);

        public Book GetBook(String ISBN) => repositoryBooks.GetBook(ISBN);

        private DepartmentReaders departmentReaders = new DepartmentReaders();

        //???
        public void AddReader(Reader reader) => departmentReaders.AddReader(reader);

        public Reader GetReader(int IDReader) => departmentReaders.GetReader(IDReader);



    }
}
