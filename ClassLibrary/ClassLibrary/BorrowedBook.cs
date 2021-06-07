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

        public DateTime dateTime
        {
            get;
            //private set;
            //so the field is set only once when the class is created? (without set) 
        } = DateTime.Now;

        public BorrowedBook(Book book):base(book.ISBN,book.NameBook,book.AuthorBook)
        {
            ID=book.ID;
        }

        //why is it better? 
        public BorrowedBook(int ID,String ISBN, String NameBook, Author AuthorBook) 
            : base(ISBN, NameBook, AuthorBook)
        {
            this.ID = ID;
        }
    }
}
