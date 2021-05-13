using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class Library
    {
        public List<Book> Books
        {
            get;
            private set;
        }
            = new List<Book>();

        public void AddBookInLibrary(Book book)
        {
            if (book == null)
            {
                throw new NullReferenceException("Book's reference is null");
            }
            
            Author returnAuthor = Authors?.FirstOrDefault(x =>
                x.ID == book.AuthorBook.ID);
            if (returnAuthor == null)
            {
                throw new ArgumentException("This author doesn't exist in list");
            }

            Book returnBook = Books?.FirstOrDefault(x => x.ISBN ==book.ISBN);
            if (returnBook != null)
            {
                throw new ArgumentException("This book's ISBN exists");
            }
            else
            {
                Books.Add(book);
            }
        }

        public List<Author> Authors
        {
            get;
            private set;
        } 
            = new List<Author>();

        public void AddAuthorInList(Author author)
        {
            if (author == null)
            {
                throw new NullReferenceException("Author's reference is null");
            }

            Author returnAuthor = Authors?.FirstOrDefault(x =>
                x.ID == author.ID);

            if (returnAuthor == null)
            {
                Authors.Add(author);
            }
            else
            {
                throw new ArgumentException("This author exists in List");
            }
        }

        public List<Reader> Readers
        {
            get;
            private set;
        }
            = new List<Reader>();


        public void AddReader(Reader reader)
        {
            if (reader == null)
            {
                throw new NullReferenceException("Reader reference is null");
            }
            Reader returnReader =
                Readers.FirstOrDefault(card => card.ID==reader.ID);

            if (returnReader == null)
            {
                Readers.Add(reader);
            }
            else
            {
                throw new ArgumentException("This reader exists in List");
            }
        }


    }
}
