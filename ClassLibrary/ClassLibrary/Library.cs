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

        public void AddBook(String ISBN, String nameBook, Author author)
        {
            if (ISBN.IsNullOrWhiteSpace() || nameBook.IsNullOrWhiteSpace() || author == null)
            {
                throw new ArgumentNullException("One of the fields of the book is empty");
            }

            Book returnBook = Books?.FirstOrDefault(x => x.ISBN == ISBN);
            Author authorInAuthors = Authors?.FirstOrDefault(x => x.ID == author.ID);

            if (returnBook != null|| authorInAuthors==null)
            {
                throw new ArgumentException("This book or author doesn't exist");
            }
            else
            {
                returnBook = new Book(ISBN, nameBook, author);
                Books.Add(returnBook);
            }
        }

        public List<Author> Authors
        {
            get;
            private set;
        } 
            = new List<Author>();

        public Author AddAuthor(String nameAuthor,String lastNameAuthor)
        {
            if (nameAuthor.IsNullOrWhiteSpace() || lastNameAuthor.IsNullOrWhiteSpace())
            {
                throw new NullReferenceException("The author's first or last name is empty ");
            }

            Author returnAuthor = Authors?.FirstOrDefault(author =>
                author.Name == nameAuthor && author.LastName == lastNameAuthor);

            if (returnAuthor == null)
            {
                returnAuthor = new Author(nameAuthor, lastNameAuthor);
                Authors.Add(returnAuthor);
            }

            return returnAuthor;
        }


    }
}
