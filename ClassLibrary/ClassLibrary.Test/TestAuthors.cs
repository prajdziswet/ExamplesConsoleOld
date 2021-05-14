using NUnit.Framework;
using System;
using Shouldly;

namespace ClassLibrary.Test
{
    [TestFixture]
    public class TestAuthors
    {

        [Test]
        public void ListAuthorsExist()
        {
            Library lib = new Library();
            Assert.AreEqual(true, lib.Authors != null);
        }

        [Test]
        public void ListIsNoAuthors()
        {
            Library lib = new Library();
            Assert.AreEqual(0, lib.Authors?.Count);
        }

        #region AddAuthor

        [Test]
        public void AddNewAuthorInList()
        {
            Library lib = new Library();
            Author author = new Author("Lev", "Tolstoj");
            lib.AddAuthor(author);
            Assert.AreEqual(true, lib.Authors[0].Name== "Lev" && lib.Authors[0].LastName == "Tolstoj");
        }

        [Test]
        public void AddEmptyAuthor()
        {
            Library lib = new Library();
            Should.Throw<ArgumentNullException>(() => new Author("", "Tolstoj"));
        }

        [Test]
        public void AddNullLastNameAuthor()
        {
            Library lib = new Library();
            Should.Throw<ArgumentNullException>(() => new Author("Lev", null));
        }

        [Test]
        public void AddNullNameAuthor()
        {
            Library lib = new Library();
            Should.Throw<ArgumentNullException>(() => new Author(null, "Tolstoj"));
        }

        [Test]
        public void AddNullAuthor()
        {
            Library lib = new Library();
            Should.Throw<ArgumentNullException>(() => lib.AddAuthor(null));
        }

        [Test]
        public void AddSimularAuthors()
        {
            Library lib = new Library();
            Author author = new Author("Lev", "Tolstoj");
            lib.AddAuthor(author);

            Should.Throw<ArgumentException>(() => lib.AddAuthor(author));
        }

        [Test]
        public void AddNewAuthors()
        {
            Library lib = new Library();
            Author author=new Author("Lev", "Tolstoj");
            lib.AddAuthor(author);
            author = new Author("Alexsandr", "Puskin");
            lib.AddAuthor(author);
            author = new Author("Anton", "Chehov");
            lib.AddAuthor(author);

            Assert.IsTrue(lib.Authors[0].Name == "Lev");
            Assert.IsTrue(lib.Authors[0].LastName == "Tolstoj");
            Assert.IsTrue(lib.Authors[1].Name == "Alexsandr");
            Assert.IsTrue(lib.Authors[1].LastName == "Puskin");
            Assert.IsTrue(lib.Authors[2].Name == "Anton");
            Assert.IsTrue(lib.Authors[2].LastName == "Chehov");
        }

        [Test]
        public void AddSimularNameOrLastNameAuthors()
        {
            Library lib = new Library();
            Author author = new Author("Lev", "Tolstoj");
            lib.AddAuthor(author);
            author = new Author("Alexsandr", "Tolstoj");
            lib.AddAuthor(author);
            author = new Author("Alexsandr", "Puskin");
            lib.AddAuthor(author);

            Assert.IsTrue(lib.Authors[0].Name == "Lev");
            Assert.IsTrue(lib.Authors[0].LastName == "Tolstoj");
            Assert.IsTrue(lib.Authors[1].Name == "Alexsandr");
            Assert.IsTrue(lib.Authors[1].LastName == "Tolstoj");
            Assert.IsTrue(lib.Authors[2].Name == "Alexsandr");
            Assert.IsTrue(lib.Authors[2].LastName == "Puskin");
        }
        #endregion

        [Test]
        public void CheckDifferentID()
        {
            Library lib = new Library();
            Author author = new Author("Lev", "Tolstoj");
            lib.AddAuthor(author);
            author = new Author("Alexsandr", "Tolstoj");
            lib.AddAuthor(author);
            author = new Author("Alexsandr", "Puskin");
            lib.AddAuthor(author);

            Assert.IsTrue(lib.Authors[0].ID != lib.Authors[1].ID);
            Assert.IsTrue(lib.Authors[0].ID != lib.Authors[2].ID);
            Assert.IsTrue(lib.Authors[1].ID != lib.Authors[2].ID);
        }
    }
}
