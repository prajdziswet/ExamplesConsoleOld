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
            Book returnBook = Books?.FirstOrDefault(x => x.ISBN == ISBN);
            Author authorInAuthors = Authors?.FirstOrDefault(x => x.ID == author?.ID);

            if (returnBook != null)
            {
                throw new ArgumentException("This book's ISBN exists");
            }
            else if (authorInAuthors == null)
            {
                throw new ArgumentException("This author doesn't exist");
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
            Author returnAuthor = Authors?.FirstOrDefault(author =>
                author.Name == nameAuthor && author.LastName == lastNameAuthor);

            if (returnAuthor == null)
            {
                returnAuthor = new Author(nameAuthor, lastNameAuthor);
                Authors.Add(returnAuthor);
            }

            return returnAuthor;
        }

        public List<CardReader> CardReaders
        {
            get;
            private set;
        }
            = new List<CardReader>();

        //I'm breaking the rule AV1115, but "AddAuthor" breaking the rule too
        public CardReader GetCardForReader(String NameReader,String LastNameReader)
        {
            CardReader cardReader =
                CardReaders.FirstOrDefault(card => card.Name == NameReader && card.LastName == LastNameReader);
            if (cardReader == null)
            {
                cardReader=new CardReader(NameReader, LastNameReader);
                CardReaders.Add(cardReader);
            }

            return cardReader;
        }


    }
}
