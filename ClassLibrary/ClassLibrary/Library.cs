using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class Library
    {
        public List<Book> Books= new List<Book>();

        public void AddBook(String ISBN, String nameBook,Author author)
        {
            if (ISBN.IsNullOrWhiteSpace() || nameBook.IsNullOrWhiteSpace() || author == null)
            {
                throw new ArgumentNullException("One of the fields of the book is empty");
            }

            Book returnBook = Books?.FirstOrDefault(x => x.ISBN == ISBN);

            if (returnBook != null)
            {
                throw new ArgumentException("This book does not exist ");
            }
            else
            {
                returnBook = new Book(ISBN, nameBook, author);
                Books.Add(returnBook);
            }
        }

        public List<Author> Authors = new List<Author>();

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
