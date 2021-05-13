using System;
using NUnit.Framework;
using Shouldly;

namespace ClassLibrary.Test
{
    [TestFixture]
    public class TestBooks
    {
        [Test]
        public void ListBooksExist()
        {
            Library lib = new Library();
            Assert.AreEqual(true, lib.Books != null);
        }

        [Test]
        public void ListIsNoBooks()
        {
            Library lib = new Library();
            Assert.AreEqual(0, lib.Books?.Count);
        }

        [Test]
        public void AddNewBook()
        {
            Library lib = new Library();
            Author author = new Author("Lev", "Tolstoj");
            lib.AddAuthor(author);
            Book book = new Book("226611156", "War and Peace", author);
            lib.AddBook(book);

            Assert.IsTrue(lib.Books[0].ISBN == "226611156");
            Assert.IsTrue(lib.Books[0].NameBook == "War and Peace");
            Assert.IsTrue(lib.Books[0].AuthorBook == author);
        }

        [Test]
        public void AddIncorrectNameBook_Empty()
        {
            Library lib = new Library();
            Author author = new Author("Lev", "Tolstoj");

            Should.Throw<ArgumentNullException>(() => new Book("226611156", "", author));
        }

        [Test]
        public void AddIncorrectNameBook_Null()
        {
            Library lib = new Library();
            Author author = new Author("Lev", "Tolstoj");
            Should.Throw<ArgumentNullException>(() => new Book("226611156", null, author));
        }

        [Test]
        public void AddIncorrectISBN_Emty()
        {
            Library lib = new Library();
            Author author = new Author("Lev", "Tolstoj");
            Should.Throw<ArgumentNullException>(() => new Book("", "War and Peace", author));
        }

        [Test]
        public void AddIncorrectISBN_Null()
        {
            Library lib = new Library();
            Author author = new Author("Lev", "Tolstoj");
            Should.Throw<ArgumentNullException>(() => new Book(null, "War and Peace", author));
        }

        [Test]
        public void AddIncorrectISBN_NotUnique()
        {
            Library lib = new Library();
            Author author = new Author("Lev", "Tolstoj");
            lib.AddAuthor(author);
            Book book = new Book("226611156", "War and Peace", author);
            lib.AddBook(book);
            Should.Throw<ArgumentException>(() => lib.AddBook(new Book("226611156", "Mu-Mu", author)));
        }

        [Test]
        public void AddIncorrectAuthor_Null()
        {
            Library lib = new Library();
            Should.Throw<ArgumentException>(() => new Book("226611156", "War and Peace", null));
        }

        [Test]
        public void AthorNotExistInList()
        {
            Library lib = new Library();
            Author author = new Author("Lev", "Tolstoj");
            Should.Throw<ArgumentException>(() => lib.AddBook(new Book("226611156", "War and Peace", author)));
        }
    }
}