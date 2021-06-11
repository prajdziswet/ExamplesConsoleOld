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

        public DateTime dateTime
        {
            get;
            private set;
        }
        public BorrowedBook(Book book, DateTime dateTime)
        {
            this.book = book;
            this.dateTime = dateTime;
        }

    }
}
