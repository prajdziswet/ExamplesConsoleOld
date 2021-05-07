using System;
using NUnit.Framework;

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
            Author author = lib.AddAuthor("Lev", "Tolstoj");
            lib.AddBook("226611156", "War and Peace", author);

            Assert.IsTrue(lib.Books[0].ISBN== "226611156");
            Assert.IsTrue(lib.Books[0].NameBook == "War and Peace");
            Assert.IsTrue(lib.Books[0].AuthorBook == lib.AddAuthor("Lev", "Tolstoj"));
        }

        [Test]
        public void AddIncorrectNameBook_Empty()
        {
            bool check = false;
            try
            {
                Library lib = new Library();
                Author author = lib.AddAuthor("Lev", "Tolstoj");
                lib.AddBook("226611156", "", author);
            }
            catch (NullReferenceException)
            {
                check = true;
            }
            catch (Exception)
            {
            }
            

            Assert.IsTrue(check);
        }

        [Test]
        public void AddIncorrectNameBook_Null()
        {
            bool check = false;
            try
            {
                Library lib = new Library();
                Author author = lib.AddAuthor("Lev", "Tolstoj");
                lib.AddBook("226611156", null, author);
            }
            catch (NullReferenceException)
            {
                check = true;
            }
            catch (Exception)
            {
            }


            Assert.IsTrue(check);
        }

        [Test]
        public void AddIncorrectISBN_Emty()
        {
            bool check = false;
            try
            {
                Library lib = new Library();
                Author author = lib.AddAuthor("Lev", "Tolstoj");
                lib.AddBook("", "War and Peace", author);
            }
            catch (NullReferenceException)
            {
                check = true;
            }
            catch (Exception)
            {
            }

            Assert.IsTrue(check);
        }

        [Test]
        public void AddIncorrectISBN_Null()
        {
            bool check = false;
            try
            {
                Library lib = new Library();
                Author author = lib.AddAuthor("Lev", "Tolstoj");
                lib.AddBook(null, "War and Peace", author);
            }
            catch (NullReferenceException)
            {
                check = true;
            }
            catch (Exception)
            {
            }
            
            Assert.IsTrue(check);
        }

        [Test]
        public void AddIncorrectISBN_NotUnique()
        {
            bool check = false;
            try
            {
                Library lib = new Library();
                Author author = lib.AddAuthor("Lev", "Tolstoj");
                lib.AddBook("226611156", "War and Peace", author);
                lib.AddBook("226611156", "Mu-Mu", author);
            }
            catch (ArgumentException)
            {
                check = true;
            }
            catch (Exception)
            {
            }

            Assert.IsTrue(check);
        }

        [Test]
        public void AddIncorrectAuthor_Null()
        {
            bool check = false;
            try
            {
                Library lib = new Library();
                Author author = lib.AddAuthor("Lev", "Tolstoj");
                lib.AddBook("226611156", "War and Peace", null);
            }
            catch (NullReferenceException)
            {
                check = true;
            }
            catch (Exception)
            {
            }

            Assert.IsTrue(check);
        }
    }
}