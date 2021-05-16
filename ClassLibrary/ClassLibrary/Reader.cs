using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class Reader
    {
        public int ID
        {
            get;
            private set;
        }
        public String Name
        {
            get;
            private set;
        }
        public String LastName
        {
            get;
            private set;
        }

        public List<Book> BorrowedBooks
        {
            get;
            private set;
        } = new List<Book>();

        public static int Count
        {
            get;
            private set;
        }

        public Reader(String NameReader, String LastNameReader)
        {

            if (NameReader.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Name is empty");
            }
            else if (LastNameReader.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("LastName is empty");
            }

            ID=++Count;
            this.Name = NameReader;
            this.LastName = LastNameReader;
        }

        public void AddBookInCard(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("Book's reference is Null (received in AddBookInCardReader)");
            }

            var findBook = BorrowedBooks.FirstOrDefault(x => x.ISBN==book.ISBN);
            if (findBook != null)
            {
                throw new ArgumentException("you have already taken this book");
            }
            else
            {
                BorrowedBooks.Add(book);
            }

        }
    }
}
