using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class CardReader
    {
        public int ID
        {
            get;
            private set;
        }
        public Reader Reader
        {
            get;
            private set;
        }
        public List<Book> Books
        {
            get;
            private set;
        }
        public static int Count
        {
            get;
            private set;
        }

        public CardReader(Reader reader)
        {
            //could better check here or all the same Library??
            if (reader == null)
            {
                throw new NullReferenceException("Readers reference is Null");
            }

            ID = ++Count;
            Reader = reader;
        }

        public void AddBookInCardReader(Book book)
        {
            if (book == null)
            {
                throw new NullReferenceException("Book's reference is Null (received in AddBookInCardReader)");
            }
            else if (book.AuthorBook == null || book.ISBN.IsNullOrWhiteSpace() || book.NameBook.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("AddBookInCardReader received incorrect arguments");
            }
        }
    }
}