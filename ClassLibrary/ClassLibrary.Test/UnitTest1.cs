using NUnit.Framework;

namespace ClassLibrary.Test
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestBooksExist()
        {
            Library l = new Library();
            Assert.AreEqual(true, l.Books!=null);
        }

        [Test]
        public void TestBooks()
        {
            Library l = new Library();
            Assert.AreEqual(true, l.Books?.Count>=0);
        }
    }
}
