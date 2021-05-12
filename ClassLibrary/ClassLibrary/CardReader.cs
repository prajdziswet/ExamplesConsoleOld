using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class CardReader
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

        public List<Book> Books
        {
            get;
            private set;
        } = new List<Book>();

        public static int Count
        {
            get;
            private set;
        }

        public CardReader(String NameReader, String LastNameReader)
        {

            if (NameReader.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Name is empty");
            }
            else if (LastNameReader.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Name is empty");
            }

            ID=++Count;
            this.Name = NameReader;
            this.LastName = LastNameReader;
        }

        public void WriteBookInCard(Book book)
        {
            if (book == null)
            {
                throw new NullReferenceException("Book's reference is Null (received in AddBookInCardReader)");
            }

            var findBook = Books.FirstOrDefault(x => x.ISBN==book.ISBN);
            if (findBook != null)
            {
                throw new ArgumentException("you have already taken this book");
            }


        }
    }
}
