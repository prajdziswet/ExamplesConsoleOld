using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public void AddNewAuthor()
        {
            Library lib = new Library();
            lib.AddAuthor("Lev", "Tolstoj");
            Assert.AreEqual(true, lib.Authors[0].Name== "Lev" && lib.Authors[0].LastName == "Tolstoj");
        }

        [Test]
        public void AddEmptyAuthor()
        {
            Library lib = new Library();
            bool checkFlag = false;
            try
            { 
            lib.AddAuthor("", "Tolstoj");
            }
            catch (NullReferenceException)
            {
                checkFlag = true;
            }
            Assert.AreEqual(true, checkFlag);
        }

        [Test]
        public void AddNullAuthor()
        {
            Library lib = new Library();
            bool checkFlag = false;
            try
            {
                lib.AddAuthor("Lev", null);
            }
            catch (NullReferenceException)
            {
                checkFlag = true;
            }
            Assert.AreEqual(true, checkFlag);
        }

        [Test]
        public void AddNewAuthors()
        {
            Library lib = new Library();
            lib.AddAuthor("Lev", "Tolstoj");
            lib.AddAuthor("Alexsandr", "Puskin"); 
            lib.AddAuthor("Anton", "Chehov");

            Assert.IsTrue(lib.Authors[0].Name == "Lev");
            Assert.IsTrue(lib.Authors[0].LastName == "Tolstoj");
            Assert.IsTrue(lib.Authors[1].Name == "Alexsandr");
            Assert.IsTrue(lib.Authors[1].LastName == "Puskin");
            Assert.IsTrue(lib.Authors[2].Name == "Anton");
            Assert.IsTrue(lib.Authors[2].LastName == "Chehov");
        }

        [Test]
        public void AddSimularAuthors()
        {
            Library lib = new Library();
            lib.AddAuthor("Lev", "Tolstoj");
            lib.AddAuthor("Lev", "Tolstoj");
            Assert.AreEqual(true, lib.Authors.Count == 1);
        }

        [Test]
        public void AddSimularNameOrLastNameAuthors()
        {
            Library lib = new Library();
            lib.AddAuthor("Lev", "Tolstoj");
            lib.AddAuthor("Alexsandr", "Tolstoj");
            lib.AddAuthor("Alexsandr", "Puskin");

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
            lib.AddAuthor("Lev", "Tolstoj");
            lib.AddAuthor("Alexsandr", "Tolstoj");
            lib.AddAuthor("Alexsandr", "Puskin");

            Assert.IsTrue(lib.Authors[0].ID != lib.Authors[1].ID);
            Assert.IsTrue(lib.Authors[0].ID != lib.Authors[2].ID);
            Assert.IsTrue(lib.Authors[1].ID != lib.Authors[2].ID);
        }
    }
}
