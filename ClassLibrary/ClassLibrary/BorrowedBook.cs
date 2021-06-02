using System;

namespace ClassLibrary
{
    public class BorrowedBook: Book
    {
        public new int ID
        {
            get;
            private set;
        }
        private DateTime _dateTime=DateTime.Now;
        public DateTime dateTime
        {
            get => _dateTime;
        }
        public BorrowedBook(Book book):base(book.ISBN,book.NameBook,book.AuthorBook)
        {
            ID=book.ID;
        }
    }
}
