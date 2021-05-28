﻿using System;
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
        public void BorrowBooks_2()
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
            lib.ReaderBoroweBook(reader.ID, book.NameBook);

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
        public void NotReader_2()
        {
            Library lib = new Library();
            //Add Book
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            lib.AddBookInLibrary(book);

            Reader reader = new Reader("Ivan", "Ivanov");
            Should.Throw<ArgumentException>(() => lib.ReaderBoroweBook(reader.ID, book.NameBook));
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
        public void NotSetNamebook()
        {
            Library lib = new Library();
            //Add Book
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            //Add reader
            Reader reader = new Reader("Ivan", "Ivanov");

            Should.Throw<ArgumentException>(() => lib.ReaderBoroweBook(reader.ID, ""));
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
        public void NotThisBooK_2()
        {
            Library lib = new Library();
            //Add Book
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);

            //Add reader
            Reader reader = new Reader("Ivan", "Ivanov");
            lib.AddReader(reader);

            Should.Throw<ArgumentException>(() => lib.ReaderBoroweBook(reader.ID, book.NameBook));
        }

        [Test]
        public void ALLBooKWithISBNBorrowed()
        {
            Library lib = new Library();
            //Add Book
            Author author = new Author("Lev", "Tolstoj");
            Book book1 = new Book("226611156", "War and Peace", author);
            lib.AddBookInLibrary(book1);
            //Add reader
            Reader reader1 = new Reader("Ivan", "Ivanov");
            lib.AddReader(reader1);
            Reader reader2 = new Reader("Alex", "Ivanov");
            lib.AddReader(reader2);
            //Borrow Books
            lib.ReaderBoroweBook(reader1, book1);

            Should.Throw<ArgumentException>(() => lib.ReaderBoroweBook(reader2, book1)).Message.ShouldBe($"ALL books with {book1.ISBN} borrowed");
        }

        [Test]
        public void ALLBooKWithISBNBorrowed_2()
        {
            Library lib = new Library();
            //Add Book
            Author author = new Author("Lev", "Tolstoj");
            Book book1 = new Book("226611156", "War and Peace", author);
            lib.AddBookInLibrary(book1);
            Book book2 = new Book("226611156", "War and Peace", author);
            lib.AddBookInLibrary(book2);
            //Add reader
            Reader reader1 = new Reader("Ivan", "Ivanov");
            lib.AddReader(reader1);
            Reader reader2 = new Reader("Alex", "Ivanov");
            lib.AddReader(reader2);
            Reader reader3 = new Reader("olja", "Ivanova");
            lib.AddReader(reader3);
            //Borrow Books
            lib.ReaderBoroweBook(reader1, book1);
            lib.ReaderBoroweBook(reader2, book2);

            Should.Throw<ArgumentException>(() => lib.ReaderBoroweBook(reader3.ID, book1.NameBook)).Message.ShouldBe("ALL books borrowed");
        }
    }
}