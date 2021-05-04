using NUnit.Framework;

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

        [Test]
        public void AddNewAuthor()
        {
            Library lib = new Library();
            lib.AddAuthor("Лев", "Толстой");
            //как проще реализовывать проверку, составных объектов?
            Assert.AreEqual(true, lib.Authors[0].Name=="Лев"&&lib.Authors[0].LastName =="Толстой");
        }

    }
}
