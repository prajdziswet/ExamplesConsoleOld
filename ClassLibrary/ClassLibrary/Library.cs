using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class Library
    {
        //List All Books
        public List<Book> Books= new List<Book>();

        //List All Athor
        public List<Author> Authors = new List<Author>();
        //public List<CardReader> CardReaders = new List<CardReader>();
        //public List<Reader> Readers = new List<Reader>();

        //букк пока не смотри
        public void AddBook(String ISBN, String NameBook,String FullNameAuthor)
        {
            Book newBook = new Book();
        }

        public Author AddAuthor(String FullNameAuthor)
        {
            if (FullNameAuthor.IsNullOrWhiteSpace()) throw new NullReferenceException("Имя автора пусто");
            String[] fullNameAuthor = FullNameAuthor.Split(' ');
            if (fullNameAuthor?.Length!=2) throw new ArgumentException("Неправильное имя автора");

            return AddAuthor(fullNameAuthor[0], fullNameAuthor[0]);
        }

        public Author AddAuthor(String nameAuthor,String lastNameAuthor)
        {
            if (nameAuthor.IsNullOrWhiteSpace()|| lastNameAuthor.IsNullOrWhiteSpace()) throw new NullReferenceException("Имя или фамилии автора пусто");
            Author authorInList = Authors?.FirstOrDefault(author =>
                author.Name == nameAuthor && author.LastName == lastNameAuthor);

            Author returnAuthor;
            if (authorInList != null)
                returnAuthor=authorInList;
            else
            {
                returnAuthor = new Author(nameAuthor, lastNameAuthor, Authors.Count);
                Authors.Add(returnAuthor);
            }

            return returnAuthor;
        }


    }
}
