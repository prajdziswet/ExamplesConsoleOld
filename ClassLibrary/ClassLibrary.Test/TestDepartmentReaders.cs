using System;
using NUnit.Framework;
using Shouldly;

namespace ClassLibrary.Test
{
    [TestFixture]
    public class TestDepartmentReaders
    {
        [Test]
        public void Add_NullReader()
        {
            DepartmentReaders DR = new DepartmentReaders();
            Should.Throw<ArgumentNullException>(() => DR.AddReader(null));
        }

        [Test]
        public void AddReader()
        {
            DepartmentReaders DR = new DepartmentReaders();
            Reader reader = new Reader("Lev", "Tolstoj");
            DR.AddReader(reader);

            Reader gotReader = DR.GetReader(reader.ID);
            gotReader.ShouldBe(reader);
        }

        [Test]
        public void AddEqualReaders()
        {
            DepartmentReaders DR = new DepartmentReaders();
            Reader reader = new Reader("Lev", "Tolstoj");
            DR.AddReader(reader);

            Should.Throw<ArgumentException>(() => DR.AddReader(reader));
        }

        [Test]
        public void ReturnNotReader()
        {
            DepartmentReaders DR = new DepartmentReaders();
            DR.GetReader(0).ShouldBe(null);
        }

        [Test]
        public void AddBookNotExistReader()
        {
            DepartmentReaders DR = new DepartmentReaders();
            Author author = new Author("Lev", "Tolstoj");
            Reader reader = new Reader("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);

            Should.Throw<ArgumentException>(()=>DR.BorrowBook(reader,book));
        }

        [Test]
        public void BorrowedBookForReader()
        {
            DepartmentReaders DR = new DepartmentReaders();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            Reader reader = new Reader("Lev", "Tolstoj");
            DR.AddReader(reader);
            DR.BorrowBook(reader,book);
            Reader reader1 = new Reader("Alex", "Tolstoj");
            DR.AddReader(reader1);

            DR.CountBorrowedBooksWithISBN(book.ISBN).ShouldBe(1);
            Should.Throw<ArgumentException>(() => DR.BorrowBook(reader1, book));
        }

        [Test]
        public void BorrowedBookNullArgument()
        {
            DepartmentReaders DR = new DepartmentReaders();
            Author author = new Author("Lev", "Tolstoj");
            Book book = new Book("226611156", "War and Peace", author);
            Reader reader = new Reader("Lev", "Tolstoj");
            DR.AddReader(reader);

            Should.Throw<ArgumentNullException>(() => DR.BorrowBook(null, book));
            Should.Throw<ArgumentNullException>(() => DR.BorrowBook(reader, null));
        }

        [Test]
        public void NotList_GetTimeWhenFreeBook()
        {
            DepartmentReaders DR = new DepartmentReaders();
            //I think it doesn't matter which parameter returns. What do you think? 
            Should.Throw<ArgumentNullException>(() => DR.GetTimeWhenFreeBook(null));
            Should.Throw<ArgumentNullException>(() => DR.GetTimeWhenFreeBook(new System.Collections.Generic.List<BorrowedBook>()));
        }
    }
}