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
            Assert.AreEqual(true, lib.Books?.Count==0);
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
            Assert.AreEqual(true, lib.Authors?.Count == 0);
        }
    }
}
