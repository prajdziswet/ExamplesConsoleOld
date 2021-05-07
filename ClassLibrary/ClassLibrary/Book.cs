using System;

namespace ClassLibrary
{
    public class Book
    {
        public String ISBN
        {
            get;
            private set;
        }
        public String NameBook
        {
            get;
            private set;
        }
        public Author AuthorBook
        {
            get;
            private set;
        }

        public Book (String ISBN, String NameBook, Author AuthorBook)
        {
            this.ISBN = ISBN;
            this.NameBook = NameBook;
            this.AuthorBook = AuthorBook;
        }
    }
}