using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.Test
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void ListBooksExist()
        {
            Library lib = new Library();
            Assert.AreEqual(true, lib.Books!=null);
        }

        [Test]
        public void ListIsNoBooks()
        {
            Library lib = new Library();
            Assert.AreEqual(0, lib.Books?.Count);
        }

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

            List<String> result = new List<String>();
            lib.Authors.ForEach(x => { result.Add(x.Name); result.Add(x.LastName); }) ;
            Assert.IsTrue(result.ToArray().SequenceEqual(new[] { "Lev", "Tolstoj", "Alexsandr", "Puskin", "Anton", "Chehov" })) ;
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

            List<String> result = new List<String>();
            lib.Authors.ForEach(x => { result.Add(x.Name); result.Add(x.LastName); });
            Assert.IsTrue(result.ToArray().SequenceEqual(new[] { "Lev", "Tolstoj", "Alexsandr", "Tolstoj" , "Alexsandr", "Puskin" }));
        }
        #endregion
    }
}
