using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void AddSameBook()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            RB.AddBook(book);
            Should.Throw<ArgumentException>(() => RB.AddBook(book));
        }

        [TestCase("226611156", "War and Peace",0)]
        [TestCase("226611156", "War and Peace",1)]
        public void AddBookWithSameArgument(String ISBN,String NameBook, int numberbook)
        {
            RepositoryBooks RB = new RepositoryBooks();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book(ISBN, NameBook, author);
            RB.AddBook(book);
            Book book1 = new Book(ISBN, NameBook, author);
            RB.AddBook(book1);

            List<Book> books = RB.FindBooks();

            books.Count.ShouldBe(2);
            Assert.IsTrue(books[numberbook].ISBN == ISBN);
            Assert.IsTrue(books[numberbook].NameBook == NameBook);
            Assert.IsTrue(books[numberbook].AuthorBook == author);
        }

        [Test]
        public void AddOneBook()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            RB.AddBook(book);

            List<Book> books = RB.FindBooks();

            books.Count.ShouldBe(1);
            Assert.IsTrue(books[0].ISBN == "226611156");
            Assert.IsTrue(books[0].NameBook == "War and Peace");
            Assert.IsTrue(books[0].AuthorBook == author);
        }

        [TestCase("","","",2)]
        [TestCase("", "", "Tolstoj", 2)]
        [TestCase("", "Lev", "", 2)]
        [TestCase("", "Lev", "Tolstoj", 2)]
        [TestCase("War and Peace", "", "", 1)]
        [TestCase("War and Peace", "", "Tolstoj", 1)]
        [TestCase("War and Peace", "Lev", "", 1)]
        [TestCase("War and Peace", "Lev", "Tolstoj", 1)]
        public void FindBook(String NameBook,String NameAuthor,String LastNameAuthor,int CountBook)
        {
            RepositoryBooks RB = new RepositoryBooks();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            RB.AddBook(book);
            Book book1 = new Book("226611188", "Anna", author);
            RB.AddBook(book1);

            List<Book> books = RB.FindBooks(NameBook, NameAuthor, LastNameAuthor);

            books.Count.ShouldBe(CountBook);

            switch (CountBook)
            {
                case 2:
                { 
                    books[0].ShouldBe(book);
                    books[1].ShouldBe(book1);
                    break;
                }
                case 1:
                {
                    books[0].ShouldBe(book);
                    break;
                }
            }
        }

        [TestCase("", "", "")]
        [TestCase("", "", "Tolstoj")]
        [TestCase("", "Lev", "")]
        [TestCase("", "Lev", "Tolstoj")]
        [TestCase("War and Peace", "", "")]
        [TestCase("War and Peace", "", "Tolstoj")]
        [TestCase("War and Peace", "Lev", "")]
        [TestCase("War and Peace", "Lev", "Tolstoj")]
        public void NotFindBook(String NameBook, String NameAuthor, String LastNameAuthor)
        {
            RepositoryBooks RB = new RepositoryBooks();
            if (NameBook.IsNullOrWhiteSpace()==false ||
                NameAuthor.IsNullOrWhiteSpace() == false ||
                LastNameAuthor.IsNullOrWhiteSpace() == false)
            {
                Author author = new Author("Alexsandr", "Pushkin");
                Book book = new Book("226611156", "Evgenij Onegin", author);
                RB.AddBook(book);
                Book book1 = new Book("226611188", "Rusalka", author);
                RB.AddBook(book1);
            }

            List<Book> books = RB.FindBooks(NameBook, NameAuthor, LastNameAuthor);

            books.Count.ShouldBe(0);
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

            RB.GetBook(book.ID).ShouldBe(book);
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

            RB.GetBook(book1.ID).ShouldBe(null);
        }

        [Test]
        public void AddBookEqualISBN()
        {
            RepositoryBooks RB = new RepositoryBooks();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            RB.AddBook(book);
            Book book1 = new Book("226611156", "War and Peace", author);
            RB.AddBook(book1);

            List<Book> books = RB.FindBooks();

            books.Count.ShouldBe(2);
        }

        [TestCase("War and Peace", "Al", "Tolstoj"]
        [TestCase("War and Peace","Lev", "Chehov"]
        [TestCase("Mu - MU", "Lev", "Tolstoj"]
        public void AddDifferentBookEqualISBN(String NameBook, String NameAuthor, String LastNameAuthor)
        {
            RepositoryBooks RB = new RepositoryBooks();
            String ISBN = "226611156";
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book(ISBN, "War and Peace", author);
            RB.AddBook(book);

            Book book1 = new Book(ISBN, NameBook, new Author(NameAuthor, LastNameAuthor));
            Should.Throw<ArgumentException>(() => RB.AddBook(book1));
        }
    }
}