using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class Library
    {
        public List<Book> Books= new List<Book>();

        public List<Author> Authors = new List<Author>();

        public Author AddAuthor(String nameAuthor,String lastNameAuthor)
        {
            if (nameAuthor.IsNullOrWhiteSpace() || lastNameAuthor.IsNullOrWhiteSpace())
            {
                throw new NullReferenceException("Имя или фамилии автора пусто");
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
