using System;

namespace ClassLibrary
{
    public class BorrowedBook
    {
        public Book book
        {
            get;
            private set;
        }

        private DateTime _dateTime;
        public DateTime dateTime
        {
            get => _dateTime;
        }
        public BorrowedBook(Book book, DateTime _dateTime)
        {
            this.book = book;
            this._dateTime = _dateTime;
        }

    }
}
