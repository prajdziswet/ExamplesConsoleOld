using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class DepartmentReaders
    {
        private List<Reader> Readers
        {
            get;
            set;
        }
            = new List<Reader>();


        public void AddReader(Reader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("Reader reference is null");
            }
            Reader foundReader =
                Readers.FirstOrDefault(temp=> temp.Name==reader.Name&&temp.LastName==reader.LastName);

            if (foundReader == null)
            {
                Readers.Add(reader);
            }
            else
            {
                throw new ArgumentException("This reader exists in List");
            }
        }

        public Reader GetReader(int IDReader)
        {
            return Readers.FirstOrDefault(x => x.ID == IDReader);
        }

        public bool CheckBorrowedBook(Book book)
        {
            Book borrowedBook = Readers.SelectMany(x => x.BorrowedBooks).FirstOrDefault(x=>x==book);
            return borrowedBook != null;
        }

        public bool CheckReader(Reader reader)
        {
            return GetReader(reader.ID)!=null;
        }

        public void BorrowBook(Reader reader,Book book)
        {
            if (reader == null||book==null)
            {
                throw new ArgumentNullException($"Null Argument {((reader==null)?"reader":"book")} in AddBook");
            }

            if (!CheckReader(reader))
            {
                throw new ArgumentException("This reader not Exist in DataBase");
            }

            if (CheckBorrowedBook(book))
            {
                throw new ArgumentException($"This book with ISBN={book.ISBN} borrowed");
            }

            reader.AddBookInCard(book);
        }
    }
}