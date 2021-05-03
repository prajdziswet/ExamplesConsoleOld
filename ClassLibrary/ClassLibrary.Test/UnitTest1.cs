using NUnit.Framework;

namespace ClassLibrary.Test
{
    [TestFixture]
    public class UnitTest1
    {
        Library lib = new Library();

        [Test]
        public void TestBooksExist()
        {
            
            Assert.AreEqual(true, lib.Books!=null);
        }

        [Test]
        public void TestBooks()
        {
            Assert.AreEqual(true, lib.Books?.Count==0);
        }

        [Test]
        public void TestAuthorExist()
        {
            Assert.AreEqual(true, lib.Authors != null);
        }

        [Test]
        public void TestAuthors()
        {
            Assert.AreEqual(true, lib.Authors?.Count == 0);
        }
    }
}
