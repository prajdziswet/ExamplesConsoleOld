using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace ClassLibrary.Test
{
    [TestFixture]
    public class TestRepositoryBooks
    {
        [Test]
        public void ListBooksExist()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Assert.AreEqual(true, RB.FindBooks() != null);
        }

        [Test]
        public void ListIsNoBooks()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Assert.AreEqual(0, RB.FindBooks()?.Count);
        }

        [Test]
        public void AddBook_Null()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Should.Throw<ArgumentNullException>(() => RB.AddBook(null));
        }

        [Test]
        public void AddIncorrectISBN_NotUnique()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            RB.AddBook(book);
            Should.Throw<ArgumentException>(() => RB.AddBook(new Book("226611156", "Mu-Mu", author)));
        }

        [Test]
        public void AddNewBook()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            RB.AddBook(book);

            List<Book> books = RB.FindBooks();

            Assert.IsTrue(books[0].ISBN == "226611156");
            Assert.IsTrue(books[0].NameBook == "War and Peace");
            Assert.IsTrue(books[0].AuthorBook == author);
        }
    }
}