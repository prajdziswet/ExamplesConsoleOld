using System;

namespace ClassLibrary
{
    public class BorrowedBook: Book
    {
        private DateTime _dateTime=DateTime.Now;
        public DateTime dateTime
        {
            get => _dateTime;
        }
        public BorrowedBook(String ISBN, String NameBook, Author AuthorBook):base(ISBN, NameBook, AuthorBook)
        {}
    }
}
