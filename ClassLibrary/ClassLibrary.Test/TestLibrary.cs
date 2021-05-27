using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using Shouldly;

namespace ClassLibrary.Test
{
    [TestFixture]
    class TestLibrary
    {
        [Test]
        public void BorrowBooks()
        {
            Library lib = new Library();
            //Add Book
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            lib.AddBookInLibrary(book);
            //Add reader
            Reader reader = new Reader("Ivan", "Ivanov");
            lib.AddReader(reader);
            //Borrow Books
            lib.ReaderBoroweBook(reader, book);

            lib.GetReader(reader.ID).BorrowedBooks.Count.ShouldBe(1);

        }

        [Test]
        public void NotReader()
        {
            Library lib = new Library();
            //Add Book
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            lib.AddBookInLibrary(book);
            
            Reader reader = new Reader("Ivan", "Ivanov");
            Should.Throw<ArgumentException>(() => lib.ReaderBoroweBook(reader, book));
        }

        [Test]
        public void BooKWithIDBorrowed()
        {
            Library lib = new Library();
            //Add Book
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            lib.AddBookInLibrary(book);
            //Add reader
            Reader reader = new Reader("Ivan", "Ivanov");
            lib.AddReader(reader);
            //Borrow Books
            lib.ReaderBoroweBook(reader, book);

            Should.Throw<ArgumentException>(() => lib.ReaderBoroweBook(reader, book));
        }

        [Test]
        public void NotThisBooK()
        {
            Library lib = new Library();
            //Add Book
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);

            //Add reader
            Reader reader = new Reader("Ivan", "Ivanov");
            lib.AddReader(reader);

            Should.Throw<ArgumentException>(() => lib.ReaderBoroweBook(reader, book));
        }

        [Test]
        public void ALLBooKWithISBNBorrowed()
        {
            Library lib = new Library();
            //Add Book
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            lib.AddBookInLibrary(book);
            //Add reader
            Reader reader = new Reader("Ivan", "Ivanov");
            lib.AddReader(reader);
            Reader reader1 = new Reader("Alex", "Ivanov");
            lib.AddReader(reader1);
            //Borrow Books
            lib.ReaderBoroweBook(reader, book);

            Should.Throw<ArgumentException>(() => lib.ReaderBoroweBook(reader1, book));
        }
    }
}
