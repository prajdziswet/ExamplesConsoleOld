using NUnit.Framework;
using System;

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
            lib.AddAuthor("���", "�������");
            Assert.AreEqual(true, lib.Authors[0].Name=="���"&&lib.Authors[0].LastName =="�������");
        }

        [Test]
        public void AddEmptyAuthor()
        {
            Library lib = new Library();
            bool checkFlag = false;
            try
            { 
            lib.AddAuthor("", "�������");
            }
            catch (NullReferenceException ex)
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
                lib.AddAuthor("���", null);
            }
            catch (NullReferenceException ex)
            {
                checkFlag = true;
            }
            Assert.AreEqual(true, checkFlag);
        }

        [Test]
        public void AddNewAuthors()
        {
            Library lib = new Library();
            lib.AddAuthor("���", "�������");
            lib.AddAuthor("���������", "������"); 
            lib.AddAuthor("�����", "�����");
            Assert.AreEqual(true, lib.Authors[1].Name == "���������" && lib.Authors[1].LastName == "������"&&lib.Authors.Count==3) ;
        }

        [Test]
        public void AddSimularAuthors()
        {
            Library lib = new Library();
            lib.AddAuthor("���", "�������");
            lib.AddAuthor("���", "�������");
            Assert.AreEqual(true, lib.Authors.Count == 1);
        }

        [Test]
        public void AddSimularNameOrLastNameAuthors()
        {
            Library lib = new Library();
            lib.AddAuthor("���", "�������");
            lib.AddAuthor("���������", "�������");
            lib.AddAuthor("���������", "������");
            Assert.AreEqual(true, lib.Authors.Count == 3&& lib.Authors[1].Name == "���������" && lib.Authors[1].LastName == "�������");
        }
        #endregion
    }
}
