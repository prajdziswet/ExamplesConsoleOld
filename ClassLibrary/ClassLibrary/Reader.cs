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

        private List<BorrowedBook> borrowedBooks = new List<BorrowedBook>();

        public IReadOnlyList<BorrowedBook> BorrowedBooks
        => borrowedBooks.AsReadOnly();

        private static int Count
        {
            get;
            set;
        }

        public Reader(String NameReader, String LastNameReader)
        {

            if (NameReader.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Name is empty");
            }

            if (LastNameReader.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("LastName is empty");
            }

            ID=++Count;
            this.Name = NameReader;
            this.LastName = LastNameReader;
        }

        internal void AddBookInCard(Book book)
        {
            var findBook = BorrowedBooks.FirstOrDefault(x => x.book.ISBN==book.ISBN);
            if (findBook != null)
            {
                throw new ArgumentException("you have already taken simular book");
            }
            else
            {
                try
                {
                borrowedBooks.Add(new BorrowedBook(book,DateTime.Now)); 
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public String ArgumentsToString()
        => $"{LastName} {Name}";
    }
}
