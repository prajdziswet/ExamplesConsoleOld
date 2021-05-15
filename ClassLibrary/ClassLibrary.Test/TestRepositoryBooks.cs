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

        [Test]
        public void FindBookAll()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            RB.AddBook(book);
            Author author1 = new Author("Lev", "Tolstoj");
            Book book1 = new Book("226611188", "Anna", author1);
            RB.AddBook(book1);

            List<Book> books = RB.FindBooks();

            books[0].ShouldBe(book);
            books[1].ShouldBe(book1);
        }

        [Test]
        public void FindBookNameBook()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            RB.AddBook(book);

            List<Book> books = RB.FindBooks("War and Peace");

            books[0].ShouldBe(book);
        }

        [Test]
        public void FindBookNameAuthor()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            RB.AddBook(book);

            List<Book> books = RB.FindBooks("", "Lev");

            books[0].ShouldBe(book);
        }

        [Test]
        public void FindBookLastNameAuthor()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            RB.AddBook(book);

            List<Book> books = RB.FindBooks("", "", "Tolstoj");

            books[0].ShouldBe(book);
        }

        [Test]
        public void FindOneBook()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            RB.AddBook(book);
            Author author1 = new Author("Lev", "Tolstoj");
            Book book1 = new Book("226611188", "Anna", author1);
            RB.AddBook(book1);

            List<Book> books = RB.FindBooks( "War and Peace");

            books.Count.ShouldBe(1);
        }

        [Test]
        public void FindTwoBook()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            RB.AddBook(book);
            Author author1 = new Author("Lev", "Tolstoj");
            Book book1 = new Book("226611188", "Anna", author1);
            RB.AddBook(book1);

            List<Book> books = RB.FindBooks("", "Lev");

            books.Count.ShouldBe(2);
        }

        [Test]
        public void GetBook()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            RB.AddBook(book);
            Author author1 = new Author("Lev", "Tolstoj");
            Book book1 = new Book("226611188", "Anna", author1);
            RB.AddBook(book1);

            RB.GetBook("226611156").ShouldBe(book);
        }

        [Test]
        public void GetNullBook()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            RB.AddBook(book);
            Author author1 = new Author("Lev", "Tolstoj");
            Book book1 = new Book("226611188", "Anna", author1);
            RB.AddBook(book1);

            RB.GetBook("226611999").ShouldBe(null);
        }
    }
}